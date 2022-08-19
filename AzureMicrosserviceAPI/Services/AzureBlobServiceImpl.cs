using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureMicrosserviceAPI.Services.Interfaces;
using System.Threading;

namespace AzureMicrosserviceAPI.Services
{
    public class AzureBlobServiceImpl : IAzureBlobService
    {
        public async Task<bool> UploadInPrivateContainer()
        {
            var blobStorageConnectionString = "myconnectionstring";
            var blobStorageContainer = "fileupload";

            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainer);

            await container.CreateIfNotExistsAsync();

            string localPath = "./Data/";
            string fileName = "test.png";
            string localFilePath = Path.Combine(localPath, fileName);

            BlobClient blobClient = container.GetBlobClient(fileName);
            blobClient.Upload(localFilePath, true);

            return true;
        }

        public async Task<bool> UploadInPublicBlobContainer()
        {
            var blobStorageConnectionString = "myconnectionstring";
            var blobStorageContainer = "publicupload";

            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainer);

            await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

            string localPath = "./Data/";
            string fileName = "test.png";
            string localFilePath = Path.Combine(localPath, fileName);

            BlobClient blobClient = container.GetBlobClient(fileName);
            blobClient.Upload(localFilePath, new BlobHttpHeaders { ContentType = "image/jpg" });

            return true;
        }
    }
}
