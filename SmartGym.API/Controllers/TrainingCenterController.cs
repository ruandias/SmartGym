using Microsoft.AspNetCore.Mvc;
using SmartGym.Domain.Entities;
using SmartGym.Domain.Interfaces;
using SmartGym.Domain.Models;
using System;

namespace SmartGym.API.Controllers
{
    [Route("api/trainingCenters")]
    [ApiController]
    public class TrainingCenterController : ControllerBase
    {
        private readonly IServiceTrainingCenter _serviceTrainingCenter;

        public TrainingCenterController(IServiceTrainingCenter serviceTrainingCenter) =>
            _serviceTrainingCenter = serviceTrainingCenter;


        [HttpPost]
        public IActionResult Register([FromBody] CreateTrainingCenterModel trainingCenterModel)
        {
            try
            {
                var trainingCenter = _serviceTrainingCenter.Insert(trainingCenterModel);

                return Created($"/api/trainingCenters/{trainingCenter?.Id}", trainingCenter?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateTrainingCenterModel trainingCenterModel)
        {
            try
            {
                var user = _serviceTrainingCenter.Update(id, trainingCenterModel);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            try
            {
                _serviceTrainingCenter.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult RecoverAll()
        {
            try
            {
                var users = _serviceTrainingCenter.RecoverAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Recover([FromRoute] int id)
        {
            try
            {
                var user = _serviceTrainingCenter.RecoverById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
