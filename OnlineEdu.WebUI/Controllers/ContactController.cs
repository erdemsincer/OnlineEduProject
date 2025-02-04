﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.ContactDtos;
using OnlineEdu.WebUI.Dtos.MessageDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<   IActionResult >IndexAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            ViewBag.map = values.Select(x => x.MapUrl).FirstOrDefault();
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("messages", createMessageDto);
            return NoContent();
        }

       
    }
}
