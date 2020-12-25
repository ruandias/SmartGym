using Microsoft.AspNetCore.Mvc;
using SmartGym.Domain.Interfaces;
using SmartGym.Domain.Models;
using System;

namespace SmartGym.API.Controllers
{
    [Route("api/personalTrainers")]
    [ApiController]
    public class PersonalTrainerController : Controller
    {
        private readonly IServicePersonalTrainer _servicePersonalTrainer;

        public PersonalTrainerController(IServicePersonalTrainer servicePersonalTrainer) =>
            _servicePersonalTrainer = servicePersonalTrainer;


        [HttpPost]
        public IActionResult Register([FromBody] CreatePersonalTrainerModel personalTrainerModel)
        {
            try
            {
                var personalTrainer = _servicePersonalTrainer.Insert(personalTrainerModel);

                return Created($"/api/personalTrainers/{personalTrainer?.Id}", personalTrainer?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdatePersonalTrainerModel personalTrainerModel)
        {
            try
            {
                var user = _servicePersonalTrainer.Update(id, personalTrainerModel);

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
                _servicePersonalTrainer.Delete(id);

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
                var personalTrainers = _servicePersonalTrainer.RecoverAll();
                return Ok(personalTrainers);
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
                var personalTrainer = _servicePersonalTrainer.RecoverById(id);
                return Ok(personalTrainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
