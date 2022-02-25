using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcDeodorant.Data;
using System;
using System.Linq;

namespace MvcDeodorant.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDeodorantContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcDeodorantContext>>()))
            {
                // Look for any movies.
                if (context.Deodorant.Any())
                {
                    return;   // DB has been seeded
                }

                context.Deodorant.AddRange(
                    new Deodorant
                    {
                        Name = "mans choice",
                        ExpiredDate = DateTime.Parse("2026-2-12"),
                        Fragrance = "melody",
                        Quantity = 100,
                        Type = "Male" ,
                        Rating = "3"
                    }, 

                    new Deodorant
                    {
                        Name = "leadis odder",
                        ExpiredDate = DateTime.Parse("2023-2-10"),
                        Fragrance = "mild",
                        Quantity = 300,
                        Type = "Female",
                        Rating = "4"
                    },

                     new Deodorant
                     {
                         Name = "smells",
                         ExpiredDate = DateTime.Parse("2026-1-31"),
                         Fragrance = "cool",
                         Quantity = 250,
                         Type = "Male",
                         Rating = "3"
                     },
                        new Deodorant
                        {
                            Name = "boys",
                            ExpiredDate = DateTime.Parse("2025-2-08"),
                            Fragrance = "cool",
                            Quantity = 300,
                            Type = "Male",
                            Rating = "3"
                        },

                        new Deodorant
                        {
                            Name = "patel",
                            ExpiredDate = DateTime.Parse("2029-2-08"),
                            Fragrance = "mild",
                            Quantity = 300,
                            Type = "Male",
                            Rating = "3"
                        },

                        new Deodorant
                        {
                            Name = "males",
                            ExpiredDate = DateTime.Parse("2026-1-20"),
                            Fragrance = "cool",
                            Quantity = 300,
                            Type = "FemaleMale",
                            Rating = "3"
                        },
                        new Deodorant
                        {
                            Name = "girls",
                            ExpiredDate = DateTime.Parse("2020-2-06"),
                            Fragrance = "cool",
                            Quantity = 200,
                            Type = "Male",
                            Rating = "2"
                        },
                           new Deodorant
                           {
                               Name = "mens",
                               ExpiredDate = DateTime.Parse("2020-2-06"),
                               Fragrance = "cool",
                               Quantity = 300,
                               Type = "Male",
                               Rating = "5"
                           },
                             new Deodorant
                             {
                                 Name = "abc",
                                 ExpiredDate = DateTime.Parse("2026-2-09"),
                                 Fragrance = "cool",
                                 Quantity = 400,
                                 Type = "Male",
                                 Rating = "5"
                             },
                              new Deodorant
                              {
                                  Name = "xyz",
                                  ExpiredDate = DateTime.Parse("2027-2-09"),
                                  Fragrance = "cool",
                                  Quantity = 400,
                                  Type = "Male",
                                  Rating = "5"
                              }



                );
                context.SaveChanges();
            }
        }
    }
}