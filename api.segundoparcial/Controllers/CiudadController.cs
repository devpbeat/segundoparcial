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
            var api = new HttpClient();
            var url = $"https://localhost:7196/ciudad/";
            var json = await api.GetAsync(url);
            var result = await json.Content.ReadAsStringAsync();
            IEnumerable<Models.ciudadModel> ciudades = JsonConvert.DeserializeObject<IEnumerable<Models.ciudadModel>>(result);
            return View(ciudades);
        }

        // GET: CiudadController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var api = new HttpClient();
            var url = $"https://localhost:7196/ciudad/{id}";
            var json = await api.GetStringAsync(url);
            Models.ciudadModel ciudad = JsonConvert.DeserializeObject<Models.ciudadModel>(json);
            return View(ciudad);
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
                var url = $"https://localhost:7196/ciudad/";
                var data = new StringContent(json, Encoding.UTF8, "Application/json");
                var api = new HttpClient();
                var response = await api.PostAsJsonAsync(url, data);
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
            var api = new HttpClient();
            var url = $"https://localhost:7196/ciudad/{id}";
            var json = await api.GetStringAsync(url);
            Models.ciudadModel ciudad = JsonConvert.DeserializeObject<Models.ciudadModel>(json);
            return View(ciudad);
        }

        // POST: CiudadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.ciudadModel ciudad)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ciudad);
                var url = $"https://localhost:7196/ciudad/{id}";
                var data = new StringContent(json, Encoding.UTF8, "Application/json");
                var api = new HttpClient();
                var response = await api.PutAsync(url, data);
                Console.WriteLine(response);
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
            var api = new HttpClient();
            var url = $"https://localhost:7196/ciudad/{id}";
            var json = await api.GetStringAsync(url);
            Models.ciudadModel ciudad = JsonConvert.DeserializeObject<Models.ciudadModel>(json);
            return View(ciudad);
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
                    var url = $"https://localhost:7196/ciudad/{id}";
                    var api = new HttpClient();
                    var response = await api.DeleteAsync(url);
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
