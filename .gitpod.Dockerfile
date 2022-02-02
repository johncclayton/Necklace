FROM gitpod/workspace-dotnet

# Install Azure Function Core Tools
RUN npm i -g azure-functions-core-tools@3 --unsafe-perm true
# And now the Azurite Storage Emulator for unit tests and local development
RUN npm install -g azurite
# Bring in the az cli so I can manipulate stuff locally or in Cloud
RUN curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
