using InterviewTest.UI.Models;
using InterviewTestExercise.Domain.Entities;
using InterviewTestExercise.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InterviewTest.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService service)
        {
            _studentService = service;
        }

        public async Task<IActionResult> Index()
        {
            return View("StudentsView", await _studentService.GetStudentsAsync());
        }

        public IActionResult AddGradeView(Student student)
        {
            var addGradeViewModel = new AddGradeViewModel();
            addGradeViewModel.Student = student;
            return View("AddGradeView", addGradeViewModel);
        }

        public async Task<IActionResult> AddGrade(int studentId, int grade)
        {
            await _studentService.AddGradeToStudent(studentId, grade);
            return RedirectToAction("Index");
        }
    }
}
