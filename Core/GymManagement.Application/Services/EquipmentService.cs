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
using GymManagement.Application.Exception;
using GymManagement.Application.Validations;
using FluentValidation;

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

        public bool Delete(int id)
        {
            var equipment = _unitOfWork.Equipments.GetById(id);
            equipment.IfIsNullThrowNotFoundException("Equipment", id);
            equipment.IsDeleted = true;
            _unitOfWork.Equipments.Update(equipment);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }

            return false;

        }

        public bool Create(EquipmentCommandViewModel model)
        {
            var validator = new EquipmentValidator();
            validator.ValidateAndThrow(model);
            var equipment = _mapper.Map<Equipment>(model);
            equipment.MaintanancePeriod = equipment.CreatedDate.AddMonths(model.Duration);
            _unitOfWork.Equipments.Create(equipment);
            return _unitOfWork.SaveChanges();
        }

        public bool Update(EquipmentCommandViewModel model, int id)
        {
            var validator = new EquipmentValidator();
            validator.ValidateAndThrow(model);
            var equipment = _mapper.Map<Equipment>(model);
            equipment.Id = id;
            var getByEquipment = _unitOfWork.Equipments.GetById(id);

            getByEquipment.IfIsNullThrowNotFoundException("Equipment", id);

            equipment.MaintanancePeriod = equipment.CreatedDate.AddMonths(model.Duration);
            _unitOfWork.Equipments.Update(equipment);
            return _unitOfWork.SaveChanges();
        }
    }
    
}
