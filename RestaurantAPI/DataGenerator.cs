using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class DataGenerator
    {
        public static void Seed(RestaurantDbContext dbContext)
        {
            var locale = "pl";
            var adressGenerator = new Faker<Adress>(locale)
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());


            var restaurantGenerator = new Faker<Restaurant>(locale)
                .RuleFor(a => a.Name, f => f.Lorem.Word())
                .RuleFor(a => a.Description, f => f.Lorem.Paragraph(5))
                .RuleFor(a => a.HasDelivery, f => f.Random.Bool())
                .RuleFor(a => a.ContactNumber, f => f.Person.Phone)
                .RuleFor(a => a.ContactEmail, f => f.Person.Email)
                .RuleFor(a => a.Adress, f => adressGenerator.Generate());


            var restaurants = restaurantGenerator.Generate(5000);

            dbContext.AddRange(restaurants);
           dbContext.SaveChanges();


        }

    }
}
