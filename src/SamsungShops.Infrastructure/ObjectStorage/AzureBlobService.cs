using Microsoft.WindowsAzure.Storage.Blob;
using SamsungShops.Application.Contracts.ObjectStorage;
using SamsungShops.Application.Models;

namespace SamsungShops.Infrastructure.ObjectStorage
{
    public class AzureBlobService : IAsyncObjectStorageRepository
    {
        private readonly IAzureBlobConnectionFactory _azureBlobConnectionFactory;

        public AzureBlobService(IAzureBlobConnectionFactory azureBlobConnectionFactory)
        {
            _azureBlobConnectionFactory = azureBlobConnectionFactory ?? throw new ArgumentNullException(nameof(azureBlobConnectionFactory));
        }

        public async Task<IEnumerable<Uri>> GetAllAsync()
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();
            var allBlobs = new List<Uri>();
            BlobContinuationToken? blobContinuationToken = null;
            do
            {
                var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
                foreach (IListBlobItem blob in response.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                        allBlobs.Add(blob.Uri);
                }
                blobContinuationToken = response.ContinuationToken;
            }
            while (blobContinuationToken != null);

            return allBlobs;
        }

        public async Task<string> UploadAsync(FileModel fileModel)
        {
            if (fileModel == null || fileModel.Content == null) return string.Empty;

            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();
            var fileName = GetRandomBlobName(fileModel);

            var blob = blobContainer.GetBlockBlobReference(fileName);

            await blob.UploadFromByteArrayAsync(fileModel.Content, 0, fileModel.Content.Length);
            return fileName;
        }

        public async Task<bool> DeleteAsync(string fileName)
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();

            var blob = blobContainer.GetBlockBlobReference(fileName);
            return await blob.DeleteIfExistsAsync();
        }

        public async Task<uint> DeleteAllAsync()
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();
            uint count = 0;
            BlobContinuationToken? blobContinuationToken = null;
            do
            {
                var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
                foreach (IListBlobItem blob in response.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                    {
                        var isDeleted = await ((CloudBlockBlob)blob).DeleteIfExistsAsync();
                        if (isDeleted) count++;
                    }
                }
                blobContinuationToken = response.ContinuationToken;
            } 
            while (blobContinuationToken != null);

            return count;
        }

        /// <summary> 
        /// string GetRandomBlobName(string filename): Generates a unique random file name to be uploaded  
        /// </summary> 
        private static string GetRandomBlobName(FileModel fileModel)
        {
            return string.Format("{0:10}_{1}{2}", DateTime.Now.Ticks, Guid.NewGuid(), fileModel.Extension);
        }
    }
}
