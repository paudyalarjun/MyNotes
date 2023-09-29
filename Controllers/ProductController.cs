using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;
using MyNotes.ViewModels;

namespace MyNotes.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            this._context = context;
        }


        //Index
        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }



        // Create Get Request
        [HttpGet]

        public IActionResult Create()
        {
            return View(new ProductViewModel());
        }


        // Create Post Request
        [HttpPost]

        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = model.ProductName,
                    ProductCode = model.ProductCode,
                    Unit = model.Unit,
                    AddedDate = model.AddedDate,
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Product");
                
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var products = _context.Products.FirstOrDefault(x => x.ID == ID);
            var model = new ProductViewModel()
            {
                ID = products.ID,
                ProductName = products.ProductName,
                ProductCode= products.ProductCode,
                Unit = products.Unit,
                IsActive = products.IsActive,
                AddedDate = products.AddedDate

            };
            return View(model);

        }


        [HttpPost]

        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ID = model.ID,
                    ProductName = model.ProductName,
                    ProductCode = model.ProductCode,
                    Unit = model.Unit,
                    AddedDate = model.AddedDate
                };
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Product");
            }
            return View(model);
        }


        public IActionResult Delete(int ID)
        {
            if(ID == 0)
            {
                Content("Error!");
            }

            var product = _context.Products.FirstOrDefault(x =>x.ID == ID);
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Product");

        }










    }
}
