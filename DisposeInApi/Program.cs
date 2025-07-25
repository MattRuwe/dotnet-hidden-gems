using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<DatabaseInitializerHost>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogContext>(options =>
{
    options.UseSqlite("Data Source=data.db");
}, ServiceLifetime.Scoped);

var app = builder.Build();

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
        // This is the proper way to handle a service resolved from the service provider.
        var context = serviceProvider.GetRequiredService<BlogContext>();
        posts = context.Posts.ToList();
        blogs = context.Blogs.ToList();


        // The following will raise an exception because the DbContext is disposed after the request is completed.
        //using (var context = serviceProvider.GetRequiredService<BlogContext>())
        //{
        //    posts = context.Posts.ToList();
        //}

        //using (var context = serviceProvider.GetRequiredService<BlogContext>())
        //{
        //    blogs = context.Blogs.ToList();
        //}


        return new { Posts = posts, Blogs = blogs };
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

    public override ValueTask DisposeAsync()
    {
        return base.DisposeAsync(); 
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

        base.OnModelCreating(modelBuilder);
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

class DatabaseInitializerHost(IServiceProvider serviceProvider, ILogger<DatabaseInitializerHost> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogDebug("Migrating database if needed.");
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
        var connectionString = dbContext.Database.GetConnectionString();
        await dbContext.Database.EnsureCreatedAsync(cancellationToken);
        await dbContext.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}