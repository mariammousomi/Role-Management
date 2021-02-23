using CoreProjectRole.Attributes.Authorize;
using CoreProjectRole.Data;
using CoreProjectRole.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectRole.Controllers
{
    [Authorize]
    public class MyProduct : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MyProduct(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Index()
        {
            ViewData["Create"] = RolesForMenu.GetMenu(User.Identity.Name, "MyProduct", "Create");
            ViewData["Edit"] = RolesForMenu.GetMenu(User.Identity.Name, "MyProduct", "Edit");
            ViewData["Delete"] = RolesForMenu.GetMenu(User.Identity.Name, "MyProduct", "Delete");

 






            return View( _context.ProductsVM.ToList());
        }
        [HttpGet]
        [CustomAuthorize("MyProduct", "Create")]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
       
        [CustomAuthorize("MyProduct", "Create")]
        public async Task<ActionResult> Create(ProductV _product)
        {
            if (ModelState.IsValid)
            {
                string Image = "";

                var files = HttpContext.Request.Form.Files;
                foreach (var img in files)
                {
                    if (img != null && img.Length > 0)
                    {
                        var file = img;

                        var uploads = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Image = fileName;
                            }

                        }
                    }
                }

                var data = new ProductV()
                {
                    ProductName = _product.ProductName,
                    Quantity = _product.Quantity,
                    Price = _product.Price,
                    IssueDate = _product.IssueDate,
                    Image = Image,
                };

                _context.ProductsVM.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(_product);
        }
        [HttpGet]
        [CustomAuthorize("MyProduct", "Edit")]
        public ActionResult Edit(int id)
        {
            var product = _context.ProductsVM.Find(id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
      
        [CustomAuthorize("MyProduct", "Edit")]
        public async Task<ActionResult> Edit(int id, ProductV _product)
        {
            if (ModelState.IsValid)
            {
                string Image = "";
                var files = HttpContext.Request.Form.Files;
                foreach (var img in files)
                {
                    if (img != null && img.Length > 0)
                    {
                        var file = img;

                        var uploads = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Image = fileName;
                            }

                        }
                    }
                }
                var data = _context.ProductsVM.Find(id);
                data.ProductName = _product.ProductName;
                data.Quantity = _product.Quantity;
                data.Price = _product.Price;
                data.IssueDate = _product.IssueDate;
                data.Image = Image;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(_product);
        }
        [HttpGet]
        [CustomAuthorize("MyProduct", "Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = _context.ProductsVM.Find(id);
            _context.ProductsVM.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
