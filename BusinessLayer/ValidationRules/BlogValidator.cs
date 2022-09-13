using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
                .MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapınız.")
                .MinimumLength(10).WithMessage("Lütfen 4 karakterden daha fazla veri girişi yapınız.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik alanı boş geçilemez.");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Resim alanı boş geçilemez.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Bu alan boş geçilemez.");

        }

    }
}
