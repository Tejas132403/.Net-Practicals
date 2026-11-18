# Run Script for SmartCampusPortal ASP.NET MVC & Web API Application
Write-Host "Checking / Starting SQL LocalDB (MSSQLLocalDB)..." -ForegroundColor Cyan
sqllocaldb start MSSQLLocalDB

Write-Host "Building SmartCampusPortal..." -ForegroundColor Cyan
$msbuild = "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"
if (-not (Test-Path $msbuild)) {
    $found = Get-ChildItem -Path "C:\Program Files\Microsoft Visual Studio", "C:\Program Files (x86)\Microsoft Visual Studio" -Recurse -Filter "MSBuild.exe" -ErrorAction SilentlyContinue | Select-Object -First 1 -ExpandProperty FullName
    if ($found) { $msbuild = $found }
}

& $msbuild "$PSScriptRoot\SmartCampusPortal.csproj" /t:Build /p:Configuration=Debug /verbosity:minimal

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed! Please check errors." -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host "Build successful!" -ForegroundColor Green
$port = 59705
$url = "http://localhost:$port/ServiceRequest"
Write-Host "Starting IIS Express on $url ..." -ForegroundColor Yellow
Write-Host "MVC View:  $url" -ForegroundColor Green
Write-Host "Web API:   http://localhost:$port/api/ServiceApi" -ForegroundColor Green

# Launch default browser
Start-Process $url

# Run IIS Express
& "C:\Program Files\IIS Express\iisexpress.exe" /path:"$PSScriptRoot" /port:$port
