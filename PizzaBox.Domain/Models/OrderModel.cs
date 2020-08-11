using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class OrderModel
  {
    public List<PizzaModel> Pizzas {get; set;}
    public int Id {get; set;}
    public string Details {get; set;}
    public DateTime Date {get; set;}
    public decimal OrderTotal {get; set;}

    // Method to compute total price
    public void ComputeTotal()
    {
      decimal total = 0m;

      // Foreach to iterate through pizzas and add price
      foreach (var p in Pizzas)
      {
        total += p.Price;
      }

      // Set OrderTotal = to the total we calculated above
      OrderTotal = total;
    }

    public void GetDetails()
    {
      var count = 0;
      foreach (var p in Pizzas)
      {
        count += 1;
      }
      Details = $"{count} items";
    }
  }
}