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

            //building application
            var app = builder.Build();

            //add mapping
            app.MapControllers();

            app.MapGet("/", () =>
            {
                return Results.Redirect("/api/books");
            });

            app.Run();
        }
    }
}
