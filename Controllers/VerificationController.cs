using System.Collections;
using System.Data;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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
    public IActionResult Register(UserInfo? empl)
    {
        if (empl is null)
            return BadRequest("Пустой сотрудник");
        if (string.IsNullOrEmpty(empl.Login) ||
            string.IsNullOrEmpty(empl.FirstName) ||
            string.IsNullOrEmpty(empl.SecondName) ||
            string.IsNullOrEmpty(empl.Password))
            return BadRequest("Введены не все обязательные данные.");

        AddEmployee(empl);
        GenerateIdentityClaims(empl);

        return RedirectToAction("Auth");
    }

    [HttpGet]
    public IActionResult Auth()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Auth(UserInfo userInfo)
    {
        if (string.IsNullOrEmpty(userInfo.Login))
            return BadRequest("Вы не ввели логин");
        if (string.IsNullOrEmpty(userInfo.Password))
            return BadRequest("Вы не ввели пароль");

        using (_sneakerFactoryContext)
        {
            var empl = _sneakerFactoryContext.Employees.FirstOrDefault(u => u.Login == userInfo.Login);
            if (empl is not null)
            {
                if (empl.Password.SequenceEqual(GeneratePassword(userInfo.Password, empl.Hired)))
                {
                    GenerateIdentityClaims(empl);
                    return View();
                }
                else
                    return BadRequest("Неравильный пароль");
            }
            else
                return BadRequest("Вы не зарегистрированы");
        }

        return View();
    }

    private byte[] GeneratePassword(string inputedPassword, DateTime hiredDate)
    {
        using (var hasher = SHA256.Create())
        {
            Encoding enc = Encoding.UTF8;
            byte[] salt = hasher.ComputeHash(enc.GetBytes(hiredDate.ToString()));
            byte[] bytePass = enc.GetBytes(inputedPassword);
            IEnumerable<byte> data = bytePass.Concat(salt);
            return hasher.ComputeHash(data.ToArray());
        }
    }

    private async Task GenerateIdentityClaims(UserInfo? empl)
    {
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
        await ControllerContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
    }
    private async Task GenerateIdentityClaims(Employee? empl)
    {
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
        await ControllerContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
    }

    private void AddEmployee(UserInfo? empl)
    {
        using (_sneakerFactoryContext)
        {
            if (!_sneakerFactoryContext.Employees.Any(u =>
                    u.FirstName == empl.FirstName &&
                    u.SecondName == empl.SecondName &&
                    u.Login == empl.Login))
            {
                var newEmpl = new Employee() 
                {
                    FirstName = empl.FirstName,
                    SecondName = empl.SecondName,
                    FatherName = empl.FatherName,
                    Phone = empl.Phone,
                    Email = empl.Email,
                    Address = empl.Address,
                    FactoryRole = empl.FactoryRole + (_sneakerFactoryContext.Employees.Count(x => x.FactoryRole != null && x.FactoryRole.Contains(empl.FactoryRole)) + 1).ToString(),
                    Login = empl.Login,
                    SaltPass = empl.Hired.ToString(),
                    Hired = empl.Hired,
                    Password = GeneratePassword(empl.Password, empl.Hired)
                };
                _sneakerFactoryContext.Employees.Add(newEmpl);
                _sneakerFactoryContext.SaveChanges();
            }
            else
            {
               BadRequest("Пользователь с такими данными уже существует.");
            }
        }
    }
}