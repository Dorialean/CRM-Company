using System.Data;
using Company_CRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company_CRM.Controllers;

public class VerificationController : Controller
{
    private readonly SneakerFactoryContext _sneakerFactoryContext;

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(Employee empl)
    {
        if (empl is null)
            return BadRequest("Пустой сотрудник");
        if (string.IsNullOrEmpty(empl.Login) || string.IsNullOrEmpty(empl.FirstName) || string.IsNullOrEmpty(empl.SecondName))
            return BadRequest("Вы не ввели логин");
        using (_sneakerFactoryContext)
        {
            if (!_sneakerFactoryContext.Employees.Any(u =>
                    u.FirstName == empl.FirstName && u.SecondName == empl.SecondName))
            {
                _sneakerFactoryContext.Employees.Add(new Employee()
                {
                    FirstName = empl.FirstName,
                    SecondName = empl.SecondName,
                    FatherName = empl.FatherName,
                    Phone = empl.Phone,
                    Email = empl.Email,
                    Address = empl.Address,
                    FactoryRole = empl.FactoryRole + _sneakerFactoryContext.Employees.Count(x => x.FactoryRole != null && x.FactoryRole.Contains(empl.FactoryRole)),
                    Login = empl.Login
                });
            }
        }
        return View();
    }

    [HttpGet]
    public IActionResult Auth()
    {
        return View();
    }
}