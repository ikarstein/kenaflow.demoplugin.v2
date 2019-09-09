param($wf, $config, $exception, $item, $eventData)

if($null-eq$wf){write-error "You need to run a workflow script and force an error.";exit;}


#Return one of these values:
#  0 or "ThrowException" or [KenaflowErrorHandlingResults]::ThrowException
#  1 or "Okay" or [KenaflowErrorHandlingResults]::Okay
#  2 or "StopItemWithSuccess" or [KenaflowErrorHandlingResults]::StopItemWithSuccess
#  6 or "StopWorkflowWithSuccess" or [KenaflowErrorHandlingResults]::StopWorkflowWithSuccess
#  7 or "StopItemWithFailure" or [KenaflowErrorHandlingResults]::StopItemWithFailure
# 11 or "StopWorkflowWithFailure" or [KenaflowErrorHandlingResults]::StopWorkflowWithFailure
#
# "ThrowException" is default in case nothing is send back
#
# "Okay" indicated that the error handling script has handled the exception and the engine must not take care.
#
# You cannot send other data back to _kenaflow_!

return "Okay"