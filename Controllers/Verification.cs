using Company_CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company_CRM.Controllers;

public class Verification : Controller
{
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(Employee employee)
    {
        // тут будет добавление в бд
        return View();
    }
}