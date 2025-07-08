namespace StringInterpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Stuff
            // https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/FormattableString.cs
            var firstName = "Matt";
            var lastName = "Ruwe";
            string regularString = $"Hello, {firstName} {lastName}!";
            FormattableString fString = $"Hello, {firstName} {lastName}!";
            
            Console.WriteLine(fString.Format);
            var i = 0;
            foreach (var argument in fString.GetArguments())
            {
                Console.WriteLine($"  Argument {++i}: {argument}");
            }

            Console.WriteLine("----");
            Console.WriteLine(fString);
            Console.WriteLine(regularString);
            #endregion
        }
    }
}