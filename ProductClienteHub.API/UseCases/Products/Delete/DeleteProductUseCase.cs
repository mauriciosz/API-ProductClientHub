using ProductClienteHub.API.Infra;
using ProductClienteHub.Exceptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClienteHubDbContext();
            var entity = dbContext.Products.FirstOrDefault(product => product.Id == id);

            if (entity == null)
                throw new NotFoundException("Produto não encontrado!");

            dbContext.Products.Remove(entity);
            dbContext.SaveChanges(); // faz a exclusão
        }
    }
}
