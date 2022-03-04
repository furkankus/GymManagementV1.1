using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.ExerciseProgramViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseProgramController : ControllerBase
    {
        readonly IExerciseProgramService _exerciseService;

        public ExerciseProgramController(IExerciseProgramService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ExerciseProgramCommandViewModel model)
        {
            var result = _exerciseService.Create(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ExerciseProgramCommandViewModel model, int id)
        {
            var result = _exerciseService.Update(model, id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Update(int id)
        {
            var result = _exerciseService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
