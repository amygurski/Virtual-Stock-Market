using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TEGram.DAL;
using TEGramApi.Providers.Security;

namespace TEGramApi
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
            // Add CORS policy allowing any origin
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Enables automatic authentication token.
            // The token is expected to be included as a bearer authentication token.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // The rules for token validation
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,                 // issuer not required
                        ValidateAudience = false,               // audience not required
                        ValidateLifetime = true,                // token must not have expired
                        ValidateIssuerSigningKey = true,        // token signature must match so as not to be tampered with
                        NameClaimType = System.Security.Claims.ClaimTypes.NameIdentifier,   // allows us to use sub for username
                        RoleClaimType = "rol",                  // allows us to put the role in rol
                        IssuerSigningKey = new SymmetricSecurityKey(    // each token is signed with a private key so as to ensure its validity
                            Encoding.UTF8.GetBytes(Configuration["JwtSecret"]))
                    };
                });

            // Dependency Injection configuration
            services.AddSingleton<ITokenGenerator>(tk => new JwtGenerator(Configuration["JwtSecret"]));
            services.AddSingleton<IPasswordHasher>(ph => new PasswordHasher());

            // Add all the Daos
            string defaultCS = Configuration.GetConnectionString("Default");
            services.AddTransient<ICommentDAO>(m => new CommentSqlDAO(defaultCS));
            services.AddTransient<IFavoriteDAO>(m => new FavoriteSqlDAO(defaultCS));
            services.AddTransient<ILikeDAO>(m => new LikeSqlDAO(defaultCS));
            services.AddTransient<IPostDAO>(m => new PostSqlDAO(defaultCS));
            services.AddTransient<IUserDAO>(m => new UserSqlDAO(defaultCS));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configure automatic model state validation
            // This prevents us from having to manually check model state in each action.
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    // Get all of the errors in a list
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();
                    // Create a result object
                    var result = new
                    {
                        Message = "Validation errors",
                        Errors = errors
                    };
                    return new BadRequestObjectResult(result);
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            // Enables the middleware to check the incoming request headers.
            app.UseAuthentication();


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
