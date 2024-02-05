using BLL = BLL_Projet_Cinema;
using DAL = DAL_Projet_Cinema;
using Shared_Projet_Cinema.Repositories;

namespace ASP_Projet_Cinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Services BLL
            builder.Services.AddScoped<IMovieRepository<BLL.Entities.Movie>, BLL.Services.MovieService>();
            builder.Services.AddScoped<ICinemaPlaceRepository<BLL.Entities.CinemaPlace>, BLL.Services.CinemaPlaceService>();
            #endregion
            #region Services DAL
            builder.Services.AddScoped<IMovieRepository<DAL.Entities.Movie>, DAL.Services.MovieService>();
            builder.Services.AddScoped<ICinemaPlaceRepository<DAL.Entities.CinemaPlace>, DAL.Services.CinemaPlaceService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}