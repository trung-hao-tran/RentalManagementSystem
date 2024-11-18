using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PropertyController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var allRenters = _db.Renters.ToList();
            return View(allRenters);
        }

        [HttpGet]
        public IActionResult AddRenter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRenter(RenterModel model)
        {
            if (model != null && model.Name.Length < 1) {
                ModelState.AddModelError("name", "Must have a name");
            }

            if (ModelState.IsValid) { 
                _db.Renters.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditRenter(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }
            RenterModel? selected = _db.Renters.Find(id);

            if (selected == null) { return NotFound(); }
            return View(selected);
        }

        [HttpPost]
        public IActionResult EditRenter(RenterModel model)
        {
            if (model != null && model.Name.Length < 1)
            {
                ModelState.AddModelError("name", "Must have a name");
            }

            if (ModelState.IsValid)
            {
                _db.Renters.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteRenter(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            RenterModel? current = _db.Renters.Find(id);
            if (current != null)
            {
                _db.Renters.Remove(current);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
