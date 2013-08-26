using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Microsoft.WindowsAzure;
using System.Data.Services.Client;
using CloudHogwarts_WorkerRole;

namespace CloudHogwarts_WebRole.Classes
{
    public static class TableDataContract
    {
        public static INotificationService getINotificationService()
        {
            NetTcpBinding myBinding = new NetTcpBinding(SecurityMode.None);
            //portlandhogwarts.cloudapp.net:3030/NotificationService
            EndpointAddress myEndpoint = new EndpointAddress("net.tcp://portlandhogwarts.cloudapp.net:3030/NotificationService");
            //EndpointAddress myEndpoint = new EndpointAddress("net.tcp://127.0.0.1:3030/NotificationService");
            ChannelFactory<INotificationService> myChannelFactory = new ChannelFactory<INotificationService>(myBinding, myEndpoint);
            return myChannelFactory.CreateChannel();
        }

        public static void AddNotice(int StaffID, int StudentID, string Title, int AnnouncementID,bool IsNotification, bool IsViewed)
        {
            var statusMessage = String.Empty;
            try
            {
                var account = CloudStorageAccount.FromConfigurationSetting("TableDataConnectionString");

                var context = new MessageDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

                context.AddMessage(StaffID, StudentID, Title, AnnouncementID, IsNotification, IsViewed);
            }
            catch (DataServiceRequestException ex)
            {
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                 + ex.Message;
            }
        }

        public static void AddStudentRequest(int StudentID, int StaffID, bool IsViewed)
        {
            var statusMessage = String.Empty;
            try
            {
                var account = CloudStorageAccount.FromConfigurationSetting("TableDataConnectionString");

                var context = new StaffMessageDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

                string text = Classes.HogwartsDataAccess.GetStudentName(StudentID) + " has made a request to change his/her profile";
                context.AddStaffMessage(StudentID, StaffID, text, IsViewed);
            }
            catch (DataServiceRequestException ex)
            {
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                 + ex.Message;
            }
        }

        public static void DeleteArticle(int AnnouncementID)
        {
            var statusMessage = String.Empty;
            try
            {
                var account = CloudStorageAccount.FromConfigurationSetting("TableDataConnectionString");
                
                var context = new MessageDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);
                while (true)
                {
                    var o = (from message in context.Messages
                             where message.IsNotification == false && message.AnnouncementID == AnnouncementID
                             select message).FirstOrDefault();
                    if (o == null) return;
                    context.DeleteObject(o);
                    context.SaveChanges();
                }
            }
            catch (DataServiceRequestException ex)
            {
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                 + ex.Message;
            }
        }

        public static void ChangeViewedStatus(string key)
        {
            var statusMessage = String.Empty;
            try
            {
                var account = CloudStorageAccount.FromConfigurationSetting("TableDataConnectionString");

                var context = new MessageDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

                var o = (from message in context.Messages
                         where message.RowKey == key
                         select message).First();
                o.IsViewed = true;
                context.UpdateObject(o);
                context.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                 + ex.Message;
            }
        }
        public static void ChangeStaffViewedStatus(string key)
        {
            var statusMessage = String.Empty;
            try
            {
                var account = CloudStorageAccount.FromConfigurationSetting("TableDataConnectionString");

                var context = new StaffMessageDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

                var o = (from message in context.StaffMessages
                         where message.RowKey == key
                         select message).First();

                o.IsViewed = true;
                context.UpdateObject(o);
                context.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                 + ex.Message;
            }
        }
    }
}