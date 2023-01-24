using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Async;

class ConsoleAppHost : IHostedService
{
    private readonly ILogger<ConsoleAppHost> _logger;

    public ConsoleAppHost(ILogger<ConsoleAppHost> logger)
    {
        _logger = logger;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Host process started on thread id: {Thread.CurrentThread.ManagedThreadId}");
        AsyncPump.Run(async delegate { await DemoAsync(); });
        return Task.CompletedTask;

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Host process stopped on thread id: {Thread.CurrentThread.ManagedThreadId}");

        return Task.CompletedTask;
    }

    async Task DemoAsync()
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < 10000; i++)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            int count;
            d[id] = d.TryGetValue(id, out count) ? count + 1 : 1;
            await Task.Yield();
        }
        foreach (var pair in d) Console.WriteLine(pair);

    }
}