using Microsoft.AspNetCore.Mvc;
using SmartGym.Domain.Interfaces;
using SmartGym.Domain.Models;
using System;

namespace SmartGym.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : Controller
    {
        private readonly IServiceStudent _serviceStudent;

        public StudentController(IServiceStudent serviceStudent) =>
            _serviceStudent = serviceStudent;


        [HttpPost]
        public IActionResult Register([FromBody] CreateStudentModel studentModel)
        {
            try
            {
                var student = _serviceStudent.Insert(studentModel);

                return Created($"/api/students/{student?.Id}", student?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStudentModel studentModel)
        {
            try
            {
                var user = _serviceStudent.Update(id, studentModel);

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
                _serviceStudent.Delete(id);

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
                var users = _serviceStudent.RecoverAll();
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
                var user = _serviceStudent.RecoverById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
