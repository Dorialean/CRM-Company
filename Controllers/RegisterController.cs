using Company_CRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company_CRM.Controllers;

public class RegisterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(Employee empl)
    {
        Console.WriteLine(empl.FirstName);
        Console.WriteLine(empl.SecondName);
        Console.WriteLine(empl.FatherName);
        Console.WriteLine(empl.Address);
        Console.WriteLine(empl.Phone);
        Console.WriteLine(empl.Email);
        Console.WriteLine(empl.Login);
        Console.WriteLine(empl.Password);
        Console.WriteLine(empl.FactoryRole);
        return View();
    }
}