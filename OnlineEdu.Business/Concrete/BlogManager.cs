using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Concrete;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogrepository;

        public BlogManager(IRepository<Blog> _repository, IBlogRepository blogrepository) : base(_repository)
        {
            _blogrepository = blogrepository;
        }

        public List<Blog> Get4LastBlogsWithCategories()
        {
            return _blogrepository.Get4LastBlogsWithCategories();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _blogrepository.GetBlogsWithCategories();
        }

        public List<Blog> TGetBlogsWithCategoriesByWriterId(int id)
        {
            return _blogrepository.GetBlogsWithCategoriesByWriterId(id);
        }
    }
}
