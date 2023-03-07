using Microsoft.WindowsAzure.Storage.Blob;

namespace SamsungShops.Infrastructure.ObjectStorage
{
    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetBlobContainer();
    }
}
