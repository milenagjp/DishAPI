using Newtonsoft.Json;

namespace WebAppHoreko.Models
{
    /*
    Model class for representation of a single IngredientsUsageResponse from Json object 
    */
    public class IngredientsUsageResponse
    {
        [JsonProperty("Id")]
        public int id { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("TotalAmount")]
        public double totalAmount { get; set; }

        [JsonProperty("NumberOfDishes")]
        public int numberOfDishes { get; set; }
    }
}
