using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagement.Application.ViewModels.CampaignViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ICampaignService
    {
        List<CampaignQueryViewModel> GetAll();
        CampaignQueryViewModel GetById(int id);
        bool Create(CampaignCommandViewModel model);
        bool Update(CampaignCommandViewModel model, int id);
        bool Delete(int id);
    }
}
