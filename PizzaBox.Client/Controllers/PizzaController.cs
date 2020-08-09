using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Linq;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller 
  {
    private readonly PizzaBoxDbContext _db;

    public PizzaController(PizzaBoxDbContext _dbContext)
    {
      _db = _dbContext;
    }
    [HttpGet()]
    public IActionResult Get()
    {
      ViewBag.PizzaList = _db.Pizzas.ToList();
      return View("Home2", _db.Pizzas.ToList());
    }
    [HttpGet("{id}")]
    public PizzaModel GetModel(int id)
    {
      return _db.Pizzas.ToList().SingleOrDefault(p=> p.Id == id);
    }
  }
}