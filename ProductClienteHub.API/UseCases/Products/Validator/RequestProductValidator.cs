using FluentValidation;
using ProductClienteHub.Communication.Requests;

namespace ProductClienteHub.API.UseCases.Products.Validator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("O campo 'Nome' é obrigatório!");
            RuleFor(product => product.Marca).NotEmpty().WithMessage("O campo 'Marca' é obrigatório!");
            RuleFor(product => product.Preco).GreaterThan(0).WithMessage("'Preço' deve ser maior que zero!");
        }
    }
}
