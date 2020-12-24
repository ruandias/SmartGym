using Microsoft.AspNetCore.Mvc;
using SmartGym.API.Persistence;
using SmartGym.Domain.Entities;
using System.Linq;

namespace SmartGym.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SqlServerDbContext _sqlServerDbContext;
        public StudentController(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _sqlServerDbContext.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _sqlServerDbContext.Students.SingleOrDefault(s => s.Id == id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
            _sqlServerDbContext.Students.Add(student);

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
