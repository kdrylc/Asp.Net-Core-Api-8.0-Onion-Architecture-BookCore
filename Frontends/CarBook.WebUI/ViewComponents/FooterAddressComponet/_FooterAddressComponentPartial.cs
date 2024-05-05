using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAddressComponet
{
    public class _FooterAddressComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cl = _httpClientFactory.CreateClient();
            var rM = await cl.GetAsync("https://localhost:7212/api/FooterAddresses");
            if (rM.IsSuccessStatusCode) 
            { 
                var jsDt = await rM.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<FooterAddressDto>>(jsDt);
                return View(val);
            }
            return View();
        }

    }
}
