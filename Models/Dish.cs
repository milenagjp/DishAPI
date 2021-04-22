using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace WebAppHoreko.Models
{  /*
    Model class for representation of a single Dish and Ingredient from Json object 
  */
    public class Dish
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("parentId")]
        public int? parentId { get; set; }

        [JsonProperty("updatedOn")]
        public DateTime updatedOn { get; set; }

        [JsonProperty("ingredients")]
        public List<Ingredient> ingredients { get; set; }

    }

    public class Ingredient
    {
        [JsonProperty("ingredientId")]
        public int ingredientId { get; set; }

        [JsonProperty("amount")]
        public double amount { get; set; }
    }

}