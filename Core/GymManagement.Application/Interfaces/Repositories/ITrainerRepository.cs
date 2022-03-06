using System.Collections.Generic;
using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface ITrainerRepository : IRepositoryBase<Trainer>
    {
        List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail();
    }
}