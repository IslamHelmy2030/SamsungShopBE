
using SamsungShops.Application.Models;

namespace SamsungShops.Application.Contracts.ObjectStorage
{
    public interface IAsyncObjectStorageRepository
    {
        Task<IEnumerable<Uri>> GetAllAsync();
        Task<string> UploadAsync(FileModel fileModel);
        Task<bool> DeleteAsync(string fileName);
        Task<uint> DeleteAllAsync();
    }
}
