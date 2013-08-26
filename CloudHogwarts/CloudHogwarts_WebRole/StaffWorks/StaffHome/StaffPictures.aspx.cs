using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.WindowsAzure.Diagnostics;
using CloudHogwarts_WebRole;

namespace CloudHogwarts_WebRole.StaffWorks.StaffHome
{
    public partial class StaffPictures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            string username = Context.User.Identity.Name;
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            var staff = (from s in db.Staffs
                         where s.UserName == username
                         select s).First();
            ViewState["title"] = staff.FirstName + " " + staff.LastName;
            try
            {
                if (!IsPostBack)
                {
                    this.EnsureContainerExists();
                }
                this.RefreshGallery();
            }
            catch (System.Net.WebException we)
            {
                status.Text = "Network error: " + we.Message;
                if (we.Status == System.Net.WebExceptionStatus.ConnectFailure)
                {
                    status.Text += "<br />Please check if the blob storage service is running at " +
                                   ConfigurationManager.AppSettings["storageEndpoint"];
                }
            }
            catch (StorageException se)
            {
                Console.WriteLine("Storage service error: " + se.Message);
            }
        }

        private CloudBlobContainer GetContainer()
        {
            // Get a handle on account, create a blob storage client and get container proxy
            var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            var client = account.CreateCloudBlobClient();

            return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName"));
        }

        private void EnsureContainerExists()
        {
            var container = GetContainer();
            container.CreateIfNotExist();

            var permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);
        }

        private void RefreshGallery()
        {
            var gallery = (from img in this.GetContainer().ListBlobs(new BlobRequestOptions()
                                {
                                    UseFlatBlobListing = true,
                                    BlobListingDetails = BlobListingDetails.All
                                })
                           where ((CloudBlob)img).Metadata["Username"] == Context.User.Identity.Name
                     select img);
            images.DataSource = gallery;
            images.DataBind();
        }

        private void SaveImage(string id, string name, string description, string fileName, string contentType, byte[] data)
        {

            // Create a blob in container and upload image bytes to it
            var blob = this.GetContainer().GetBlobReference(name);

            blob.Properties.ContentType = contentType;

            // Create some metadata for this image
            var metadata = new NameValueCollection();
            metadata["Id"] = id;
            metadata["Filename"] = fileName;
            metadata["ImageName"] = String.IsNullOrEmpty(name) ? "unknown" : name;
            metadata["Description"] = String.IsNullOrEmpty(description) ? "unknown" : description;
            metadata["Uri"] = blob.Uri.ToString();
            metadata["Username"] = Context.User.Identity.Name;
            // Add and commit metadata to blob
            blob.Metadata.Add(metadata);
            blob.UploadByteArray(data);
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if (imageFile.HasFile)
            {
                status.Text = "Inserted [" + imageFile.FileName + "] - Content Type [" + imageFile.PostedFile.ContentType + "] - Length [" + imageFile.PostedFile.ContentLength + "]";

                this.SaveImage(
                    Guid.NewGuid().ToString(),
                    imageName.Text,
                    imageDescription.Text,
                    imageFile.FileName,
                    imageFile.PostedFile.ContentType,
                    imageFile.FileBytes
                    );

                RefreshGallery();
            }
            else
                status.Text = "No image file";
            imageName.Text = "";
            imageDescription.Text = "";
        }

        protected void OnBlobDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var metadataRepeater = e.Item.FindControl("blobMetadata") as Repeater;
                var blob = ((ListViewDataItem)(e.Item)).DataItem as CloudBlob;

                if (blob != null)
                {
                    if (metadataRepeater != null)
                    {
                        //bind to metadata
                        metadataRepeater.DataSource = from key in blob.Metadata.AllKeys
                                                      select new
                                                      {
                                                          Name = key,
                                                          Value = blob.Metadata[key]
                                                      };
                        metadataRepeater.DataBind();
                    }
                }
            }
        }

        protected void OnDeleteImage(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    
                    var blobUri = (string)e.CommandArgument;

                    var blob = this.GetContainer().GetBlobReference(blobUri);
                    status.Text = "Deleted [" + blobUri + "]";

                    blob.DeleteIfExists();

                    RefreshGallery();
                }
            }
            catch (StorageClientException se)
            {
                status.Text = "Storage client error: " + se.Message;
            }
            catch (Exception) { }
            imageName.Text = "";
            imageDescription.Text = "";
        }
    }
}