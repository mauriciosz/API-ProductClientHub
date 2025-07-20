using System.Net;

namespace ProductClienteHub.Exceptions.ExceptionsBase
{
    public abstract class ProductClienteHubException : SystemException
    {
        public ProductClienteHubException(string errorMessage) : base(errorMessage)
        {            
        }
        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
