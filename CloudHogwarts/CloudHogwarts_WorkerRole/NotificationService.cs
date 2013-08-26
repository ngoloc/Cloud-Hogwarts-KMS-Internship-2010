using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace CloudHogwarts_WorkerRole
{
    public class Message : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    {
        public Message()
        {
            PartitionKey = "a";
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }
        public int AnnouncementID { get; set; }
        public int StaffID { get; set; }
        public int StudentID { get; set; }
        public string Title { get; set; }
        public bool IsNotification { get; set; }
        public bool IsViewed { get; set; }
    }

    public class StaffMessage : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    {
        public StaffMessage()
        {
            PartitionKey = "a";
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }

        public int StudentID { get; set; }
        public int StaffID { get; set; }
        public string text { get; set; }
        public bool IsViewed { get; set; }
    }

    public class MessageDataServiceContext : TableServiceContext
    {
        public IQueryable<Message> Messages
        {
            get
            {
                return this.CreateQuery<Message>("Messages");
            }
        }
        public MessageDataServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public void AddMessage(int StaffID, int StudentID, string Title, int AnnouncementID, bool IsNotification, bool IsViewed)
        {
            this.AddObject("Messages", new Message { StaffID = StaffID, StudentID = StudentID, Title = Title, AnnouncementID = AnnouncementID, IsNotification = IsNotification, IsViewed = IsViewed });
            this.SaveChanges();
        }
    }

    public class StaffMessageDataServiceContext : TableServiceContext
    {
        public IQueryable<StaffMessage> StaffMessages
        {
            get
            {
                return this.CreateQuery<StaffMessage>("StaffMessages");
            }
        }

        public StaffMessageDataServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public void AddStaffMessage(int StudentID, int StaffID, string text, bool IsViewed)
        {
            this.AddObject("StaffMessages", new StaffMessage { StudentID = StudentID, StaffID = StaffID, text = text, IsViewed = IsViewed });
            this.SaveChanges();
        }
    }

    [ServiceContract(Namespace = "Hogwarts:NotificationServiceContract")]
    public interface INotificationService
    {
        [OperationContract]
        List<Message> getRelatingMessages(int StudentID);
        [OperationContract]
        List<StaffMessage> getStaffRelatingMessages(int StaffID);
    }

    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    class NotificationService:INotificationService
    {
        public List<Message> getRelatingMessages(int StudentID)
        {
            var account = CloudStorageAccount.FromConfigurationSetting("TableDataConnectionString");

            var context = new MessageDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

            var messages = from m in context.Messages
                           where m.StudentID == StudentID
                           select m;
            try
            {
                return messages.ToList<Message>();
            }
            catch (Exception) { return null; }
        }

        public List<StaffMessage> getStaffRelatingMessages(int StaffID)
        {
            var account = CloudStorageAccount.FromConfigurationSetting("TableDataConnectionString");

            var context = new StaffMessageDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

            var StaffMessages = from m in context.StaffMessages
                                where m.StaffID == StaffID
                                select m;
            try
            {
                return StaffMessages.ToList<StaffMessage>();
            }
            catch (Exception) { return null; }
        }
    }
}
