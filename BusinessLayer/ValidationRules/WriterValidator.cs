using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı boş geçilemez.")
                                      .MinimumLength(4).WithMessage("Lütfen en az 4 karakter girişi yapınız.")
                                      .MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");

            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
                                     // .Matches(@"[a - z0 - 9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f]").WithMessage("Lütfen email adresinizi doğru giriniz.");

            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.")
                                      .MinimumLength(6).WithMessage("Lütfen en az 6 karakter girişi yapınız.")
                                      .MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız.")
                                      .Matches(@"[A-Z]+").WithMessage("Şifrede en az bir büyük harf olmalıdır.")
                                      .Matches(@"[a-z]+").WithMessage("Şifrede en az bir küçük harf olmalıdır.")
                                      .Matches(@"[0-9]+").WithMessage("Şifrede en az bir rakam olmalıdır");
        }

    }
}
