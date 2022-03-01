using InterviewTestExercise.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTestExercise.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<double> GetStudentAverageGrade(Student student);
        Task AddGradeToStudent(int studentId, int grade);
        Task<List<Grade>> GetStudentGrades(int studentId);
    }
}
