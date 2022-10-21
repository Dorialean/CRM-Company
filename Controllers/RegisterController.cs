using Microsoft.AspNetCore.Mvc;

namespace Company_CRM.Controllers;

public class RegisterController : Controller
{
    // GET
    public IActionResult Register()
    {
        return View();
    }
}