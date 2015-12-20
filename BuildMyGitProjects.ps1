[CmdletBinding()]
param()

$dnxPackages="C:\Users\mika\.dnx\packages"
$mygit = "C:\MyGit"


    
function Main()
{
    $projectJsonPaths = dir project.json -Recurse
    $projectDirectories = foreach($projectJsonPath in $projectJsonPaths){$projectJsonPath.Directory}
    foreach($projectDir in $projectDirectories)
    {
        Write-Host "cd to $projectDir" -BackgroundColor Green
        cd $projectDir
        dnu restore
        cd $myGit
    }
    $commonProject = Join-Path $myGit "Common\src"
    PublishNugetPackage $commonProject "Common.Core" 
    PublishNugetPackage $commonProject "Common.Mailer"
    PublishNugetPackage $commonProject "Common.ProcessExecution"
    $codingCodeProject = Join-Path $mygit "CodingCode\src"
    PublishNugetPackage $codingCodeProject "CodingCode.Web"
}
function PublishNugetPackage
{
    [CmdletBinding()]
    param(
        [parameter(Mandatory=$true)]
        [System.String]
        $commonProject,
        [parameter(Mandatory=$true)]
        [System.String]
        $dllName
    )
    $dll = Join-Path $commonProject $dllName
    Write-Host "passed arguments $DllName $dll" -BackgroundColor Green
    $NugetPath = Join-Path $dnxPackages $dllName
    Write-Host "join-path $NugetPath"
    if(Test-Path $NugetPath){
        Remove-Item $NugetPath -Recurse
        Write-Host "Removing $NugetPath" -BackgroundColor Green
    }
    Write-Host "cd to $dll" -BackgroundColor Green
    cd $dll
    Write-Host "publishing to $dnxPackages" -BackgroundColor Green
    $outPath = Join-Path (Join-Path $dnxPackages "approot\packages") $dllName
    dnu publish --no-source --out $dnxPackages; Copy-Item  $outPath $dnxPackages -Recurse
    Write-Host "publish completed" -BackgroundColor Green
    cd $mygit
}

Main