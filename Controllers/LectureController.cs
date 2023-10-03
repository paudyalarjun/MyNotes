using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.ViewModels;


namespace MyNotes.Controllers
{
    public class LectureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LectureController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var lectures = _context.Lectures.ToList();
            return View(lectures);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View(new LectureViewModel());
        }


        
        [HttpPost]
        public IActionResult Create(LectureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lecture = new Lecture()
                {
                    Name = model.Name,
                };

                _context.Lectures.Add(lecture);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Lecture" );

            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var lecture = _context.Lectures.FirstOrDefault(x => x.ID == ID);
            var model = new LectureViewModel()
            {
                ID = lecture.ID,
                Name = lecture.Name,
            };

            return View(model);

        }




        [HttpPost]
        public IActionResult Edit(LectureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lecture = new Lecture
                {
                    ID = model.ID,
                    Name = model.Name,
                };

                _context.Lectures.Update(lecture);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Lecture");
            }
            return View(model);
        }



        public IActionResult Delete(int ID)
        {
            var lecture = _context.Lectures.FirstOrDefault(x => x.ID == ID);
            _context.Lectures.Remove(lecture);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Lecture");
        }
    }

}
