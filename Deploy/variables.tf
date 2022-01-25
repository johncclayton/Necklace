
variable "ResourceGroupName" {
    default = "NecklaceRG"
    description = "The name of the resource group that this system will be deployed into"
}

variable "ResourceGroupLocation" {
    default = "SwitzerlandNorth"
    description = "The Azure region/location that the project resources will be deployed to"
}

variable "StorageReplicationType" {
    default = "GRS"
    description = "Which storage replication type will be set"
}

variable "functionapp" {
    type = string
    default = "./appcastcode-function.zip"
}