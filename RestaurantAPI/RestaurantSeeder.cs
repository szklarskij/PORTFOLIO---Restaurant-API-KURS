﻿using System.Collections;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;

namespace RestaurantAPI
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
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if(pendingMigrations != null && pendingMigrations.Any()) {
                    _dbContext.Database.Migrate();
                }


                if (!_dbContext.Roles.Any())
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
                    Name="User"
                },
                new Role()
                {
                    Name="Manager"
                },
                new Role()
                {
                    Name="Admin"
                },

            };
            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC is an American fast food restaurant",
                    ContactEmail = "contact@kfc.com",
                    ContactNumber = "123456789",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,

                        },
                        new Dish(){
                            Name = "Chicken Nuggets",
                            Price = 5.30M,

                        }
                    },
                    Adress = new Adress()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                }, new Restaurant()
                {
                    Name = "McDonald’s",
                    Category = "Fast Food",
                    Description = "McDonald’s is an American fast food restaurant",
                    ContactEmail = "contact@mcdonald.com",
                    ContactNumber = "123456789",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Big Mac",
                            Price = 8.30M,
 
                        },
                        new Dish(){
                            Name = "Cheeseburger",
                            Price = 5.30M,
  
                        }
                    },
                    Adress = new Adress()
                    {
                        City = "Warszawa",
                        Street = "Krótka 5",
                        PostalCode = "10-001"
                    }
                } };

                return restaurants;

        }
    }
}
