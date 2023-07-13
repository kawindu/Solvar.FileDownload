using System;

namespace Solvar.FileDownload
{
    public class EntryPointService
    {
        private readonly IFileDownloadService _fileDownloadService;

        public EntryPointService(IFileDownloadService fileDownloadService)
        {
            _fileDownloadService = fileDownloadService;
        }

        public async Task StartAsync(string[] fileUrls)
        {
            foreach (string url in fileUrls)
            {
                try
                {
                    using HttpClient client = new();
                    await _fileDownloadService.DownloadFileAsync(url, client);
                    Console.WriteLine($"Downloaded file from {url}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to download file from {url}. Error: {ex.Message}");
                }
            }
        }
    }
}

