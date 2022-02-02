FROM gitpod/workspace-dotnet

# Install Azure Function Core Tools
RUN npm i -g azure-functions-core-tools@3 --unsafe-perm true
