using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.Services;
using MyNotes.ViewModels;

namespace MyNotes.Controllers
{
    public class StudentLectureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITeacherService _studentService;

        public StudentLectureController(ApplicationDbContext context, ITeacherService studentService)
        {
            _context = context;
            _studentService = studentService;
        }




        public IActionResult Index()
        {
            var data = _studentService.GetStudentLectureInfo();
            return View(data);
        }






        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StudentList = new SelectList(_context.Students, "ID", "Name");
            ViewBag.LectureList = new SelectList(_context.Lectures, "ID", "Name");
            return View(new StudentLectureViewModel());
        }



        [HttpPost]

        public IActionResult Create(StudentLectureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var studentlecture = new StudentLecture()
                {
                    StudentID = model.StudentID,
                    LectureID = model.LectureID,
                    StudentName = model.StudentName,
                    LectureName = model.LectureName,

                };
                _context.StudentLectures.Add(studentlecture);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "StudentLecture");
            }
            ViewBag.StudentList = new SelectList(_context.Students, "ID", "Name");
            ViewBag.LectureList = new SelectList(_context.Lectures, "ID", "Name");
            return View(model);
        }






        //[HttpPost]
        //public IActionResult Create(StudentLectureViewModel viewModel)   // (studentViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        // Create a studentlecture entry
        //        var studentlecture = new StudentLecture()
        //        {
        //            StudentID = viewModel.StudentID,
        //            LectureID = viewModel.LectureID,
        //            StudentName = viewModel.StudentName,
        //            LectureName = viewModel.LectureName,
        //        };

        //        _context.Add(studentlecture);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.studentList = new SelectList(_context.Students, "ID", "Name");
        //    ViewBag.lectureList = new SelectList(_context.Lectures, "ID", "Name");
        //    return View(viewModel);
        //}



        [HttpGet]
        public IActionResult Edit(int ID)
        {
            ViewBag.StudentList = new SelectList(_context.Students, "ID", "Name");
            ViewBag.LectureList = new SelectList(_context.Lectures, "ID", "Name");
            var studentlecture = _context.StudentLectures.FirstOrDefault(x => x.ID == ID);

            return View(studentlecture);

        }



        [HttpPost]
        public IActionResult Edit(StudentLectureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var studentlecture = new StudentLecture()
                {
                    ID = viewModel.ID,
                    StudentID = viewModel.StudentID,
                    LectureID = viewModel.LectureID,
                    StudentName = viewModel.StudentName,
                    LectureName = viewModel.LectureName,
                };
                _context.StudentLectures.Update(studentlecture);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "studentlecture");
            }
            ViewBag.StudentList = new SelectList(_context.Students, "ID", "Name");
            ViewBag.LectureList = new SelectList(_context.Lectures, "ID", "Name");
            return View(viewModel);
        }









        //[HttpPost]
        //public IActionResult Edit(StudentLectureViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var studentLecture = new StudentLecture()
        //        {
        //            ID = model.ID,
        //            StudentID = model.StudentID,
        //            LectureID = model.LectureID,
        //            StudentName = model.StudentName,
        //            LectureName = model.LectureName,
        //        };

        //        _context.StudentLectures.Update(studentLecture);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index), "StudentLecture");
        //    }
        //return View(model);
        //}


        public IActionResult DeletionSuccessful()
        {
            return View();
        }


        public IActionResult Delete(int ID)
        {
            if (ID  == 0)
            {
                return Content("Error");
            }
            var student = _context.StudentLectures.FirstOrDefault(x => x.ID == ID);
            _context.StudentLectures.Remove(student);
            _context.SaveChanges();
            

            return RedirectToAction("DeletionSuccessful", "StudentLecture");


        }










        //public IActionResult Delete(int ID)
        //{
        //    if (ID  == 0)
        //    {
        //        return Content("Error");
        //    }
        //    var studentLecture = _context.StudentLectures.FirstOrDefault(x => x.ID == ID);
        //    _context.StudentLectures.Remove(studentLecture);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index), "StudentLecture");
        //}


    }
}
