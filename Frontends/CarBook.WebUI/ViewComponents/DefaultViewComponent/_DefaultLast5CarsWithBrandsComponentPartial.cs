using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponent
{
    public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7212/api/Cars/GetLast5CarsWithBrandQueryHandler");
            if (responseM.IsSuccessStatusCode)
            {
                var jsonData = await responseM.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<Last5CarDto>>(jsonData);
                return View(val);
            }
            return View();
        }
    }
}
