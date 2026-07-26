using HossamSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HossamSystem.Controllers
{
    [Authorize(Roles = "Supplier")]
    public class SupplierDashboardController : Controller
    {
        public IActionResult Index() => Content("Welcome Supplier!");
    }
}
