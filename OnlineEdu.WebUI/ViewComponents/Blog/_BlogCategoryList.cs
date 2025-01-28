using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BlogCategoryDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogCategoryList:ViewComponent
    {
        private readonly HttpClient _httpClient=HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogCategories");
            var blogCategories = (from blogCategory in values

                                  select new BlogCategoryWithCountViewModel
                                  {
                                      BlogCount = blogCategory.Blogs.Count,
                                      CategoryName = blogCategory.Name,
                                      BlogCategoryId = blogCategory.BlogCategoryId
                                  }).ToList();

          return View(blogCategories);
        }
    }
}
