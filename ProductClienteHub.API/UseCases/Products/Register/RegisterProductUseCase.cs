using ProductClienteHub.API.Entities;
using ProductClienteHub.API.Infra;
using ProductClienteHub.API.UseCases.Products.Validator;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Exceptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(Guid ClientId, RequestProductJson request)
        {
            var dbContext = new ProductClienteHubDbContext();

            Validate(ClientId, dbContext, request);

            var entity = new Product
            {
                ClientId = ClientId,
                Name = request.Name,
                Brand = request.Marca, // Corrigir, no Banco de Dados não está "Marca"
                Price = request.Preco
            };

            dbContext.Products.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = entity.Id,
                Name = entity.Name,
            };        
        }

        private void Validate(Guid ClientId, ProductClienteHubDbContext dbContext, RequestProductJson request)
        {
            var ClienteExist = dbContext.Clients.Any(x => x.Id == ClientId);
            if (!ClienteExist)
                throw new NotFoundException("Cliente não encontrado!");

            var validate = new RequestProductValidator();
            var result = validate.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
