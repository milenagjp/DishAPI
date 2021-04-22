using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace WebAppHoreko.Exceptions
{   /*
    Class for handling with 409 exception.
    */
    public class ExceptionHandler
    {
        [JsonProperty("StatusCode")]
        public int statusCode { get; set; }

        [JsonProperty("Message")]
        public string message { get; set; }


        public static JArray getException(string message)
        {
            ExceptionHandler e = new ExceptionHandler();
            e.statusCode = 409;
            e.message = message;
            List<ExceptionHandler> ex = new List<ExceptionHandler>();
            ex.Add(e);
            string js = JsonConvert.SerializeObject(ex);
            return JArray.Parse(js);
        }
    }
}