using ProductClienteHub.API.Infra;
using ProductClienteHub.Communication.Responses;

namespace ProductClienteHub.API.UseCases.Clientes.GetAll
{
    public class GetAllClientUseCase
    {
        public ResponseAllClientJson Execute()
        {
            var dbContext = new ProductClienteHubDbContext();
            var clients = dbContext.Clients.ToList();

            return new ResponseAllClientJson
            {
                Clients = clients.Select(cliente => new ResponseShortClientJson
                {
                    Id = cliente.Id,
                    Name = cliente.Name,
                }).ToList()
            };

        }
    }
}
