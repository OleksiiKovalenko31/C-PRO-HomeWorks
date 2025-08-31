using HomeWork_26_WebAPI_Middleware_RESTAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace HomeWork_26_WebAPI_Middleware_RESTAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Додаємо сервіс Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();
           
                // Вмикаємо Swagger
                app.UseSwagger();
                app.UseSwaggerUI();
           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
     

            app.Run();
        }
    }
}
