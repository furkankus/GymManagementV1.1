
using System.Collections.Generic;
using GymManagement.Application.ViewModels.TrainerViewModel;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ITrainerService
    {
        List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail();
        //bool AddMemberExerciseProgram(string memberId);
        bool EquipmentMaintenanceControl(int equipmentId);
    }
}
