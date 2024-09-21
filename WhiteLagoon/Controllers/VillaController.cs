using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// In the constructor (public VillaController(ApplicationDbContext db)), dependency
        /// injection is used to pass the ApplicationDbContext object (db) into the controller. This means the
        /// controller does not need to manually instantiate the database context; it's provided by the ASP.NET Core runtime.
        /// </summary>
        /// <param name="db"></param>
        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var villas = _db.tbl_Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
                ModelState.AddModelError("Name", "You cannot keep same desciption and name");
            
            if (ModelState.IsValid)
            {
                _db.tbl_Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            Villa? obj = _db.tbl_Villas.FirstOrDefault(v => v.Id == id);
            if(obj == null)
                return NotFound();
            return View(obj);
        }
    }
}
