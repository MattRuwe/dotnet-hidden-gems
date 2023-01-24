using Microsoft.EntityFrameworkCore;

namespace EfInterpolatedParameters
{
    internal class Program
    {
        // Things to show:
        // Developer command line - ILDASM - Show the IL for the interpolated string
        // Show how to use Sqlite with entity framework
        // Show Logto in entity framework

        static void Main(string[] args)
        {
            var context = new BlogContext();
            
            var blogId = 1;
            FormattableString query = $"SELECT * FROM Posts WHERE BlogId = {blogId}";
            Console.WriteLine(query.Format);
            Console.WriteLine(query.GetArgument(0));
            var posts = context.Posts.FromSqlInterpolated(query).ToList();
        }
    }
}