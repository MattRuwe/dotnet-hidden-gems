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
            //var context = new BlogContext();
            //context.Database.EnsureCreated();

            //var blogId = 1;
            //FormattableString query = $"SELECT * FROM Posts WHERE BlogId = {blogId}";
            //Console.WriteLine(query.Format);
            //Console.WriteLine(query.GetArgument(0));
            //var posts = context.Posts.FromSqlInterpolated(query).ToList();
            #endregion
        }
    }
}