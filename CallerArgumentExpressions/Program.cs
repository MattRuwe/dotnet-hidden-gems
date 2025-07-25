using System.Runtime.CompilerServices;

namespace CallerArgumentExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hello("Nebraska Code");
            string? myString = null;

            NotNullBoring(myString, nameof(myString));
            NotNullAwesome(myString);

        }

        static void Hello(string name,
            [CallerMemberName()] string? memberName = null,
            [CallerArgumentExpression(nameof(name))] string? argumentExpression = null,
            [CallerFilePath()] string? filePath = null,
            [CallerLineNumber()] int? lineNumber = 0)
        {
            Console.WriteLine("Caller Information:");
            Console.WriteLine($"  Member Name:         {memberName}");
            Console.WriteLine($"  Argument Expression: {argumentExpression}");
            Console.WriteLine($"  File Path:           {filePath}");
            Console.WriteLine($"  Line Number:         {lineNumber}");
            Console.WriteLine($"");
            
            Console.WriteLine($"Hello, {name}");
        }

        public static void NotNullBoring<T>(T argument, string argumentName)
            where T : class?
        {
            if (argument == null)
            {
                Console.WriteLine($"Boring: Argument {argumentName} cannot be null");
                //throw new ArgumentNullException(paramName: parameterName);
            }
        }

        public static void NotNullAwesome<T>(T argument, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null)
            where T : class?
        {
            if (argument == null)
            {
                Console.WriteLine($"Awesome: Argument {argumentExpression} cannot be null");
                //throw new ArgumentNullException(paramName: argumentExpression);
            }
        }

        public static void TheRightWayToThrowArgumentNullException<T>(T argument)
            where T : class?
        {
            ArgumentNullException.ThrowIfNull(argument);
        }
}
