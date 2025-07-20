using ProductClienteHub.API.Infra;
using ProductClienteHub.API.UseCases.Clientes.Validator;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Exceptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clientes.Update
{
    public class UpdateClientUseCases
    {
        public void Execute(Guid ClientId, RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClienteHubDbContext();

            var entity = dbContext.Clients.FirstOrDefault(x => x.Id == ClientId);

            if (entity == null)
                throw new NotFoundException("Cliente não encontrado!");

            entity.Name = request.Name;
            entity.Email = request.Email;

            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();            
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }

        }
    }
}
