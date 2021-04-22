using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebAppHoreko.Models;
using WebAppHoreko.Repository;
using WebAppHoreko.Service;

namespace WebAppHoreko.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class DishesController : ControllerBase
    {
        private List<Dish> dishesList = ReadFromJson.LoadDishesJson();
        private List<Ingredients> ingredientsList = ReadFromJson.LoadIngredientsJson();
        private DishesService dishesService = new DishesService();

        [HttpGet]
        [Route("dishes")]
        [Produces("application/json")]
        public ActionResult<JArray> Get()
        {
            return dishesService.getAllDishes(dishesList, ingredientsList);
        }

        // GET api/dishes/{id}
        [HttpGet("dishes/{id}")]
        [Produces("application/json")]
        public ActionResult<JArray> Get(int id)
        {
            return dishesService.getDishesById(dishesList, ingredientsList, id);
        }

        // POST api/dishes
        [HttpPost]
        [Route("dish")]
        public ActionResult<JArray> Post([FromBody] List<Dish> dish)
        {
            return dishesService.addNewDish(dishesList, dish);
        }

        // GET api/dishes/prices
        [HttpGet]
        [Route("dishes/prices")]
        [Produces("application/json")]
        public ActionResult<JArray> Get(int id, float prices)
        {
            return dishesService.getPrice(dishesList, ingredientsList);
        }

        // GET api/dishes/ingredients/usage
        [HttpGet]
        [Route("ingredients/usage")]
        [Produces("application/json")]
        public ActionResult<JArray> Get(int ingredients, int prices)
        {
            return dishesService.getIngredients(dishesList, ingredientsList);
        }
    }
}
