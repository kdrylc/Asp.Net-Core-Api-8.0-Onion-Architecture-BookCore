﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.BlogDtos;
using CarBook.Dto.TestimonialDtos;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _GetLast3BlogsWithAuthorListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7212/api/Blogs/GetLast3BlogsWitAuthorsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
