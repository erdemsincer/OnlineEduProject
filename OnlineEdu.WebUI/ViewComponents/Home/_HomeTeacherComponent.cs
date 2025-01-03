using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Services;

public class _HomeTeacherComponent : ViewComponent
{
    private readonly IUserService _userService;

    public _HomeTeacherComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _userService.Get4Teachers();
        return View(values);
    }
}
