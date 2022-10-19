using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.segundoparcial.Controllers
{
    public class CiudadController : Controller
    {
        // GET: CiudadController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CiudadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CiudadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CiudadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CiudadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CiudadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CiudadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CiudadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
