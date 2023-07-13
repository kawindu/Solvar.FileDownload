using System;

namespace Solvar.FileDownload
{
	public interface IFileDownloadService
	{
        /// <summary>
        /// Download the file from url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        Task DownloadFileAsync(string url, HttpClient client);
    }
}

