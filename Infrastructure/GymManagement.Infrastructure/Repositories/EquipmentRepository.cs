using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Repositories
{
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
            private readonly GymManagementDbContext _context;
            public EquipmentRepository(GymManagementDbContext context) : base(context)
            {
                _context = context;
            }

            public List<Equipment> GetEquipmentsWithTrainer()
            {
                return _context.Equipments.Include(e => e.Trainer).ToList();
            }
    }
}