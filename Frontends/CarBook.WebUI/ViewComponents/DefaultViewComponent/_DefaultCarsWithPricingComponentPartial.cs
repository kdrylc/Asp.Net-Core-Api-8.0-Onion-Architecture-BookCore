using CarBook.Dto.BannerDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponent
{
    public class _DefaultCarsWithPricingComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clF;

        public _DefaultCarsWithPricingComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _clF = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
             var client = _clF.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7212/api/Cars/GetCarWithPricingList");
            if (responseM.IsSuccessStatusCode)
            {
                var jsonData = await responseM.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<CarPricingWithCarDto>>(jsonData);
                return View(val);
            }
            return View();
        }
    }
}
