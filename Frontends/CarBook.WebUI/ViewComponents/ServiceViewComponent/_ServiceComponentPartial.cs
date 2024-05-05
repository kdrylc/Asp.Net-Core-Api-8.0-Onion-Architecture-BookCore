using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.ServiceViewComponent
{
    public class _ServiceComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7212/api/Services");
            if (responseM.IsSuccessStatusCode)
            {
                var jsonData = await responseM.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(val);
            }
            return View();
        }
    }
}
