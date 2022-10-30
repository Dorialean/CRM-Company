using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company_CRM.Controllers
{
    public class WorkController : Controller
    {
        [Authorize]
        public IActionResult EmployeeSpace()
        {
            return View();
        }

        public IActionResult ClientOrder()
        {
            return View();
        }
    }
}
