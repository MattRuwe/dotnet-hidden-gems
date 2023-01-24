using System.Threading.Channels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Async
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine(SynchronizationContext.Current?.GetType().ToString() ?? "Default Syncrhonization Context");
            //MyAsyncMethod().Wait();

            //This does not deadlock because console apps do not have a synchronization context
            //async Task operationOnContext()
            //{
            //    Console.WriteLine("\tWaiting");
            //    await Task.Delay(1000);
            //    Console.WriteLine("\tDone Waiting");
            //}

            //Console.WriteLine("Waiting");
            //operationOnContext().Wait();
            //Console.WriteLine("Done!");








            //ThreadPool.SetMinThreads(1, 1);
            //ThreadPool.SetMaxThreads(10, 10);
            //var tasks = new List<Task>();
            //for (int i = 0; i < 1000; i++)
            //{
            //    tasks.Add(Task.Run(() =>
            //    {
            //            Task.Delay(100);
            //            return Guid.NewGuid();
            //    }));
            //};

            //var pendingWorkItemCount = 0L;
            //do
            //{
            //    ThreadPool.GetAvailableThreads(out int workerThreads, out int completionPortThreads);
            //    pendingWorkItemCount = ThreadPool.PendingWorkItemCount;
            //    Console.SetCursorPosition(0, 0);
            //    Console.WriteLine($"PendingWorkItemCount = {pendingWorkItemCount}");
            //    Console.WriteLine($"workerThreads = {workerThreads}");
            //    Console.WriteLine($"completionPortThreads = {completionPortThreads}");
            //    Thread.Sleep(100);
            //} while (pendingWorkItemCount > 0);






            //Console.WriteLine($"Thread Pool Thread Id = {Thread.CurrentThread.ManagedThreadId}");
            //DemoAsync().Wait();

            //Console.ReadKey();


            //Host.CreateDefaultBuilder(args)
            //    .ConfigureServices(services =>
            //    {
            //        services.AddHostedService<ConsoleAppHost>();
            //        services.AddLogging(builder =>
            //        {
            //            builder.AddConsole();
            //            builder.AddFilter(level => true);
            //        });

            //    })
            //    .ConfigureAppConfiguration((ctx, builder) =>
            //    {
            //        builder.AddCommandLine(args);
            //    })
            //    .Build().Run();


        }

        public static async Task MyAsyncMethod()
        {
            Console.WriteLine("First Part");
            await Task.FromResult(true);

            Console.WriteLine("Second Part");
            await Task.Delay(200);

            Console.WriteLine("Third Part");
            await Task.Yield();

            Console.WriteLine("Fourth Part");
            throw new Exception();
        }
    }
}