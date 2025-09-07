namespace BookApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // creating builder
            var builder = WebApplication.CreateBuilder(args);

            // add services(controllers)
            builder.Services.AddControllers();

            //add CORS Cross Origin Resource Sharing
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            //building application
            var app = builder.Build();

            app.UseCors("MyCors");

            //add mapping
            app.MapControllers();

            app.MapGet("/", () =>
            {
                return Results.Redirect("/api/books");
            });

            //Running Application
            app.Run();
        }
    }
}
