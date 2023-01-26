namespace StringInterpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstName = "Matt";
            var lastName = "Ruwe";
            FormattableString fString = $"Hello, {firstName} {lastName}!";

            Console.WriteLine(fString.Format);
            var i = 0;
            foreach (var argument in fString.GetArguments())
            {
                Console.WriteLine($"  Argument {++i}: {argument}");
            }

            Console.WriteLine("----");
            Console.WriteLine(fString);
        }
    }
}