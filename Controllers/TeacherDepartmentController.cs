using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.Services;
using MyNotes.ViewModels;

namespace MyNotes.Controllers
{
    public class TeacherDepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITeacherService _teacherService;

        public TeacherDepartmentController(ApplicationDbContext context, ITeacherService teacherService)
        {
            _context = context;
            _teacherService = teacherService;
        }




        public IActionResult Index()
        {
            var data = _teacherService.GetTeacherDepartmentInfo();
            return View(data);
        }






        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.TeacherList = new SelectList(_context.Teachers, "ID", "Name");
            ViewBag.DepartmentList = new SelectList(_context.Departments, "ID", "Name");
            return View();

            //return View(new TeacherViewModel());
        }



        [HttpPost]
        public IActionResult Create(TeacherDepartmentViewModel viewModel)   // (TeacherViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Create a TeacherDepartment entry
                var teacherDepartment = new TeacherDepartment()
                {
                    TeacherID = viewModel.TeacherID,
                    DepartmentID = viewModel.DepartmentID,
                    TeacherName = viewModel.TeacherName,
                    DepartmentName = viewModel.DepartmentName,
                };

                _context.Add(teacherDepartment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherList = new SelectList(_context.Teachers, "ID", "Name");
            ViewBag.DepartmentList = new SelectList(_context.Departments, "ID", "Name");
            return View(viewModel);
        }


        public IActionResult Edit(int ID)
        {
            var teacherDepartment = _context.TeacherDepartments.FirstOrDefault(x => x.ID == ID);
            var model = new TeacherDepartment()
            {
                ID = teacherDepartment.ID,
                TeacherID = teacherDepartment.TeacherID,
                DepartmentID = teacherDepartment.DepartmentID,
            };


            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(TeacherDepartmentViewModel model) {
            if (ModelState.IsValid)
            {
                var teacherDepartment = new TeacherDepartment()
                {
                    ID = model.ID,
                    TeacherID = model.TeacherID,
                    DepartmentID = model.DepartmentID,
                };

                _context.TeacherDepartments.Update(teacherDepartment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "TeacherDepartment");
            }

            ViewBag.TeacherList = new SelectList(_context.Teachers, "ID", "Name");
            ViewBag.DepartmentList = new SelectList(_context.Departments, "ID", "Name");
            return View(model);
        }



        public IActionResult Delete(int ID)
        {
            if (ID == 0)
            {
                return Content("Error");
            }
            var teacherDepartment = _context.TeacherDepartments.FirstOrDefault(x => x.ID == ID);
            _context.TeacherDepartments.Remove(teacherDepartment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "TeacherDepartment");
        }




    }
}
