using Microsoft.EntityFrameworkCore;
using student_API.Data;
using student_API.Models;
namespace student_API.Services
{
    public class StudentService : Istudent
    {
        private readonly fullStackDbContext _fullstackDbcontext;

        public StudentService(fullStackDbContext fullstackDbcontext)
        {
            _fullstackDbcontext = fullstackDbcontext;
        }

        public async Task<IEnumerable<Student>> getAllStudent()
        {
            return await _fullstackDbcontext.Students.ToListAsync();
        }

        public async Task<Student> registerStudent(Student objStudent)
        {
            _fullstackDbcontext.Students.Add(objStudent);
            await _fullstackDbcontext.SaveChangesAsync();
            return objStudent;
        }

        public async Task<Student> getStudentbyId(Guid Id)
        {
            return await _fullstackDbcontext.Students.FindAsync(Id);
        }

        public async Task<Student> getStudentbyMatric(string Matric)
        {
            var student = _fullstackDbcontext.Students.Where(c => c.MatricId == Matric).FirstOrDefault();
            return student;
        }

        public async Task<IEnumerable<Student>> getStudentsbyCourse(string Course)
        {
            return await _fullstackDbcontext.Students.Where(c => c.courseName == Course).ToListAsync();
        }

        public async Task<Student> updateStudent(Guid Id, Student objStudent)
        {
            var student = _fullstackDbcontext.Students.Find(Id);
            student.Name = objStudent.Name;
            student.Email = objStudent.Email;
            student.courseName = objStudent.courseName;
            student.Gender = objStudent.Gender;
            student.MatricId = objStudent.MatricId;

            await _fullstackDbcontext.SaveChangesAsync();
            return student;
        }

        public bool deleteStudent(Guid Id)
        {
            bool result = false;
            var student = _fullstackDbcontext.Students.Find(Id);
            if (student != null)
            {
                _fullstackDbcontext.Entry(student).State = EntityState.Deleted;
                _fullstackDbcontext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}
