using HossamSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HossamSystem.Controllers
{
    [Authorize(Roles = "Owner")]
    public class OwnerDashboardController : Controller
    {
        public IActionResult Index() => Content("Welcome Owner!");
    }
}
