using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace api.segundoparcial.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public async Task<ActionResult> IndexAsync()
        {
            List<Models.clienteModel> clientes = new List<Models.clienteModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7196/clientes/1");
            Models.clienteModel cliente = JsonConvert.DeserializeObject<Models.clienteModel>(json);
            clientes.Add(cliente);
            return View();
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            List<Models.clienteModel> clientes = new List<Models.clienteModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7196/clientes/{id}");
            Models.clienteModel cliente = JsonConvert.DeserializeObject<Models.clienteModel>(json);
            clientes.Add(cliente);
            return View();
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
                var data = new StringContent(json, Encoding.UTF8, "Application/json");
                var api = new HttpClient();
                var response = await api.PostAsync("https://localhost:7261/Clientes/", data);
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
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
                    var api = new HttpClient();
                    var response = await api.DeleteAsync("https://localhost:7261/Clientes/{id}");
                }
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
