using Microsoft.Extensions.DependencyInjection;
using Solvar.FileDownload;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileDownloadService, FileDownloadService>()
                .AddTransient<EntryPointService>()
                .BuildServiceProvider();

        var entryPoint = serviceProvider.GetRequiredService<EntryPointService>();

        Console.WriteLine("Enter the URLs (separated by commas):");
        var fileUrlsInput = Console.ReadLine();
        var fileUrls = fileUrlsInput?.Split(',');

        await entryPoint.StartAsync(fileUrls);
    }
}