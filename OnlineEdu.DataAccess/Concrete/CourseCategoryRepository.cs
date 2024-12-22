using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(OnlineEduContext context) : base(context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var values = _context.CourseCategories.Find(id);
            values.IsShown = false;
            _context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var values = _context.CourseCategories.Find(id);
            values.IsShown = false;
            _context.SaveChanges();
        }
    }
}
