using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogContext>(options =>
{
    using var scope = builder.Services.BuildServiceProvider().CreateScope();
    var hostingEnvironment = scope.ServiceProvider.GetService<IWebHostEnvironment>();
    var connectionString = $"Data Source={hostingEnvironment?.ContentRootPath}data.db";
    options.UseSqlite(connectionString);
});

var app = builder.Build();
using (var scopedProvider = app.Services.CreateScope())
{
    scopedProvider.ServiceProvider.GetRequiredService<BlogContext>().Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/blogposts", (IServiceProvider serviceProvider) =>
    {
        IEnumerable<Post> posts;
        IEnumerable<Blog> blogs;
        using (var context = serviceProvider.GetRequiredService<BlogContext>())
        {
            posts = context.Posts.ToList();
        }

        using (var context = serviceProvider.GetRequiredService<BlogContext>())
        {
            blogs = context.Blogs.ToList();
        }


        return (blogs = blogs, posts = posts);
    })
.WithName("blogposts");

app.Run();

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {

    }

    public override void Dispose()
    {
        base.Dispose();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasData(new Blog[]
            {
                new Blog() {Id = 1, Name = "Blog 1", Url = "http://blog1.com"},
                new Blog() {Id = 2, Name = "Blog 2", Url = "http://blog2.com"},
            });
        modelBuilder.Entity<Post>()
            .HasData(new Post[]
            {
                new Post {Id = 1, Title = "First Post", Content = "First Post Content", BlogId = 1},
                new Post {Id = 2, Title = "Second Post", Content = "Second Post Content", BlogId = 2},
                new Post {Id = 3, Title = "Third Post", Content = "Third Post Content", BlogId = 1},
            });
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Blog> Blogs { get; set; }
}

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}