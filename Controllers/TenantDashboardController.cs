using HossamSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HossamSystem.Controllers
{
    [Authorize(Roles = "Tenant")]
    public class TenantDashboardController : Controller
    {
        public IActionResult Index() => Content("Welcome Tenant!");
    }
}
