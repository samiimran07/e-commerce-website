using Microsoft.AspNetCore.Mvc;

public class ProductController: Controller
{
    // Yeh wala page tab dikhega jab user search karega
    public IActionResult Index()
    {
        // Yahan aap apna database se search karne ka logic likh sakte hain
        // Abhi ke liye ye sirf View return karega jo aapne banaya hai
        return View();
    }
}