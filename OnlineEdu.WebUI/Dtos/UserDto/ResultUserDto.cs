using OnlineEdu.WebUI.Dtos.TeacherSocialDtos;

namespace OnlineEdu.WebUI.Dtos.UserDto
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        public List<ResultTeacherSocialDto> TeacherSocials { get; set; }
    }
}
