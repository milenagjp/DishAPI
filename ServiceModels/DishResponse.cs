using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebAppHoreko.Models
{ /*
    Model class for representation of a single DishResponse and IngredientRespons from Json object 
  */
    public class DishResponse
    {
        [JsonProperty("Id")]
        public int id { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("LastUpdatedOn")]
        public DateTime lastupdatedOn { get; set; }

        [JsonProperty("Ingredients")]
        public List<IngredientResponse> ingredients { get; set; }
    }
    public class IngredientResponse
    {
        [JsonProperty("Id")]
        public int id { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }
    }
}
