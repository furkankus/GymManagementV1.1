using GymManagement.Application.Interfaces.Repositories;

namespace GymManagement.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ICampaignRepository Campaigns { get;}
        IEmployeeDetailRepository EmployeeDetails { get;}
        IEquipmentRepository Equipments { get; }
        IExerciseProgramRepository ExercisePrograms { get; }
        IManagerRepository Managers { get; }
        IMissionRepository Missions { get; }
        ITrainerRepository Trainers { get; }
        IWorkerContractRepository WorkerContracts { get; }
        bool SaveChanges();
    }
}
