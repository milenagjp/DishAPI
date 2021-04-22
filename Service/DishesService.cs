using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using WebAppHoreko.Models;
using System;
using WebAppHoreko.Exceptions;
using WebAppHoreko.Repository;

namespace WebAppHoreko.Service
{ /*
    Service class for business logic and communication with controller
  */
    public class DishesService
    {
        public JArray getAllDishes(List<Dish> dishes, List<Ingredients> ingredients)
        {
            /*
             * return JArray with all the dishes, sorted by name and lastupdatedOn
             */

            List<DishResponse> dishResponsesList = new List<DishResponse>();

            foreach (Dish dish in dishes)
            {
                DishResponse dishResponse = new DishResponse();

                List<IngredientResponse> ingredientResponseList = new List<IngredientResponse>();

                dishResponse.id = dish.id;
                dishResponse.name = dish.name;
                dishResponse.lastupdatedOn = dish.updatedOn;

                foreach (Ingredient ingredient in dish.ingredients)
                {
                    if (ingredients.Exists(x => x.id == ingredient.ingredientId))
                    {
                        Ingredients current = ingredients.Find(x => x.id == ingredient.ingredientId);

                        IngredientResponse ingredientResponse = new IngredientResponse();

                        ingredientResponse.id = current.id;
                        ingredientResponse.name = current.name;

                        ingredientResponseList.Add(ingredientResponse);

                    }

                }
                dishResponse.ingredients = ingredientResponseList;
                dishResponsesList.Add(dishResponse);
            }

            List<DishResponse> filterList = dishResponsesList.OrderBy(x => x.name).ThenBy(x => x.lastupdatedOn).ToList();
            string json = JsonConvert.SerializeObject(filterList);

            return JArray.Parse(json);
        }

        public JArray getDishesById(List<Dish> dishes, List<Ingredients> ingredients, int id)
        {
            /*
             * return JArray with dish by id, if does not exits return error
             */

            DishByIdResponse dishByIdResponse = new DishByIdResponse();
            List<DishByIdResponse> list = new List<DishByIdResponse>();
            List<ParentDish> listParentDish = new List<ParentDish>();

            if (dishes.Exists(x => x.id == id))
            {
                Dish dish = dishes.Find(x => x.id == id);

                dishByIdResponse.id = dish.id;
                dishByIdResponse.name = dish.name;
                dishByIdResponse.lastupdatedOn = dish.updatedOn;

                ParentDish parentDish = new ParentDish();

                parentDish.id = dish.parentId;

                Dish parent = dishes.Find(x => x.id == dish.parentId);

                parentDish.name = parent.name;

                listParentDish.Add(parentDish);

                dishByIdResponse.parentDish = listParentDish;

                List<IngredientsResponse> ingredientResponseList = new List<IngredientsResponse>();

                foreach (Ingredient i in dish.ingredients)
                {
                    IngredientsResponse ingredientResponse = new IngredientsResponse();

                    Ingredients ingredient = ingredients.Find(x => x.id == i.ingredientId);

                    ingredientResponse.id = ingredient.id;
                    ingredientResponse.name = ingredient.name;
                    ingredientResponse.amount = i.amount;

                    ingredientResponseList.Add(ingredientResponse);
                    dishByIdResponse.ingredients = ingredientResponseList;
                }

                list.Add(dishByIdResponse);

                string json = JsonConvert.SerializeObject(list);
                return JArray.Parse(json);
            }
            else
            {
                string message = "Dish with id: " + id + " is not found";
                return ExceptionHandler.getException(message);

            }
        }

        public JArray addNewDish(List<Dish> dishes, List<Dish> dishList)
        {
            /*
             * return JArray with inserted dishId, validations and error handling
             */

            Dish dish = dishList[0];
            if (!dishes.Exists(x => x.name == dish.name)) //checking if unique name
            {
                if (dish.name != null && dish.name != "")//checking if not empty
                {
                    Dish newDish = new Dish();

                    if (!(dish.name.Length > 50))//checking length
                    {

                        if (dish.ingredients == null || dish.ingredients.Count == 0)//checking ingredients
                        {
                            string message = "Dish must contain at least one ingredient!";
                            return ExceptionHandler.getException(message);

                        }
                        else
                        {
                            newDish = dish;
                            dishes.Add(newDish);

                            List<Dish> filterList = dishes.OrderBy(x => x.id).ToList();
                            WriteToJson.LoadDishesJson(filterList);

                            List<int> newList = new List<int>();
                            newList.Add(dish.id);

                            string js = JsonConvert.SerializeObject(newList);
                            return JArray.Parse(js);
                        }
                    }
                    else
                    {
                        string message = "Dish name cannot be more than 50 characters!";
                        return ExceptionHandler.getException(message);
                    }

                }
                else
                {
                    string message = "Dish name cannot be empty!";
                    return ExceptionHandler.getException(message);
                }
            }
            else
            {
                string message = "Dish with name: " + dish.name + " already exists";
                return ExceptionHandler.getException(message);
            }

        }

        public JArray getPrice(List<Dish> dishes, List<Ingredients> ingredients)
        {
            /*
             * return JArray with dishes and total cost
             */

            List<DishPriceResponse> dishResponsesList = new List<DishPriceResponse>();
            double sumPrice = 0.0;

            foreach (Dish dish in dishes)
            {
                DishPriceResponse dishResponse = new DishPriceResponse();

                dishResponse.id = dish.id;
                dishResponse.name = dish.name;

                foreach (Ingredient ingredient in dish.ingredients)
                {
                    if (ingredients.Exists(x => x.id == ingredient.ingredientId))
                    {
                        Ingredients current = ingredients.Find(x => x.id == ingredient.ingredientId);
                        sumPrice += current.price * ingredient.amount;
                    }

                }
                dishResponse.price = Math.Round(sumPrice, 2);
                dishResponsesList.Add(dishResponse);
            }

            string json = JsonConvert.SerializeObject(dishResponsesList);
            return JArray.Parse(json);
        }

        public JArray getIngredients(List<Dish> dishes, List<Ingredients> ingredients)
        {
            /*
            * return JArray with ingredients, totalAmount and numberOfDishes
            */

            List<IngredientsUsageResponse> ingredientsUsageResponses = new List<IngredientsUsageResponse>();

            foreach (Ingredients ingredient in ingredients)
            {
                IngredientsUsageResponse response = new IngredientsUsageResponse();
                int counter = 0;
                double totalAmount = 0.0;
                foreach (Dish dish in dishes)
                {
                    if (dish.ingredients.Exists(x => x.ingredientId == ingredient.id))
                    {
                        counter++;
                        Ingredient current = dish.ingredients.Find(x => x.ingredientId == ingredient.id);

                        totalAmount += current.amount * ingredient.price;

                    }
                    response.id = ingredient.id;
                    response.name = ingredient.name;
                }
                response.numberOfDishes = counter;
                response.totalAmount = Math.Round(totalAmount, 2);
                ingredientsUsageResponses.Add(response);
            }

            string json = JsonConvert.SerializeObject(ingredientsUsageResponses);
            return JArray.Parse(json);
        }
    }
}
