using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Contexts;
using GymManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<GymManagementDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("mssql")));
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IEmployeeDetailRepository, EmployeeDetailRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IExerciseProgramRepository, ExerciseProgramRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IMissionRepository, MissionRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IWorkerContractRepository, WorkerContractRepository>();
        }
    }
}


//Singleton => Uygulama start aldığında bir instance oluşur uygulama durana kadar o kullanılır.
//Scoped => Request geldiğinde oluşur Response dönene kadar. Yeni Request geldiğinde  tekrar bir instance oluşturulur. 
//Transient => Nesneye her erişmek istediğiniz de yeni bir instance oluşuturuluyor.