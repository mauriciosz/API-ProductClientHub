using System.Collections.Generic;

namespace ProductClienteHub.Communication.Responses
{
    public class ResponseErrorMessageJson
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMessageJson(string message)
        {
            Errors = new List<string> { message };
            
            /*
                No C# 7 (esse que estou) não aceita isso "Errors = [message];", mas no 12 pra cima
                dava para simplificar o código assim...
            */
        }

        public ResponseErrorMessageJson(List<string> messages)
        {
            Errors = messages;
        }
    }
}
