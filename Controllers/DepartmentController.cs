using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.ViewModels;


namespace MyNotes.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }






        [HttpGet]
        public IActionResult Create()
        {
            
            return View(new DepartmentViewModel());
            
        }


        [HttpPost]
        public IActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Name = model.Name
                } ;
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Department");
            }
            return View(model);
        }




        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var department = _context.Departments.FirstOrDefault(x => x.ID == ID);
            var model = new DepartmentViewModel()
            {
                ID = department.ID,
                Name = department.Name,
            };

            return View(model);

        }




        [HttpPost]
        public IActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    ID = model.ID,
                    Name = model.Name,
                };

                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Department");
            }
            return View(model);
        }



        public IActionResult Delete(int ID)
        {
            var department = _context.Departments.FirstOrDefault(x => x.ID == ID);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Department");
        }


    }
}
