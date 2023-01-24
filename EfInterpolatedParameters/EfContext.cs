using Microsoft.EntityFrameworkCore;

namespace EfInterpolatedParameters
{
    internal class BlogContext : DbContext // DbContext is a class in the Microsoft.EntityFrameworkCore namespace
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blog.db");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog { BlogId = 1, Url = "http://sample.com" },
                new Blog { BlogId = 2, Url = "http://sample2.com" }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post { PostId = 1, BlogId = 1, Title = "First post", Content = "First post content" },
                new Post { PostId = 2, BlogId = 1, Title = "Second post", Content = "Second post content" },
                new Post { PostId = 3, BlogId = 2, Title = "First post", Content = "First post content" },
                new Post { PostId = 4, BlogId = 2, Title = "Second post", Content = "Second post content" }
            );
        }
    }

    internal class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }

    internal class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

}
