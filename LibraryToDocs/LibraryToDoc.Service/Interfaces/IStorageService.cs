using Microsoft.AspNetCore.Http;

namespace LibraryToDocs.Service.Interfaces
{
    public interface IStorageService
    {
        Task<MemoryStream> DownloadFileAsync(string fileUrl);
        Task<string> UploadFileAsync(IFormFile formFile, string fileNameForStorage);
        Task DeleteFileAsync(string fileUrl);
    }
}
