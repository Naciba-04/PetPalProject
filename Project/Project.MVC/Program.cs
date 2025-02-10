using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Project.BL.Services.Implementation;
using Project.DAL.Contexts;
using Project.BL.Profiles;
using Project.BL.DTOs.ProductDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using Project.DAL.Repository.Implementation;
using Microsoft.AspNetCore.Identity;
using Project.BL.EmailServices.Abstraction;
using Project.BL.EmailServices.Implementation;

namespace Project.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<PetPatFinalProjectDbContext>();

            builder.Services.AddDbContext<PetPatFinalProjectDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
            builder.Services.AddScoped<IGenericRepository<Department>, GenericRepository<Department>>();
            builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            builder.Services.AddScoped<IGenericRepository<Rating>, GenericRepository<Rating>>();
            builder.Services.AddScoped<IGenericRepository<PetType>, GenericRepository<PetType>>();
            builder.Services.AddScoped<IGenericRepository<PetService>, GenericRepository<PetService>>();
            builder.Services.AddScoped<IGenericRepository<Reservation>, GenericRepository<Reservation>>();
            builder.Services.AddScoped<IGenericRepository<Animal>, GenericRepository<Animal>>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IRatingService, RatingService>();
            builder.Services.AddScoped<IPetTypeService, PetTypeService>();
            builder.Services.AddScoped<IPetServiceService, PetServiceService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IAnimalService, AnimalService>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidation>();

            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddAuthentication()
        .AddCookie(options =>
        {
            options.AccessDeniedPath = "/Account/AccessDenied/";
        });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "areas",
            pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
