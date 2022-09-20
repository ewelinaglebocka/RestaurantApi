using RestaurantApi.Entities;

namespace RestaurantApi
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name="Manager"
                },
                new Role()
                {
                    Name = "Admn"
                }
            };
            return roles;
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>();
            new Restaurant()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFC (short fot Kentucky Fried Chicken) is an American fast foof restaurant chain headquartered in..",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Nashville Hot Chicken",
                        Price = 10.30M,
                    },

                     new Dish()
                    {
                        Name = "Chicken Nuggets",
                        Price = 4.30M,
                    },
                },
                Address = new Address()
                {
                    City = "Kraków",
                    Street = "Długa 5",
                    PostalCode = "30-001"
                }

            };
             new Restaurant()
             {
                 Name = "KFC 2.0",
                 Category = "Fast Food",
                 Description = "KFC 2.0 (short fot Kentucky Fried Chicken) is an American fast foof restaurant chain headquartered in..",
                 ContactEmail = "contact2-0@kfc.com",
                 HasDelivery = true,
                 Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Nashville Hot Chicken 2.0",
                        Price = 10.30M,
                    },

                     new Dish()
                    {
                        Name = "Chicken Nuggets 2.0",
                        Price = 4.30M,
                    },
                },
                 Address = new Address()
                 {
                     City = "Warszawa",
                     Street = "Krótka 5",
                     PostalCode = "50-401"
                 }

             };
            return restaurants;
        }
    }
}
