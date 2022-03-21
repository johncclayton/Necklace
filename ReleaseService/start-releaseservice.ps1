#$env:ASPNETCORE_ENVIRONMENT = "Development"
dapr run --app-id releaseservice --app-port 5227 --dapr-http-port 7000 --dapr-grpc-port 8000 