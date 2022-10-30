using System.Data;
using System.Net;
using System.Security.Claims;
using Company_CRM.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Company_CRM.Controllers;

public class VerificationController : Controller
{
    private readonly SneakerFactoryContext _sneakerFactoryContext;

    public VerificationController(SneakerFactoryContext sneakerFactoryContext)
    {
        _sneakerFactoryContext = sneakerFactoryContext;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(Employee? empl)
    {
        if (empl is null)
            return BadRequest("Пустой сотрудник");
        if (string.IsNullOrEmpty(empl.Login) || string.IsNullOrEmpty(empl.FirstName) || string.IsNullOrEmpty(empl.SecondName))
            return BadRequest("Вы не ввели логин");
        
        using (_sneakerFactoryContext)
        {
            //Добавить правильное добавления пароля здесь Солью лучше сделать дату добавления сотрудника!!
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
                    FactoryRole = empl.FactoryRole + (_sneakerFactoryContext.Employees.Count(x =>
                        x.FactoryRole != null && x.FactoryRole.Contains(empl.FactoryRole))+1),
                    Login = empl.Login
                });
                _sneakerFactoryContext.SaveChanges();
            }
        }
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, empl.Login),
            new Claim(ClaimTypes.Role, empl.FactoryRole),
            new Claim(ClaimTypes.Surname, empl.SecondName),
            new Claim(ClaimTypes.MobilePhone, empl.Phone),
            new Claim(ClaimTypes.Email, empl.Email),
            new Claim(ClaimTypes.StreetAddress, empl.Address),
        };
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookie");
        ControllerContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
        
        return RedirectToAction("Auth");
    }
    
    public IActionResult Auth(UserInfo userInfo)
    {
        var user = ControllerContext.HttpContext.User.Identity;
        if (string.IsNullOrEmpty(userInfo.Login))
            return BadRequest("Вы не ввели логин");
        if (string.IsNullOrEmpty(userInfo.Password))
            return BadRequest("Вы не ввели пароль");
        //Здесь надо добавить хэширование и соление пароля
        using (_sneakerFactoryContext)
        {
        }
        return View();
    }
}