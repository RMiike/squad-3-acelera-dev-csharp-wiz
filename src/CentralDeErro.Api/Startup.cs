using System.Text;
using CentralDeErro.Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Services.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Infrastructure.Services;
using CentralDeErro.Infrastructure.Context;
using System;
using CentralDeErro.Infrastructure.Interface;
using CentralDeErro.Infrastructure.Repository;

namespace CentralDeErro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<CentralDeErrorContext>(opt => opt
                .UseSqlServer(Configuration.GetConnectionString("AuthString")));


            services.AddIdentityCore<User>(opt =>
            {

                //TODO modify params pass
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 8;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.MaxFailedAccessAttempts = 5;

                //TODO MODIFY 2fa
                opt.SignIn.RequireConfirmedAccount = true;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedPhoneNumber = false;

                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.@,-_1234567890";
            })
         .AddRoles<Role>()
         .AddEntityFrameworkStores<CentralDeErrorContext>()
         .AddRoleValidator<RoleValidator<Role>>()
         .AddRoleManager<RoleManager<Role>>()
         .AddSignInManager<SignInManager<User>>()
         .AddDefaultTokenProviders();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                               .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                           ValidateIssuer = false,
                           ValidateAudience = false
                       };
                   });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAccountManagerService, AccountManagerService>();
            services.AddScoped<ILogErroRepository, LogErroRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IMailService, MailService>();
            services.AddCors();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors(x =>
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EziLog - V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
