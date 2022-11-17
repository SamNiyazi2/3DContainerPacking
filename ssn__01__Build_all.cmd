
dotnet build src\CromulentBisgetti.ContainerPacking\CromulentBisgetti.ContainerPacking.csproj --configuration Release 
rem dotnet publish src\CromulentBisgetti.ContainerPacking\CromulentBisgetti.ContainerPacking.csproj -c Release -o ..\published001


dotnet build src\CromulentBisgetti.ContainerPackingTests\CromulentBisgetti.ContainerPackingTests.csproj --configuration Release 
rem dotnet publish src\CromulentBisgetti.ContainerPackingTests\CromulentBisgetti.ContainerPackingTests.csproj -c Release -o ..\published001



dotnet build src\CromulentBisgetti.DemoApp\CromulentBisgetti.DemoApp.csproj --configuration Release 
dotnet publish src\CromulentBisgetti.DemoApp\CromulentBisgetti.DemoApp.csproj -c Release -o ..\published001

