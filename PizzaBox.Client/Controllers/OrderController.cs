using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Models;
using PizzaBox.Storing.Factories;
using PizzaBox.Storing;
using System.Collections.Generic;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaBoxDbContext _db;

    public OrderController(PizzaBoxDbContext _dbContext)
    {
      _db = _dbContext;
    }

    public IActionResult Home()
    {
      return View("Order", new PizzaViewModel());
    }
  }
}