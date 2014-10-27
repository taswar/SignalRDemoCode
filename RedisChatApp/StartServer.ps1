function programfiles-dir {
    if (is64bit -eq $true) {
        (Get-Item "Env:ProgramFiles(x86)").Value
    } else {
        (Get-Item "Env:ProgramFiles").Value
    }
}

function is64bit() {
    return ([IntPtr]::Size -eq 8)
}

$executingPath = (Split-Path -parent $MyInvocation.MyCommand.Definition)
$appPPath = (join-path $executingPath "RedisChatApp")
$iisExpress = "$(programfiles-dir)\IIS Express\iisexpress.exe"
$args1 = "/path:$appPPath /port:9090 /clr:v4.0 /systray:false"
$args2 = "/path:'" + $appPPath + "' /port:9091 /clr:v4.0 /systray:false"

Write-Host("Starting process " + $args1);
Write-Host($iisExpress + " " + $args1 + "-windowstyle Normal");

start-process $iisExpress $args1 -windowstyle Normal 

Write-Host("Starting process " + $args2);
start-process $iisExpress $args2 -windowstyle Normal
