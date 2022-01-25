terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~>2.0"
    }
  }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = var.ResourceGroupName
  location = var.ResourceGroupLocation
}

resource "random_id" "randomId" {
  keepers = {
    # Generate a new ID only when a new resource group is defined
    resource_group = azurerm_resource_group.rg.name
  }

  byte_length = 4
}

resource "azurerm_storage_account" "sa" {
  name                     = "assets${random_id.randomId.hex}"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_kind             = "StorageV2"
  account_replication_type = var.StorageReplicationType
  account_tier             = "Standard"

  tags = {
    environment = "Look at the resource group for more instructions!"
  }

  # identity {
  #   type = "SystemAssigned"
  # }

  static_website {
    # empty - causes Azure to create a static website and a container called $web,
    # which the system will use as its main storage container.
  }
}

resource "azurerm_storage_blob" "appcastcode" {
    name = "appcastcode-function.zip"
    storage_account_name = "${azurerm_storage_account.sa.name}"
    storage_container_name = "$web"
    type = "Block"
    source = "${var.functionapp}"
}

data "azurerm_storage_account_sas" "sas" {
    connection_string = "${azurerm_storage_account.sa.primary_connection_string}"

    https_only = true
    start = "2021-11-30"
    expiry = "2022-12-31"
    
    resource_types {
        object = true
        container = false
        service = false
    }
    services {
        blob = true
        queue = false
        table = false
        file = false
    }
    permissions {
        read = true
        write = false
        delete = false
        list = false
        add = false
        create = false
        update = false
        process = false
    }
}

resource "azurerm_application_insights" "insights" {
  name                = "insights${random_id.randomId.hex}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  application_type    = "web"
}

resource "azurerm_app_service_plan" "plan" {
  name                = "appcast-service-plan"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "FunctionApp"

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_function_app" "appcast" {
  name                       = "appcast-functions"
  location                   = azurerm_resource_group.rg.location
  resource_group_name        = azurerm_resource_group.rg.name
  app_service_plan_id        = azurerm_app_service_plan.plan.id
  storage_account_name       = azurerm_storage_account.sa.name
  storage_account_access_key = azurerm_storage_account.sa.primary_access_key

  version = "~4"

  identity {
    type = "SystemAssigned"
  }

  app_settings = {
        https_only = true
        FUNCTIONS_WORKER_RUNTIME = "dotnet"
        FUNCTIONS_EXTENSION_VERSION = "~4"
        FUNCTION_APP_EDIT_MODE = "readonly"
        APPINSIGHTS_INSTRUMENTATIONKEY = "${azurerm_application_insights.insights.instrumentation_key}"
        AzureWebJobsStorage = "${azurerm_storage_account.sa.primary_connection_string}"
        HASH = "${base64encode(filesha256("${var.functionapp}"))}"
        WEBSITE_RUN_FROM_PACKAGE = "https://${azurerm_storage_account.sa.name}.blob.core.windows.net/$web/${azurerm_storage_blob.appcastcode.name}${data.azurerm_storage_account_sas.sas.sas}"
    }
}

resource "azurerm_role_assignment" "role-storage" {
  scope                = azurerm_storage_account.sa.id
  role_definition_name = "Storage Blob Data Contributor"
  principal_id         = azurerm_function_app.appcast.identity.0.principal_id
}

