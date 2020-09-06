using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id= 1, Name ="Oregano's", Location = "Goodyear", Cuisine = CuisineType.Italian },
                new Restaurant{Id= 2, Name ="Pei Wi", Location = "Avondale", Cuisine = CuisineType.Chinese },
                new Restaurant{Id= 3, Name ="Honey Bear's", Location = "Phoenix", Cuisine = CuisineType.BBQ }

            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants orderby r.Name select r;

        }
    }
}
