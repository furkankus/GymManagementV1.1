using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application.DependencyContainers
{
    public static class DependencyContainer 
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
