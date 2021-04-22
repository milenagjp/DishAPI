using Newtonsoft.Json;

namespace WebAppHoreko.Models
{
    /*
     Model class for representation of a single DishPriceResponse from Json object 
    */
    public class DishPriceResponse
    {
        [JsonProperty("Id")]
        public int id { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("Price")]
        public double price { get; set; }

    }
}
