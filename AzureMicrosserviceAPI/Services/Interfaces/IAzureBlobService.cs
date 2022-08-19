namespace AzureMicrosserviceAPI.Services.Interfaces
{
    public interface IAzureBlobService
    {
        Task<bool> UploadInPrivateContainer();

        Task<bool> UploadInPublicBlobContainer();
    }
}
