using Newtonsoft.Json;

namespace WebAppHoreko.Models
{
    /*
     Model class for representation of a single Ingredient from Json object 
   */
    public class Ingredients
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("price")]
        public double price { get; set; }

    }
}