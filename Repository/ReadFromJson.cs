using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebAppHoreko.Models;

namespace WebAppHoreko.Repository
{ /*
    Repository class for reading from data (in this case JSON file)
  */
    public class ReadFromJson
    {
        public static List<Dish> LoadDishesJson()
        {
            using (StreamReader reader = new StreamReader("Data/dishes-sample-data.json"))
            {
                string json = reader.ReadToEnd();
                List<Dish> dishes = JsonConvert.DeserializeObject<List<Dish>>(json);
                return dishes;
            }
        }

        public static List<Ingredients> LoadIngredientsJson()
        {
            using (StreamReader reader = new StreamReader("Data/ingredients-sample-data.json"))
            {
                string json = reader.ReadToEnd();
                List<Ingredients> ingredients = JsonConvert.DeserializeObject<List<Ingredients>>(json);
                return ingredients;
            }
        }
    }
}
