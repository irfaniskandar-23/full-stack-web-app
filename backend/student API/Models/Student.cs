using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace student_API.Models
{
    public class Student
    {
        [SwaggerSchema(ReadOnly = true)]
        public Guid studentId { get; set; }

        [Required]
        public string? MatricId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Contact { get; set; }
       
        [Required]
        public string? courseName { get; set; }


        [SwaggerSchema(ReadOnly = true)]
        public DateTime Registered_Date { get; set; } = DateTime.UtcNow;
    }
}
