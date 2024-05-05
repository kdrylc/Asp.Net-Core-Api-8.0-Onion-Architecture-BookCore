using CarBook.Dto.BannerDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponent
{
    public class _DefaultCoverUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clF;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory clF)
        {
            _clF = clF;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clF.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7212/api/Banners");
            if (responseM.IsSuccessStatusCode)
            {
                var jsonData = await responseM.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<BannerDto>>(jsonData);
                return View(val);
            }
            return View();
        }
    }
}
