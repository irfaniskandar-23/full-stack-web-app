using student_API.Models;

namespace student_API.Services
{
    public interface Istudent
    {
        Task<IEnumerable<Student>> getAllStudent();
        Task<Student>registerStudent(Student objStudent);
        Task<Student> getStudentbyId(Guid Id);

        Task<Student> getStudentbyMatric(string Matric);
        Task<IEnumerable<Student>> getStudentsbyCourse(string Course);

        Task<Student> updateStudent(Guid Id, Student objStudent);

        bool deleteStudent(Guid Id);
    }

}
