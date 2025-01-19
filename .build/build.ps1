# Constants
$slnPath = "..\src\DTDatabaseEntry\DTDatabaseEntry.sln"
$compiledBinDir = "..\src\DTDatabaseEntry\DTDatabaseEntry\bin\Release"
$customizationProjectDir = "..\src\project\*"
$buildToolPath = "./tool/PackageBuild.exe"
$packageOutputDir = "output"
$packageBinDir = "$packageOutputDir\Bin"
$packageName = "DTDBFormEntry[24.204.0004].zip"
$description = "v1.0"
$level = 0
$acumaticaVersion = "24.204.0004"

# Function to search for MSBuild in common installation directories
function Get-MsBuild-Path {
    $msbuildPaths = @(
        "${env:ProgramFiles(x86)}\Microsoft Visual Studio\*\*\MSBuild\*\Bin\MSBuild.exe",
        "${env:ProgramFiles}\JetBrains\*\tools\MSBuild\Current\Bin\MSBuild.exe",
        "${env:ProgramFiles}\MSBuild\*\Bin\MSBuild.exe",
        "${env:ProgramFiles(x86)}\MSBuild\*\Bin\MSBuild.exe"
    )
    # Find the first existing path
    $msbuildPath = $msbuildPaths | Where-Object { Test-Path $_ } | Select-Object -First 1
    return $msbuildPath
}

# Find MSBuild path
$msbuildPath = Get-MsBuild-Path
if ($msbuildPath) {
    Write-Output "MSBuild found at: $msbuildPath"
} else {
    Write-Error "MSBuild not found. Exiting script."
    exit 1
}

# Restore NuGet packages
Write-Output "Restoring NuGet packages..."
& "..\.nugets\nuget.exe" restore "$slnPath"

# Compile customization project
Write-Output "Compiling solution..."
& "$msbuildPath" /t:Rebuild /p:Configuration=Release "$slnPath" /p:WarningLevel=0 /nologo > $null 2>&1
$exitCode = $LASTEXITCODE

# Check if the build was successful
if ($exitCode -eq 0) {
    Write-Output "Build succeeded."
} else {
    Write-Output "Build failed with exit code $exitCode."
    exit $exitCode
}

# Prepare output directories
Write-Output "Preparing output directories..."
Remove-Item $packageOutputDir -Force -Recurse -ErrorAction SilentlyContinue
New-Item -ItemType "directory" -Path "$packageBinDir"

# Copy required files to output directory
Write-Output "Copying required files..."
Copy-Item "$compiledBinDir\DTDatabaseEntry.dll" -Destination "$packageBinDir" -Force
Copy-Item "$customizationProjectDir" -Destination "$packageOutputDir" -Recurse -Force

# Remove existing package if it exists
Write-Output "Cleaning up existing package..."
Remove-Item -Path "$packageName" -Force -ErrorAction SilentlyContinue

# Create a zip archive for the customization package
Write-Output "Building customization package..."
& $buildToolPath build --customizationpath "$packageOutputDir" --packagefilename "$packageName" --description "$description" --level $level --product-version "$acumaticaVersion"

Write-Output "Customization package created: $packageName"
