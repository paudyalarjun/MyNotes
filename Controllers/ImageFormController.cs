using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyNotes.Data;
using MyNotes.Migrations;
using MyNotes.ViewModels;

namespace MyNotes.Controllers
{
    public class ImageFormController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageFormController(ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment) {
            _context = context;
            _webHostEnvironment = _webHostEnvironment;
        }




        public IActionResult Index()
        {
            var imageForm = _context.ImageForms.ToList();
            return View(imageForm);
        }




        public IActionResult Create()
        {
            return View( new ImageFormViewModel() );
        }






        private string UploadFile(ImageFormViewModel model)
        {
            string photoName = null;
            if (model.ImageFile != null)
            {
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Pictures");
                photoName = Guid.NewGuid().ToString() + "-" + model.ImageIFile.FileName;
                string filePath = Path.Combine(UploadDir + photoName ) ;
                using(var fileStream = new FileStream(filePath, FileMode.Create ))
                {
                    model.ImageIFile.CopyTo(fileStream);
                }
            }
            return photoName;
        }







    }





}
