using HossamSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HossamSystem.Controllers
{
    [Authorize(Roles = "EmployeeManager")]
    public class EmployeeDashboardController : Controller
    {
        public IActionResult Index() => Content("Welcome EmployeeManager!");
    }
}
