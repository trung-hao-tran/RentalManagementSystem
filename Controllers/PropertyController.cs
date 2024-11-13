using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allRenters = _context.Renters.ToList();
            return View(allRenters);
        }
    }
}
