using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Api.Core;
using Application.Commands;
using Implementation.Commands;
using Implementation.Validation;
using Application;
using DataAccess;
using Application.Queries;
using Implementation.Queries;
using Application.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Implementation;
using Application.Services;
using Implementation.Services;

namespace Api
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
            services.AddTransient<IUploadProductPhotoCommand, UploadProductPhotoCommand>();
            services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, UpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();
            services.AddTransient<ICommentCommand, CreateCommentCommand>();
            services.AddTransient<IUpdateCommentCommand, UpdateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, DeleteCommentCommand>();
            services.AddTransient<ILikeCommentCommand, LikeCommentCommand>();
            services.AddTransient<IDislikeCommentCommand, DislikeCommentCommand>();
            services.AddTransient<ILikeProductCommand, LikeProductCommand>();
            services.AddTransient<IDislikeProductCommand, DislikeProductCommand>();
            services.AddTransient<IGetAllProductQuery<ProductResult>, GetAllProducts>();
            services.AddTransient<IGetAllUsersQuery, GetAllUsers>();
            services.AddTransient<IGetOneProductQuery, GetOneProduct>();
            services.AddTransient<IGetOneUserQuery, GetOneUser>();
            services.AddTransient<ITopLikeProductsQuery, GetTopProducts>();
            services.AddTransient<ITopLikeCommentsQuery, GetTopComments>();
            services.AddTransient<IGetProductCommentsQuery, GetProductComments>();
            services.AddTransient<IRegistrationCommand, RegistrationCommand>();
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor, ApplicationActor>();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;
                if (user.FindFirst("ActorData") == null)
                {
                    return new JwtActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });


            services.AddTransient<ProductValidate>();
            services.AddTransient<CommentValidate>();
            services.AddTransient<UploadImageValidate>();
            services.AddTransient<CreateUserValidate>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<DataContext>();
            services.AddTransient<JwtManager>();
            services.AddTransient<ILoggerService, CPLogger>();
            services.AddTransient<IEmailService, SmtpClientEmailService>();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseMiddleware<ErrorMiddleware>();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
