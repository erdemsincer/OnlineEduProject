using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.CourseDtos;

namespace OnlineEdu.WebUI.Dtos.CourseRegisterDto
{
    public class CreateCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
    }
}
