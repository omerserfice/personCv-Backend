using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using personApp.Business.Abstract;
using personApp.Business.Abstract.Index;
using personApp.Business.Concrete;
using personApp.Business.Concrete.Index;
using personApp.DAL.Context;
using personApp.DAL.LoginSecurity.Helper;
using personApp.DAL.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using personApp.DAL.LoginSecurity.Entity;
using personApp.DAL.LoginSecurity.Encryption;

namespace personApp.WebAPI
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
            services.AddDbContext<personAppDbContext>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IAbilityService, AbilityService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<IMessageService, MessageService>();  
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<ITokenHelper, TokenHelper>();

         


            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IIndexCoverImageService, IndexCoverImageService>();
            services.AddScoped<IIndexGalleryImageService, IndexGalleryImageService>();
            services.Configure<MongoOptions>(Configuration.GetSection("MongoOptions"));           
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "personApp.WebAPI", Version = "v1" });
            });

            //JWT AYARI
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<DAL.LoginSecurity.Entity.TokenOptions>();
            services.Configure<DAL.LoginSecurity.Entity.TokenOptions>(Configuration.GetSection("TokenOptions"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtOption =>
            {
                jwtOption.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,    
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });
            //CORS 
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                 builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "personApp.WebAPI v1"));
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
