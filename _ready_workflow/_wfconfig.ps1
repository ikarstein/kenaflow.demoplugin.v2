@{
    Version = "3.0";
    Ignore = $true; 
    Type = "DEMO2";
	SubType = "SUB1";
    Name = "demo-plugin-v2"; 
    Id = "8677F4B4-488E-446E-A5F7-166EFD5FC2FA"; 
    #ScriptFolder = ""; 
    TBE = 60; 
    #Cron = "60 * * * * *"; 
    #CustomLibrary = ""; 
    #ErrorHandlingScript = "errorHandling.ps1"
    #Debug = $false; 
    #NoSerializing = $false;
    #MaxLifetimeOfSerialization = "0:5" #5 minutes
    #StopWorkflowOnScriptError = $true; 
    ConfigListDefaults = @{
        "kenaflow" = "cool"
    }; 
    AlertAddresses = @(); 
    #AlertFloodProtection = 3600; 
    #Script = "script.ps1";
    #MaxExecutionTime = -1;     
    RER = $false; 
    #MaximumRerLifetime = 120;
    #PostponeFailedRer = 5;

    #writeMailsToDiskDuringDebug = $true;
    #alwaysWriteMailsToDiskInsteadSending = $false; 
    #redirectAllMails = @(); 
    #SendOutputToMainProcess = $false;
    #DumpRerEventDataToLog = $false
    #SaveRerEventsAfterProcessing = $false
	
	CustomData = @{
		Plugin = @{
			"Name" = "Demo Plugin V2";
		};
	}
}

if(!$kenaflow){import-module "c:\kenaflow\kenaflow.runtime.dll";Test-KFConfig;exit}
