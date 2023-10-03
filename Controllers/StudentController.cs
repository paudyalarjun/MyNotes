using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.ViewModels;

namespace MyNotes.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context) {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var student = _context.Students.ToList();
            return View(student);
        }



        // Create Get Method
        public IActionResult Create()
        {
            return View(new StudentViewModel());
        }


        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if(ModelState.IsValid)
            {
                var student = new Student()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Gender = model.Gender,
                    Degree  = model.Degree,
                };
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Student");

            }
            return View(model);
        }




        //Edit Get
        [HttpGet]

        public IActionResult Edit(int ID)
        {
            var student = _context.Students.FirstOrDefault(x => x.ID == ID);

            var model = new StudentViewModel()
            {
                ID = student.ID,
                Name = student.Name,
                Email = student.Email,
                Address = student.Address,
                Gender = student.Gender,
                Degree = student.Degree,
                CreatedDate = student.CreatedDate


            };
            return View(model);
        }




        [HttpPost]

        public IActionResult Edit(StudentViewModel model)
        {
            if(ModelState.IsValid)
            {
                var student = new Student
                {
                    ID = model.ID,
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Gender = model.Gender,
                    Degree = model.Degree,
                    CreatedDate = model.CreatedDate,
                };
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Student");
            }
            return View(model);
        }



        //Delete
        public IActionResult Delete(int ID)
        {
            if(ID == 0)
            {
                return Content("Error!");
            }
            
            var student = _context.Students.FirstOrDefault(x => x.ID == ID);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Student");

        }
    }
}
