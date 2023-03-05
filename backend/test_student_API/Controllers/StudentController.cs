using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using test_student_API.Data;
using test_student_API.Models;
using test_student_API.Services;

namespace test_student_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly Istudent _student; 
        public StudentController(Istudent student)
        {
            _student = student ??
                throw new ArgumentNullException(nameof(student));
        }
        [HttpGet]
        [Route("student-list")]
        public async Task <IActionResult> Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _student.getStudents());
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
          
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetStudentById(Guid Id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _student.getStudentbyId(Id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Post(Student student)
        {
            var new_student = await _student.registerStudent(student);

            if (new_student == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
            return StatusCode(StatusCodes.Status201Created, new_student);

        }


        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateStudent( Guid Id,Student objStudent)
        {
            var student = await _student.getStudentbyId(Id);

            if(student == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            }
            return StatusCode(StatusCodes.Status200OK, await _student.updateStudent(Id, objStudent));
        }


        [HttpDelete]
        [Route("{Id}")]
        public JsonResult  deleteStudent(Guid Id)
        {
            try
            {
                var result = _student.deleteStudent(Id);
                return new JsonResult(StatusCodes.Status204NoContent);
            }

            catch (Exception ex)
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Matric")]
        public async Task<IActionResult> getStudentbyMatricId([FromQuery] string Matric)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _student.getStudentbyMatric(Matric));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("Course")]
        public async Task<IActionResult> getStudentsbyCourse([FromQuery] string Course)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _student.getStudentsbyCourse(Course));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
