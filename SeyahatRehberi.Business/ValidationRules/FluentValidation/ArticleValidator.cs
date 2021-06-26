using FluentValidation;
using SeyahatRehberi.Entities.Concrete;

namespace SeyahatRehberi.Business.ValidationRules.FluentValidation
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(p => p.ArticleName).NotEmpty();
            RuleFor(p => p.ArticleName).MinimumLength(2);
            RuleFor(p => p.ArticleContent).NotEmpty();
        }
    }
}
