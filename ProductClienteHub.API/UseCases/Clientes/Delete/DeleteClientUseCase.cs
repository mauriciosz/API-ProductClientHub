using ProductClienteHub.API.Infra;
using ProductClienteHub.Exceptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clientes.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClienteHubDbContext();
            var entity = dbContext.Clients.FirstOrDefault(cliente => cliente.Id == id);

            if (entity == null)
                throw new NotFoundException("Cliente não encontrado!");

            //-- OBSERVAÇÃO --\\
            /* A Tabela "Products" foi criada como "CASCADE" para a Foreign Key ClientId, assim, 
             * ao deletar um CLiente todos os produtos que tiverem este cliente vinculado também 
             * serão deletados automaticamente...
            */

            dbContext.Clients.Remove(entity);
            dbContext.SaveChanges();        
        }
    }

}
