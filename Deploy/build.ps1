$exclude = @(".vs", "deploy", "build.ps1", ".gitignore", ".terra*", "*.tf", ".vscode")

Push-Location ../Necklace
& dotnet publish --sc -c Release -o build
Get-ChildItem -Path ./build -Exclude $exclude | Compress-Archive -DestinationPath ../Deploy/appcastcode-function.zip -Force

Pop-Location
