using InterviewTestExercise.Domain.Entities;
using InterviewTestExercise.Domain.Interfaces.Services;
using InterviewTestExercise.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTestExercise.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _dbContext.Students.Include(s => s.Grades).ToListAsync();
        }

        public async Task<double> GetStudentAverageGrade(Student student)
        {
            if(student.Grades == null)
            {
                student.Grades = await GetStudentGrades(student.IdStudent);
            }

            return student.Grades.Select(g => g.GivenGrade).Average();
        }

        public async Task AddGradeToStudent(int studentId, int grade)
        {
            var givenGrade = new Grade();
            givenGrade.StudentId = studentId;
            givenGrade.GivenGrade = grade;
            await _dbContext.Grades.AddAsync(givenGrade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Grade>> GetStudentGrades(int studentId)
        {
            return await _dbContext.Grades.Where(g => g.StudentId == studentId).ToListAsync();
        }

    }
}
