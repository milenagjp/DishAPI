using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebAppHoreko.Models;

namespace WebAppHoreko.Repository
{ /*
    Repository class for writing to data (in this case JSON file)
  */
    public class WriteToJson
    {
        public static void LoadDishesJson(List<Dish> dishes)
        {

            using (StreamWriter writer = new StreamWriter("Data/new-dishes-data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                serializer.Serialize(writer, dishes);

            }
        }

    }
}
