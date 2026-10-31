# Run Script for PlacementDashboard ASP.NET Web Application
Write-Host "Building PlacementDashboard..." -ForegroundColor Cyan
& "C:\Program Files\Microsoft Visual Studio\18\Insiders\MSBuild\Current\Bin\MSBuild.exe" "$PSScriptRoot\PlacementDashboard.csproj" /t:Build /p:Configuration=Debug /verbosity:minimal

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed! Please resolve errors." -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host "Build successful!" -ForegroundColor Green
Write-Host "Starting IIS Express on http://localhost:5000/Default.aspx ..." -ForegroundColor Yellow

# Launch default browser
Start-Process "http://localhost:5000/Default.aspx"

# Run IIS Express
& "C:\Program Files\IIS Express\iisexpress.exe" /path:"$PSScriptRoot" /port:5000
