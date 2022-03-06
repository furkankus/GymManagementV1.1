using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.TrainerViewModel;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        public IActionResult CreateTrainer([FromBody] TrainerCommandViewModel model)
        {
            if (_managerService.CreateTrainer(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{trainerId}")]
        public IActionResult AddMissionToTrainer([FromQuery] int missionId, int trainerId)
        {
            //Buraya bakılacak...
            if (_managerService.AddMissionToTrainer(missionId, trainerId))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
