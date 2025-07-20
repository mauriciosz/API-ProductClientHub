using FluentValidation;
using ProductClienteHub.Communication.Requests;

namespace ProductClienteHub.API.UseCases.Clientes.Validator
{
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("Campo 'Nome' é obrigatório!");
            RuleFor(client => client.Email).NotEmpty().WithMessage("Campo 'E-mail' é obrigatório!")
                                           .EmailAddress().WithMessage("O E-mail digitado não é válido!");
                                           
        }
    }
}
