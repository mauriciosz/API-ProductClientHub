﻿using System.Net;

namespace ProductClienteHub.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : ProductClienteHubException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrors()
        {
            return _errors;
        }

        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
