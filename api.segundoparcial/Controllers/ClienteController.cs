using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Diagnostics;
using System.Text;

namespace api.segundoparcial.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var api = new HttpClient();
            var url = $"https://localhost:7196/cliente/";
            var json = await api.GetAsync(url);
            var result = await json.Content.ReadAsStringAsync();
            IEnumerable<Models.clienteModel> clientes = JsonConvert.DeserializeObject<IEnumerable<Models.clienteModel>>(result);
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var api = new HttpClient();
            var url = $"https://localhost:7196/cliente/{id}";
            var json = await api.GetStringAsync(url);
            Models.clienteModel cliente = JsonConvert.DeserializeObject<Models.clienteModel>(json);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.clienteModel cliente)
        {
            try
            {
                var json = JsonConvert.SerializeObject(cliente);
                var url = $"https://localhost:7196/cliente/";
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

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var api = new HttpClient();
            var url = $"https://localhost:7196/cliente/{id}";
            var json = await api.GetStringAsync(url);
            Models.clienteModel cliente = JsonConvert.DeserializeObject<Models.clienteModel>(json);
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.clienteModel cliente)
        {
            try
            {
                var json = JsonConvert.SerializeObject(cliente);
                var url = $"https://localhost:7196/cliente/{id}";
                var data = new StringContent(json, Encoding.UTF8, "Application/json");
                var api = new HttpClient();
                var response = await api.PutAsync(url, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var api = new HttpClient();
            var url = $"https://localhost:7196/cliente/{id}";
            var json = await api.GetStringAsync(url);
            Models.clienteModel cliente = JsonConvert.DeserializeObject<Models.clienteModel>(json);
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {  
                if (id > 0) 
                {
                    var url = $"https://localhost:7196/cliente/{id}";
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
