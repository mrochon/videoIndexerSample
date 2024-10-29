using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VISample.Services;

namespace VISample;

internal class Main : IHostedService
{
    private readonly ILogger<Main> _logger;
    private readonly VideoClient _videoIndexer;

    public Main(
        ILogger<Main> logger,
        VideoClient videoIndexer
        )
    {
        _logger = logger;
        _videoIndexer = videoIndexer;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogTrace("Main Started");
        //await _videoIndexer.FileUploadAsync("myVideo", "./Data/waiting in line.mp4");
        await _videoIndexer.ListVideosAsync();
        _logger.LogTrace("done");
        await StopAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stopped");
        return Task.CompletedTask;
    }
}