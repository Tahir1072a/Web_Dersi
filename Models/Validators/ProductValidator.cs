using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email bos olamaz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen doğru bir email adresi giriniz.");
            RuleFor(x => x.Name).NotNull().WithMessage("Name bos olamaz!").NotEmpty().WithMessage("Name boş olmaz");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Product name 100 karakteri gecemez!!!");
        }
    }
}
