$exclude = @(".vs", "deploy", "build.ps1", ".gitignore", ".terra*", "*.tf", ".vscode")

Push-Location ../Necklace
& dotnet build -c Release 
Get-ChildItem -Path ./bin/Release -Exclude $exclude | Compress-Archive -DestinationPath ../Deploy/appcastcode-function.zip -Force

Pop-Location
