using ProductClienteHub.API.Entities;
using ProductClienteHub.API.Infra;
using ProductClienteHub.API.UseCases.Clientes.Validator;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Exceptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clientes.Register
{
    public class RegisterClientUseCases
    {
        public ResponseShortClientJson Execute(RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClienteHubDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email
            };


            dbContext.Clients.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortClientJson
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                // Essa linha abaixo faz a mesma coisa que TODO aquele código comentado abaixo faz!!!
                var listErrors = result.Errors.Select(x => x.ErrorMessage).ToList();

                #region
                /*
                var listErrors = new List<string>();
                if (result.Errors.Count > 0)
                {
                    foreach (var messageError in result.Errors)
                    {
                        listErrors.Add(messageError.ErrorMessage);
                    }
                }
                */
                #endregion

                throw new ErrorOnValidationException(listErrors);
            }
        }
    }
}
