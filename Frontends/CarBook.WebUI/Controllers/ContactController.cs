using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto dto)
        {
            var cl = _httpClientFactory.CreateClient();
            dto.SendDate = DateTime.Now;
            var js = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(js,Encoding.UTF8,"application/json");
            var rm = await cl.PostAsync("https://localhost:7212/api/Contacts",content);
            if (rm.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
