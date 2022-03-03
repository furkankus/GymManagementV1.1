using System;
using System.Collections.Generic;
using System.Linq;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {  
        public List<Equipment> GetEquipmentsWithTrainer();
    }
}
