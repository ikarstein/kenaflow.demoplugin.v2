/* part of kenaflow (https://kenaflow.com) */
/* Copyright by kenaro GmbH (https://www.kenaro.com) */
/* Written by Ingo Karstein */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace kenaflow.demoplugin.v2
{
    public class DemoPluginV2 : KenaflowPluginV2
    {
        private readonly KenaflowPluginConfigurationV2 MyConfig = new KenaflowPluginConfigurationV2
        {
            Id = Guid.Parse("{BC3E435B-ADD6-4764-B415-3D887403222C}"),
            Enabled = true,
            Name = "Demo Plugin v2",
            Version = new Version("1.0.0.0"),
            MinKenaflowVersion = new Version("3.0.12.0"),
            MaxKenaflowVersion = new Version("3.0.9999.0"),
            PSModule = true,
            CustomWorkflowType = "DEMO2::SUB1",
            LogDebug = true,
            SupportedWorkflowTypes = new List<string> { "DEMO2::SUB1" }
        };

        private string SomePrivateData { get; set; }

        /* BEGIN Accessible from PowerShell */
        public KenaflowPluginConfigurationV2 GetPluginConfig()
        {
            return MyConfig;
        }

        public WFConfig GetCurrentWorkflowConfig()
        {
            return WorkflowConfig;
        }

        /* END Accessible from PowerShell */

        protected override KenaflowPluginConfigurationV2 GetPluginConfig(Options options)
        {
            //Return the Plugin Configuriation to kenaflow.
            LogNormal("Loading config of DemoPlugin v1");
            return MyConfig;
        }

        protected override void Loaded()
        {
            //Can be used to initialize the plugin after it was loaded and successfully registered.
        }

        protected override string CheckConfig(WFConfig config)
        {
            //Can be used to check the loaded workflow config (_wfconfig.ps1)
            //To return an error just return a string. On success return NULL.
            return null;
        }

        protected override void Init(WFConfig config)
        {
            //Can be used to initialize the current workflow run.
        }

        protected override object Connect()
        {
            //Connect to your system. Return a handle to the connection. Whatever you want.
            return null;
        }

        protected override string GetLastProcessedItemId(object li)
        {
            //A workflow has a maximum execution time.BEFORE each item processing the elapsed time of the current workflow run is checked.If the time exceeded the limit the workflow execution is stopped.Therefore a hint to the next item is stored in the `_wfdata` folder.
            //The get the hint this method is called.The hint is returned as string. On the next workflow run its passed to the method `GetItems`.

            return li as string;
        }

        protected override void PreProcessEventData(ref Hashtable hashtableEventData)
        {
            //In case of remote events this is method can be used to modify the remote data BEFORE initiating the workflow.
        }

        protected override void PreProcessWorkflowConfigValues1(ref Dictionary<string, object> currentWorkflowConfigValues)
        {
            //after config values are read from _wfconfig.ps1
        }

        protected override void PreProcessWorkflowConfigValues2(ref Dictionary<string, object> currentWorkflowConfigValues)
        {
            //after config values are modified by engine BEFORE execution
        }

        protected override bool CheckLastRun(ref DateTime lastRun, ref string errorMessage, ref string errorCode)
        {
            return false; // FALSE => do not execute workflow.
        }

        protected override bool CheckTBEandCRON(ref DateTime dt, bool checkResult)
        {
            return checkResult; // FALSE => do not execute workflow. Next runtime can be set in 'dt';
        }

        protected override List<object> GetItems(Hashtable eventData, string lastProcessedItem)
        {
            //Get list of items for processing by workflow script.
            return new List<object> { 1, 2, 3, 4, 5 };
        }

        protected override void PreItemProcessing(ref object li)
        {
            SerializeStorageData(true, Guid.Parse(WorkflowConfig.Id), $"key_{li}", new { a = "a", b = "b" }, false, "");
        }

        protected override void PostItemProcessing(ref object li)
        {
            var d = DeserializeStorageData(true, Guid.Parse(WorkflowConfig.Id), $"key_{li}", "");
            RemoveStorageData(true, Guid.Parse(WorkflowConfig.Id), $"key_{li}");
        }

        protected override void CleanupAfterItem()
        {
            //Called after the workflow has processed all items. (Also in case of failure.)
        }

        protected override void CleanupAfterRun()
        {
            //Called after the workflow has processed all items.
        }

        protected override void ItemRemoval(object li, int removalState)
        {
            //Called at the end of the item processing. 
            // 0 = no removal requested
            // 1 = removal requested
            // 2 = move to recycle bin requested
            base.ItemRemoval(li, removalState);
        }

        protected override void Disconnect(object connection)
        {
            //Disconnect from your system. You get to handle that was returned by 'Connect'.
            //Only called at the end of the workflow run if "Connect" returns a value != null.
        }

        /**** TOOLS ****/

        protected override object GetData(string key, object item)
        {
            //can be used to read persisted data. 'item' can be null, e.g. if using Set-KFData
            return null;
        }

        protected override void SetData(string key, object item, object data)
        {
            //can be used to persist data. 'item' can be null, e.g. if using Set-KFData
        }

        protected override void RemoveData(string key, object item)
        {
            //can be used to remove persisted data. 'item' can be null, e.g. if using Set-KFData
        }

        protected override bool HandleException(Exception exception)
        {
            return true; // => throw exception in engine. FALSE => don't throw
        }

        protected override void RegisterReceiver(string url)
        {
            //Can be used to register web hooks.
        }

        protected override void UnregisterReceiver(string url)
        {
            //Can be used to un-register web hooks.
        }
    }

    [Cmdlet("Get", "PluginTestV2")]
    public class Test : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject($"Test: {DateTime.Now}");
        }
    }
}
