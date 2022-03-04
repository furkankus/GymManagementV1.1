using System.Collections.Generic;
using GymManagement.Application.ViewModels.ExerciseProgramViewModel;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IExerciseProgramService
    {
        List<ExerciseProgramQueryViewModel> GetAll();
        bool Create(ExerciseProgramCommandViewModel model);
        bool Update(ExerciseProgramCommandViewModel model, int id);
        bool Delete(int id);
    }
}
