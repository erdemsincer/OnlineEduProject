using OnlineEdu.WebUI.Dtos.CourseDtos;

namespace OnlineEdu.WebUI.Dtos.CourseVideoDtos
{
    public class ResultCourseVideoDto
    {
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }
    }
}
