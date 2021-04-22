using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TPAParkingLotAPI.Services;
using TPAParkingLotAPI.DbContexts;

namespace TPAParkingLotAPI
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				var contact = new Microsoft.OpenApi.Models.OpenApiContact()
				{
					Email = "thomas.carney@computershare.com",
					Name = "Platform Engineering",
					Url = new Uri("https://dev.americas.computershare.com")
				};
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "TPAParkingLotAPI", Version = "v1", Description = "TPA Parking Lot API", Contact = contact });

				var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
				c.IncludeXmlComments(xmlCommentsFullPath);
			});

			services.Configure<IISServerOptions>(options =>
			{
				options.AutomaticAuthentication = true;
			});

			services.AddAuthentication(IISDefaults.AuthenticationScheme);

			services.AddAuthorization(options =>
			{
				options.AddPolicy("ADRoleOnly", policy => policy.RequireRole(Configuration["SecuritySettings:ADGroup"]));
			});

			services.AddScoped<IParkingLotRepository, ParkingLotRepository>();

			services.AddDbContext<ParkingLotDbContext>(options =>
			{
				options.UseSqlServer(
					@"Server=(localdb)\mssqllocaldb;Database=UserContextDB;Trusted_Connection=True;");
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TPAParkingLotAPI v1"));
            }

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
