using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Factories;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Exchange.Concierge;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    public PizzaViewModel()
    {

    }

    [Required(ErrorMessage = "Please select a crust")]
    public string Crust { get; set; }

    [Required(ErrorMessage = "Please select a size")]
    public string Size { get; set; }

    [Required(ErrorMessage = "Please select a Pizza")]
    public string MenuItems { get; set; }

    // [DisplayName("Toppings")]
    // [Required(ErrorMessage = "Please select at least two toppings")]
    // [MinLength(_min_toppings, ErrorMessage = "Please select a minimum of {1} toppings")]
    // [MaxLength(_max_toppings, ErrorMessage = "Please select a maximum of {1} toppings")]
    // public List<string> SelectedToppings { get; set; }

    public const int _min_toppings = 2;

    public const int _max_toppings = 5;
  }
}