﻿using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;
using GymManagement.Infrastructure.Repositories;
using GymManagement.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GymManagement.Infrastructure.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<GymManagementDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("mssql")));
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IEmployeeDetailRepository, EmployeeDetailRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IExerciseProgramRepository, ExerciseProgramRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IMissionRepository, MissionRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IWorkerContractRepository, WorkerContractRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddIdentity<Member, IdentityRole>().AddEntityFrameworkStores<GymManagementDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options => 
            { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        }
    }
}


//Singleton => Uygulama start aldığında bir instance oluşur uygulama durana kadar o kullanılır.
//Scoped => Request geldiğinde oluşur Response dönene kadar. Yeni Request geldiğinde  tekrar bir instance oluşturulur. 
//Transient => Nesneye her erişmek istediğiniz de yeni bir instance oluşuturuluyor.