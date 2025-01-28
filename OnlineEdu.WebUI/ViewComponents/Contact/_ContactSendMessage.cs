using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Contact
{
    public class _ContactSendMessage:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
