using AutoMapper;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer()
        {
            var equipments = _unitOfWork.Equipments.GetEquipmentsWithTrainer();
            return _mapper.Map<List<EquipmentQueryViewModel>>(equipments);
        }

        public bool Create(Equipment model)
        {
            var equipment = _mapper.Map<Equipment>(model);
            equipment.MaintenancePeriod = equipment.CreatedDate.AddMonths(model.Duration);
            _unitOfWork.Equipments.Create(equipment);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }

        public bool Update(Equipment model, int id)
        {
            var equipment = _mapper.Map<Equipment>(model);
            var getByEquipment = _unitOfWork.Equipments.GetById(id);

            if (getByEquipment is null)
            {
                throw new InvalidOperationException("Equipment not found");
            }

            equipment.MaintenancePeriod = equipment.CreatedDate.AddMonths(model.Duration);
            _unitOfWork.Equipments.Update(equipment);

            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var equipment = _unitOfWork.Equipments.GetById(id);

            equipment.IsDeleted = true;
            _unitOfWork.Equipments.Update(equipment);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }

            return false;

        }
        
    }
    
}
