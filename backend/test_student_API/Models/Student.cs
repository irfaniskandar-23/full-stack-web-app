using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace test_student_API.Models
{
    public class Student
    {

        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }

        [Required]
        public string MatricId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CourseName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime Registered_Date { get; set; } = DateTime.UtcNow;

    }
}   
