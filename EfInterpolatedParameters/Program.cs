using Microsoft.EntityFrameworkCore;

namespace EfInterpolatedParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Stuff

            // Things to show:
            // Developer command line - ILDASM - Show the IL for the interpolated string
            // Show how to use Sqlite with entity framework
            // Show Log to in entity framework
            var context = new BlogContext();
            context.Database.EnsureCreated();

            UsingNormalFromSqlInterpolated(context);

            UsingFormattableString(context);

            #endregion
        }

        private static void UsingNormalFromSqlInterpolated(BlogContext context)
        {
            // More expressive query using a FormattableString
            var blogId = 1;
            var posts = context.Posts.FromSqlInterpolated($"SELECT * FROM Posts WHERE BlogId = {blogId}").ToList();
        }

        private static void UsingFormattableString(BlogContext context)
        {
            // More expressive query using a FormattableString
            var blogId = 1;
            FormattableString query = $"SELECT * FROM Posts WHERE BlogId = {blogId}";
            var previousConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Format:        {query.Format}");
            Console.WriteLine($"Query Value 0: {query.GetArgument(0)}");
            Console.ForegroundColor = previousConsoleColor;
            var posts = context.Posts.FromSqlInterpolated(query).ToList();
        }
    }
}