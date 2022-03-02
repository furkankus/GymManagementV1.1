using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;

namespace GymManagement.Infrastructure.Repositories
{
    public class CampaignRepository : RepositoryBase<Campaign>,ICampaignRepository
    {
        public CampaignRepository(GymManagementDbContext context) : base(context)
        {
        }

    }
}
