using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductClienteHub.Exceptions.ExceptionsBase
{
    public class NotFoundException : ProductClienteHubException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }

        public override List<string> GetErrors()
        {
            return new List<string>([Message]);
        }

        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}
