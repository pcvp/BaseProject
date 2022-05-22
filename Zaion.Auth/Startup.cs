using HibernatingRhinos.Profiler.Appender.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Threading.Tasks;
using Zaion.Auth.Data;
using Zaion.Auth.Roles;
using Zaion.Auth.Services;

namespace Zaion.Auth {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsuarioConnection")));
            services
                .AddIdentity<IdentityUser<int>, IdentityRole<int>>(opt => {
                    opt.SignIn.RequireConfirmedEmail = true;

                })
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsuariosApi", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<EmailService, EmailService>();
            services.AddScoped<CadastroService, CadastroService>();
            services.AddScoped<TokenService, TokenService>();
            services.AddScoped<LoginService, LoginService>();
            services.AddScoped<LogoutService, LogoutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
             UserManager<IdentityUser<int>> userManager,
             RoleManager<IdentityRole<int>> roleManager) {
            if (env.IsDevelopment()) {
                EntityFrameworkProfiler.Initialize();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuariosApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            CreateRoles(userManager, roleManager);
        }

        private void CreateRoles(UserManager<IdentityUser<int>> userManager, 
            RoleManager<IdentityRole<int>> roleManager) {        
            Task<IdentityResult> roleResult;

            bool hasAdminRole = roleManager.RoleExistsAsync(Role.Admin).GetAwaiter().GetResult();

            if (!hasAdminRole) {
                roleResult = roleManager.CreateAsync(new IdentityRole<int>(Role.Admin));
                roleResult.GetAwaiter().GetResult();
            }

            var emailAdmin = Configuration.GetValue<string>("UsuarioAdmin:Email");
            var senhaAdmin = Configuration.GetValue<string>("UsuarioAdmin:Senha");
            var adminUser = userManager.FindByEmailAsync(emailAdmin).GetAwaiter().GetResult();

            if (adminUser == null) {
                IdentityUser<int> administrator = new();
                administrator.Email = emailAdmin;
                administrator.UserName = emailAdmin;
                administrator.EmailConfirmed = true;

                IdentityResult newUser = userManager.CreateAsync(administrator, senhaAdmin)
                    .GetAwaiter().GetResult();

                if (newUser.Succeeded) {
                    _ = userManager.AddToRoleAsync(administrator, Role.Admin)
                        .GetAwaiter().GetResult();
                }
            }

        }
    }
}
