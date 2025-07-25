namespace SimpleConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var myAsyncClass = new MyAsyncClass();
            await myAsyncClass.MyAsyncMethod();
        }
    }

    class MyAsyncClass
    {
        public async Task MyAsyncMethod()
        {
            Console.WriteLine("Hello, World!");
            await Task.Delay(1000);
            Console.WriteLine("Async method completed.");
        }
    }
}
