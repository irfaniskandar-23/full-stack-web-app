using test_student_API.Models;

namespace test_student_API.Services
{
    public interface Istudent
    {
        Task<IEnumerable<Student>> getStudents();
        Task<Student> registerStudent(Student objStudent);
        Task<Student> getStudentbyId(Guid Id);
        Task<Student> getStudentbyMatric(string Matric);
        Task<IEnumerable<Student>> getStudentsbyCourse(string Course);
        Task<Student> updateStudent(Guid Id, Student objStudent);
        bool deleteStudent(Guid Id);
    }
}
