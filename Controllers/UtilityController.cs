using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Controllers
{
    public class UtilityController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public UtilityController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _db = context;
        }
        public IActionResult UtilityProfile()
        {
            var utilProfiles = _db.UtilityProfile
                .Include(up => up.Utilities)
                .Include(up => up.Properties)
                .ToList();
            return View(utilProfiles);
        }
    }
}
