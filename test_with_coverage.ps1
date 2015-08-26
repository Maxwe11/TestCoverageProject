$isPullRequest = $env:APPVEYOR_PULL_REQUEST_NUMBER -ne $null
$packagesDir = "./packages"
$coverageDir = "./codecoverage"
$xunitConsoleExe = "$packagesDir/xunit.runner.console.2.0.0/tools/xunit.console.exe"
$openCoverExe = "$packagesDir/OpenCover.4.6.166/tools/OpenCover.Console.exe"
$reportGeneratorExe = "$packagesDir/ReportGenerator.2.2.0.0/tools/ReportGenerator.exe"
$testDir = "*/bin/*"
$tests = @("$testDir/*Tests.dll")
$targetArgs = Get-ChildItem $tests -Recurse
$outputXml = "CodeCoverage.xml"
$converallsNetExe = "$packagesDir/coveralls.io.1.3.4/tools/coveralls.net.exe"
$openCoverArgs = @('-register:user', "`"-target:$xunitConsoleExe`"", "`"-targetargs:$targetArgs -appveyor -noshadow -nologo -quiet`"", "`"-filter:+[TestCoverageProject]*`"", "`"-output:$outputXml`"", '-coverbytest:*Tests.dll', '-log:All', '-returntargetcode')
& $openCoverExe $openCoverArgs
& $reportGeneratorExe -verbosity:Info "`"-reports:$outputXml`"" "`"-targetdir:$coverageDir`""
if (!$isPullRequest)
{
    & $converallsNetExe --opencover $outputXml --full-sources --repo-token R5PvoZmhUHpuI3Sq6KU3Wc9hxOH2uTAzD        
}