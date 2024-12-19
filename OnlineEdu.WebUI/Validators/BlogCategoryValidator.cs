using FluentValidation;
using OnlineEdu.WebUI.Dtos.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Blog Category Adı Boş bırakılamaz");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Blog kategori Adı en fazla 30 karekter olmalıdır");
        }
    }
}
