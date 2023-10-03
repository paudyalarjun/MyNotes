using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context) {
            _context = context;
        }


        public IActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }




        [HttpGet]
        public ActionResult Create()
        {
            ////var teacherViewModel = new TeacherViewModel
            ////{
            ////    Teacher = new Teacher(),
            ////    Departments = new SelectList(_context.Departments, "ID", "Name")
            ////};
            //ViewBag.TeacherList = new SelectList(_context.Teacher, "ID", "Name");
            //ViewBag.DepartmentList = new SelectList(_context.Departments, "ID", "Name");
            //return View();

            return View(new TeacherViewModel());
        }



        [HttpPost]
        public IActionResult Create(TeacherViewModel model)  //  (TeacherDepartmentViewModel viewModel)
        {

            //if (ModelState.IsValid)
            //{
            //    // Create a TeacherDepartment entry
            //    var teacherDepartment = new TeacherDepartment
            //    {
            //        TeacherID = viewModel.TeacherID,
            //        DepartmentID = viewModel.DepartmentID
            //    };

            //    _context.Add(teacherDepartment);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //// If the model state is not valid, re-populate dropdown lists and return to the Create view
            //ViewBag.TeacherList = new SelectList(_context.Teachers, "ID", "Name", viewModel.TeacherID);
            //ViewBag.DepartmentList = new SelectList(_context.Departments, "ID", "Name", viewModel.DepartmentID);

            //return View(viewModel);

            if (ModelState.IsValid)
            {
                var teacher = new Teacher()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Gender = model.Gender,
                };

                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Teacher");
            }

            return View(model);
        }




        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.ID == ID);
            var model = new TeacherViewModel()
            {
                ID = teacher.ID,
                Name = teacher.Name,
                Email = teacher.Email,
                Address = teacher.Address,
                Gender = teacher.Gender,
            };

            return View(model);
        }



        [HttpPost]
        public IActionResult Edit(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teacher = new Teacher
                {
                    ID = model.ID,
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Gender = model.Gender,
                };


                _context.Teachers.Update(teacher);
                _context.SaveChanges(true);
                return RedirectToAction(nameof(Index), "Teacher");
            }
            return View(model);
        }


        public IActionResult Delete(int ID)
        {
            if (ID == 0)
            {
                return Content("Error");
            }
            var teacher = _context.Teachers.FirstOrDefault(x => x.ID == ID);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Teacher");
        }

    }
    

}
