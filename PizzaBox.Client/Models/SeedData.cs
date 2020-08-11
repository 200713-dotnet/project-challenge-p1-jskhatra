using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using domain = PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new PizzaBoxDbContext(serviceProvider.GetRequiredService<DbContextOptions<PizzaBoxDbContext>>()))
      {
        if (!context.Crusts.Any())
        {
          context.Crusts.AddRange(new domain.CrustModel { Name = "Thin" },
                                                    new domain.CrustModel { Name = "Stuffed" },
                                                    new domain.CrustModel { Name = "Deep-Dish" }
                                                    );
        }

        if (!context.Sizes.Any())
        {
          context.Sizes.AddRange(new domain.SizeModel { Name = "Small" },
                                                    new domain.SizeModel { Name = "Medium" },
                                                    new domain.SizeModel { Name = "Large" }
                                                    );
        }


        if (!context.Toppings.Any())
        {
          context.Toppings.AddRange(new domain.ToppingModel { Name = "Cheese" },
                                                          new domain.ToppingModel { Name = "Pepperoni" },
                                                          new domain.ToppingModel { Name = "Canadian Bacon" },
                                                          new domain.ToppingModel { Name = "Pineapples" },
                                                          new domain.ToppingModel { Name = "Olives" },
                                                          new domain.ToppingModel { Name = "Mushrooms" }
                                                        );
        }

        if (!context.MenuItems.Any())
        {
          context.MenuItems.AddRange(
                                                            new domain.MenuModel { Name = "Cheese", isSpecialtyItem = false },
                                                            new domain.MenuModel { Name = "Veggie", isSpecialtyItem = false },
                                                            new domain.MenuModel { Name = "Meat Lover", isSpecialtyItem = false },
                                                            new domain.MenuModel { Name = "Supreme", isSpecialtyItem = false },
                                                            new domain.MenuModel { Name = "Custom", isSpecialtyItem = true }
                                                          );
        }
        context.SaveChanges();
      }
    }
  }
}