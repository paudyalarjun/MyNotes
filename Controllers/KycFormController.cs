using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.ViewModels;
using System.Net;

namespace MyNotes.Controllers
{
    public class KycFormController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KycFormController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            var kycforms = _context.KycForms.ToList();
            return View(kycforms);
        }





        public JsonResult GetStates()
        {
            var states = _context.State.OrderBy(x => x.Sname).ToList();
            return new JsonResult(states);
        }




        public JsonResult GetDistricts( int StateId)
        {

            var districts = _context.District.Where(x => x.StateId == StateId ).OrderBy(x => x.Dname).ToList();
            return new JsonResult(districts);
        }







        public IActionResult Create()
        {

            return View(new KycFormViewModel());
        }



        [HttpPost]
        public IActionResult Create(KycFormViewModel model)
        {
            string stringFileName = UploadFile(model);
            if (ModelState.IsValid)
            {

                var kycform = new KycForm()
                {
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    PermaState = model.PermaState,
                    PermaDistrict = model.PermaDistrict,
                    PermaMunicipality = model.PermaMunicipality,
                    PermaWard = model.PermaWard,
                    PermaStreet = model.PermaStreet,
                    TempState = model.TempState,
                    TempDistrict = model.TempDistrict,
                    TempMunicipality = model.TempMunicipality,
                    TempWard = model.TempWard,
                    TempStreet = model.TempStreet,
                    ProfileImage = stringFileName,

                };
                _context.KycForms.Add(kycform);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "KycForm");
            }
            return View(model);
        }

        private string UploadFile(KycFormViewModel model)
        {
            string fileName = null;
            if(model.ProfileImage != null)
            {
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + model.ProfileImage.FileName ;
                string filePath = Path.Combine(UploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create ))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return fileName;

        }
    }
}
