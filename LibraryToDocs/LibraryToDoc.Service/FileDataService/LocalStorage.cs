using LibraryToDocs.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LibraryToDocs.Service.FileDataService
{
    public class LocalStorage : IStorageService
    {
        private readonly string appFolder;
        private readonly string bucketName;
        public LocalStorage(IConfiguration configuration)
        {
            var _config = configuration.GetSection("Core").GetSection("FileDataSettings");
            appFolder = Directory.GetCurrentDirectory();
            bucketName = _config.Value = "StorageBucket";
        }

        public async Task<MemoryStream> DownloadFileAsync(string fileUrl)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(Path.Combine(appFolder, fileUrl));
                return await Task.FromResult(new MemoryStream(fileBytes));
            }
            catch { throw; }
        }

        public async Task<string> UploadFileAsync(IFormFile formFile, string fileNameForStorage)
        {
            try
            {
                if (!Directory.Exists(Path.Combine(appFolder, bucketName)))
                    Directory.CreateDirectory(Path.Combine(appFolder, bucketName));

                var fullPath = Path.Combine(appFolder, bucketName, fileNameForStorage);
                using FileStream stream = new(fullPath, FileMode.Create);
                await formFile.CopyToAsync(stream);
                return Path.Combine(bucketName, fileNameForStorage);
            }
            catch { throw; }
        }
        public async Task DeleteFileAsync(string fileUrl)
        {
            try
            {
                await Task.Run(() => File.Delete(Path.Combine(appFolder, fileUrl)));
            }
            catch { throw; }
        }
    }
}
