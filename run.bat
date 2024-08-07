start dotnet run --project="PinewoodsCrm.API"
start dotnet run --project="PinewoodsCrm.UI"
timeout 5
explorer "https://localhost:5000/swagger/index.html"
explorer "https://localhost:7065"
exit