using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using System.ServiceModel;

namespace CloudHogwarts_WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        /// <summary>ServiceHost object for internal and external endpoints.</summary>
        private ServiceHost serviceHost;

        private void StartWCFService(int retries)
        {
            // recycle the role if host cannot be started 
            // after the specified number of retries
            if (retries == 0)
            {
                RoleEnvironment.RequestRecycle();
                return;
            }

            Trace.TraceInformation("Starting notification service host...");

            this.serviceHost = new ServiceHost(typeof(NotificationService));

            // Recover the service in case of failure. 
            // Log the fault and attempt to restart the service host. 
            this.serviceHost.Faulted += (sender, e) =>
            {
                Trace.TraceError("Host fault occured. Aborting and restarting the host. Retry count: {0}", retries);
                this.serviceHost.Abort();
                this.StartWCFService(--retries);
            };

            // use NetTcpBinding with no security
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);

            // define an external endpoint for client traffic
            RoleInstanceEndpoint externalEndPoint =
                RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["NotificationService"];

            this.serviceHost.AddServiceEndpoint(
                            typeof(INotificationService),
                            binding,
                            String.Format("net.tcp://{0}/NotificationService", externalEndPoint.IPEndpoint));

            try
            {
                this.serviceHost.Open();
                Trace.TraceInformation("Chat service host started successfully.");
            }
            catch (TimeoutException timeoutException)
            {
                Trace.TraceError("The service operation timed out. {0}", timeoutException.Message);
            }
            catch (CommunicationException communicationException)
            {
                Trace.TraceError("Could not start chat service host. {0}", communicationException.Message);
            }
        }
        
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("CloudHogwarts_WorkerRole entry point called", "Information");
            StartWCFService(3);
            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
            });

            return base.OnStart();
        }
    }
}
