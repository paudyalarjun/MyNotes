using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.Services;
using MyNotes.ViewModels;
using System.Net;

namespace MyNotes.Controllers
{
    public class KycFormController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITeacherService _stateService;

        public KycFormController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, ITeacherService stateService) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _stateService = stateService;
        }





        public IActionResult Index()
         {
            ViewBag.StateList = new SelectList(_stateService.GetStateDistrictName());

            var kycforms = _stateService.GetStateDistrictName();
            //var kycform = _context.KycForms.ToList();
            return View(kycforms);
        }




        public JsonResult GetStates()
        {
            var states = _context.State.OrderBy(x => x.Name).ToList();
            return new JsonResult(states);
        }



        [Route("KycForm/GetDistricts")]
        public JsonResult GetDistricts( int id)
        {

            var districts = _context.District.Where(x => x.StateId == id ).OrderBy(x => x.Name).ToList();
            return new JsonResult(districts);
        }








        public IActionResult Create()
        {
            ViewBag.StateList = new SelectList(_context.State, "StateId", "Name");
            ViewBag.DistrictList = new SelectList(_context.District, "DistrictId", "Name");
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
                    TempState = model.TState,
                    TempDistrict = model.TDistrict,
                    TempMunicipality = model.TempMunicipality,
                    TempWard = model.TempWard,
                    TempStreet = model.TempStreet,
                    ProfileImage = stringFileName,

                };
                _context.KycForms.Add(kycform);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "KycForm");
            }

            ViewBag.StateList = new SelectList(_context.State, "StateId", "Name");
            ViewBag.DistrictList = new SelectList(_context.District, "DistrictId", "Name");
            return View(model);
        }






        public IActionResult Edit(int id)
        {
            var model = _context.KycForms.FirstOrDefault(x=>x.ID == id);

            ViewBag.StateList = new SelectList(_context.State, "StateId", "Name");
            ViewBag.DistrictList = new SelectList(_context.District, "DistrictId", "Name");
            return View(model);

        }



        [HttpPost]

        public IActionResult Edit(KycFormViewModel model)
        {
            string stringFileName = UploadFile(model);
            if (ModelState.IsValid)
            {
                var kycform = new KycForm()
                {
                    ID = model.ID,
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

                _context.KycForms.Update(kycform);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "KycForm");
            }
            ViewBag.StateList = new SelectList(_context.State, "StateId", "Name");
            ViewBag.DistrictList = new SelectList(_context.District, "DistrictId", "Name");
            return View(model);
        }





        public IActionResult Delete(int id)
        {
            //if ( id == 0 )
            //{
            //    return Content("Error!");
            //}
            var form = _context.KycForms.FirstOrDefault(x=>x.ID == id);
            _context.KycForms.Remove(form);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "KycForm");
        }






        private string UploadFile(KycFormViewModel model)
        {
            string fileName = null;
            if(model.ProfileImages != null)
            {
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + model.ProfileImages.FileName ;
                string filePath = Path.Combine(UploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create ))
                {
                    model.ProfileImages.CopyTo(fileStream);
                }
            }
            return fileName;

        }
    }
}



