using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagement.Application.Interfaces.ServiceInterfaces;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
            private readonly ITrainerService _trainerService;

            public TrainerController(ITrainerService trainerService)
            {
                _trainerService = trainerService;
            }

            [HttpGet]
            public IActionResult GetTrainersWithEmployeeDetail()
            {
                return Ok(_trainerService.GetTrainersWithEmployeeDetail());
            }

            [HttpPut("{equipmentId}")]
            public IActionResult EquipmentMaintenanceControl(int equipmentId)
            {
                var result = _trainerService.EquipmentMaintenanceControl(equipmentId);
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
        }
}
