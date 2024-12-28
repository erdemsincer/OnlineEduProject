using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.AboutDto;
using OnlineEdu.WebUI.Dtos.BlogCategoryDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Validators;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class BlogCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task< IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
            return View(values);
        }
        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _client.DeleteAsync($"blogcategories/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult CreateBlogCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto createBlogCategoryDto)
        {

            var validator=new BlogCategoryValidator();
            var result= await validator.ValidateAsync(createBlogCategoryDto);
            if (!result.IsValid)
                    { 
                    foreach(var x  in result.Errors) {
                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
                    }
            return View();
            }
            await _client.PostAsJsonAsync("blogcategories", createBlogCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBlogCategoryDto>($"blogcategories/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            await _client.PutAsJsonAsync("blogcategories", updateBlogCategoryDto);
            return RedirectToAction("Index");
        }
    }
}
