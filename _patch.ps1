param([string]$pathToKenaflow = "")

if( [string]::IsNullOrEmpty($pathToKenaflow) ) {
	$pathToKenaflow = Read-Host -Prompt "Path to kenaflow.exe:"
}

$p = split-path $MyInvocation.MyCommand.path

Get-ChildItem $p -Recurse -File | ? { $_.FullName -notlike "*.snk" -and $_.FullName -notlike "*\obj\*" -and $_.FullName -notlike "*\packages\*" -and $_.FullName -notlike "*\.git\*" } | % {
    write-host $_.FullName
    $r = [system.io.file]::ReadAllLines($_.FullName)

    $r = $r | % {
        return ($_.replace("C:\kenaflow", "$pathToKenaflow").replace("c:\kenaflow", "$pathToKenaflow").replace("c:\workflows\plugin","$p\_ready_workflow").replace("c:\source\plugin", "$p"))
    }

    [system.io.file]::WriteAllLines($_.FullName, $r)
}