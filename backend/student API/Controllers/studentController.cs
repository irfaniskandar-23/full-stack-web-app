using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_API.Models;
using student_API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace student_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class studentController : ControllerBase
    {
        private readonly Istudent _student;

        public studentController(Istudent student)
        {
            _student = student;
        }

        [HttpGet]
        [Route("student-list")]
        [SwaggerResponse((StatusCodes.Status200OK), Type = typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _student.getAllStudent());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        [SwaggerResponse((StatusCodes.Status200OK), Type = typeof(IEnumerable<Student>))]
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
        [Route("register")]
        [SwaggerResponse((StatusCodes.Status200OK), Type = typeof(IEnumerable<Student>))]
        public async Task<IActionResult> registerStudent(Student student)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _student.registerStudent(student));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("Matric")]
        [SwaggerResponse((StatusCodes.Status200OK), Type = typeof(IEnumerable<Student>))]
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
        [SwaggerResponse((StatusCodes.Status200OK), Type = typeof(IEnumerable<Student>))]
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

        [HttpPut]
        [Route("{Id}")]
        [SwaggerResponse((StatusCodes.Status200OK), Type = typeof(IEnumerable<Student>))]
        public async Task<IActionResult> UpdateStudent(Guid Id, Student objStudent)
        {
            var student = await _student.getStudentbyId(Id);

            if (student == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, await _student.updateStudent(Id, objStudent));
        }

        [HttpDelete]
        [Route("{Id}")]
        public JsonResult deleteStudent(Guid Id)
        {
            try
            {
                var result = _student.deleteStudent(Id);
                return new JsonResult(StatusCodes.Status204NoContent);
            }

            catch
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);
            }
           
        }
    }
}
