using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
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

        public  Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   orderby r.Name
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
                   
                   ;

        }
    }
}
