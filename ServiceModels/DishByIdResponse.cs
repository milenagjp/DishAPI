using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebAppHoreko.Models
{
    /*
    Model class for representation of a single DishByIdResponse, ParentDish and IngredientsResponse from Json object 
    */
    public class DishByIdResponse
    {
        [JsonProperty("Id")]
        public int id { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("LastUpdatedOn")]
        public DateTime lastupdatedOn { get; set; }

        [JsonProperty("ParentDish")]
        public List<ParentDish> parentDish { get; set; }

        [JsonProperty("Ingredients")]
        public List<IngredientsResponse> ingredients { get; set; }
    }

    public class ParentDish
    {
        [JsonProperty("Id")]
        public int? id { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }
    }

    public class IngredientsResponse
    {
        [JsonProperty("Id")]
        public int id { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("Amount")]
        public double amount { get; set; }

    }
}
