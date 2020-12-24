using Microsoft.AspNetCore.Mvc;
using SmartGym.API.Persistence;
using SmartGym.Domain.Entities;
using System.Linq;

namespace SmartGym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCenterController : ControllerBase
    {
        private readonly SqlServerDbContext _sqlServerDbContext;
        public TrainingCenterController(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trainingCenters = _sqlServerDbContext.TrainingCenters.ToList();
            return Ok(trainingCenters);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var trainingCenter = _sqlServerDbContext.TrainingCenters.SingleOrDefault(t => t.Id == id);

            if (trainingCenter == null)
                return NotFound();

            return Ok(trainingCenter);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TrainingCenter trainingCenter)
        {
            _sqlServerDbContext.TrainingCenters.Add(trainingCenter);

            _sqlServerDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
