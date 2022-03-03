using GymManagement.Application.ViewModels.EquipmentViewModel;
using System;
using System.Collections.Generic;


namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IEquipmentService
    {
        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer();
    }
}
