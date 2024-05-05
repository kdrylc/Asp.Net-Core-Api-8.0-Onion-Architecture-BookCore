using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.TestimonialViewComponent
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7212/api/Testimonials");
            if (responseM.IsSuccessStatusCode)
            {
                var jsonData = await responseM.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(val);
            }
            return View();
        }
    }
}
