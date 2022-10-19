using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace api.segundoparcial.Controllers
{
    public class CiudadController : Controller
    {
        // GET: CiudadController
        public async Task<ActionResult> Index()
        {
            List<Models.ciudadModel> ciudades = new List<Models.ciudadModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7196/ciudad/");
            Models.ciudadModel ciudad = JsonConvert.DeserializeObject<Models.ciudadModel>(json);
            ciudades.Add(ciudad);
            return View();
        }

        // GET: CiudadController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            List<Models.ciudadModel> ciudades = new List<Models.ciudadModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7196/ciudad/{id}");
            Models.ciudadModel ciudad = JsonConvert.DeserializeObject<Models.ciudadModel>(json);
            ciudades.Add(ciudad);
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
        public async Task<ActionResult> Create(Models.ciudadModel ciudad)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ciudad);
                var data = new StringContent(json, Encoding.UTF8, "Application/json");
                var api = new HttpClient();
                var response = await api.PostAsync("https://localhost:7261/ciudad/", data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CiudadController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            List<Models.ciudadModel> ciudades = new List<Models.ciudadModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7196/clientes/{id}");
            Models.ciudadModel ciudad = JsonConvert.DeserializeObject<Models.ciudadModel>(json);
            ciudades.Add(ciudad);
            return View();
        }

        // POST: CiudadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.ciudadModel ciudad)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ciudad);
                var data = new StringContent(json, Encoding.UTF8, "Application/json");
                var api = new HttpClient();
                var response = await api.PutAsync("https://localhost:7261/Clientes/{id}", data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CiudadController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            List<Models.ciudadModel> ciudades = new List<Models.ciudadModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7196/clientes/{id}");
            Models.ciudadModel ciudad = JsonConvert.DeserializeObject<Models.ciudadModel>(json);
            ciudades.Add(ciudad);
            return View();
        }

        // POST: CiudadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    var api = new HttpClient();
                    var response = await api.DeleteAsync("https://localhost:7261/clientes/{id}");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
