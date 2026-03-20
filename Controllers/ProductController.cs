using Microsoft.AspNetCore.Mvc;
using ecommerce_website.Data;
using ecommerce_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ecommerce_website.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor mein database aur webHost (for images) inject karein
        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // 1. Form dikhane ke liye (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 2. Data save karne ke liye (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // Image Upload Logic
                if (imageFile != null)
                {
                    string folder = "images/";
                    folder += Guid.NewGuid().ToString() + "_" + imageFile.FileName; // Unique name
                    product.ImageName = folder; // Database mein path save hoga

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Save hone ke baad Home par bhej dega
            }
            return View(product);
        }
    }
}