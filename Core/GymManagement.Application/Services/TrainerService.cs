using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagement.Application.Exception;
using GymManagement.Application.ViewModels.TrainerViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace GymManagement.Application.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddMemberExerciseProgram(int memberId)
        {
            throw new NotImplementedException();
        }

        public bool EquipmentMaintenanceControl(int equipmentId)
        {
            var equipment = _unitOfWork.Equipments.GetById(equipmentId);

            equipment.IfIsNullThrowNotFoundException("Equipment", equipmentId);

            equipment.IsActive = false;
            _unitOfWork.Equipments.Update(equipment);

            return _unitOfWork.SaveChanges();
        }

        public List<Trainer> GetAll()
        {
            return null;
        }

        public List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail()
        {
            var result = _unitOfWork.Trainers.GetTrainersWithEmployeeDetail();
            return result;
        }

        object ITrainerService.GetTrainersWithEmployeeDetail()
        {
            throw new NotImplementedException();
        }
    }
}
