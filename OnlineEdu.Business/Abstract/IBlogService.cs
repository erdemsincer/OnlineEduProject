using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetBlogsWithCategories();
        public List<Blog> TGetBlogsByCategoryId(int id);
        List<Blog> Get4LastBlogsWithCategories();
        List<Blog> TGetBlogsWithCategoriesByWriterId(int id);
        public Blog TGetBlogWithCategory(int id);
        
    }
}
