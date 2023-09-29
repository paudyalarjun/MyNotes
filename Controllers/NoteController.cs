using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace MyNotes.Controllers
{
    // [Authorize]
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<User> _userManager;
        public NoteController(ApplicationDbContext context) // context, UserManager<User> userManager)
        {
            _context = context;
            //_userManager = UserManager;
        }


        //note/index
        //note
        [HttpGet]

        public IActionResult Index()
        {
            var notes = _context.Notes.ToList();
            
            return View(notes);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new NoteViewModel());
        }

        [HttpPost]
        public IActionResult Create(NoteViewModel model)
        {
            if(ModelState.IsValid)
            {
                var note = new Note()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Color = model.Color,
                };
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Note");
            }
            return View(model);
        }




        // Edit Get
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var note = _context.Notes.FirstOrDefault(x => x.ID == Id);

            var model = new NoteViewModel()
            {
                ID = note.ID,
                Title = note.Title,
                Description = note.Description,
                Color = note.Color,
                CreatedDate = note.CreatedDate,
                UserId = note.UserId
            };
            return View(model);
        }

        //Edit Post

        [HttpPost]
        public IActionResult Edit(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var note = new Note
                {
                    ID = model.ID,
                    Title = model.Title,
                    Description = model.Description,
                    Color = model.Color,
                    CreatedDate = model.CreatedDate,
                };
                _context.Notes.Update(note);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Note");
            }
            return(View(model));
        }
		
		
		
		
        //Delete
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return Content("Error");
            }
            var note = _context.Notes.FirstOrDefault(x => x.ID == Id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Note");
        }

    }
}
