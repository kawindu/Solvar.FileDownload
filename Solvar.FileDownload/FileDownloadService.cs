using System;
using System.Net;

namespace Solvar.FileDownload
{
    public class FileDownloadService : IFileDownloadService
    {
        public async Task DownloadFileAsync(string url, HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to download file from {url}. Status code: {response.StatusCode}");
            }

            string fileName = Path.GetFileName(url);
            string projectLocation = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectLocation, fileName);

            using FileStream fileStream = File.Create(filePath);
            await response.Content.CopyToAsync(fileStream);

            Console.WriteLine($"Downloaded {fileName} successfully.");

        }
    }
}

