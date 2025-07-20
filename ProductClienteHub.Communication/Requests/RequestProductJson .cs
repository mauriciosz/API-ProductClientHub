using System;

namespace ProductClienteHub.Communication.Requests
{
    public  class RequestProductJson
    {
        public string Name { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}
