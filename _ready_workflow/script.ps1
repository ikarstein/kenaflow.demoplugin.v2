param($wf, $eventData, $config, $plugin, $connection, $item)


# This is the code you need to debug. It does not hurt the workflow during prdoction but can be removed of course. 
if($wf-eq$null){import-module "c:\kenaflow\kenaflow.runtime.dll";Invoke-Kenaflow;exit}


Write-KFLog "Item: $item"

