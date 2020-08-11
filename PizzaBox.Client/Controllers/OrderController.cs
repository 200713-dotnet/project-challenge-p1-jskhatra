using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Models;
using PizzaBox.Storing.Factories;
using PizzaBox.Exchange.Concierge;
using PizzaBox.Storing;
using System.Collections.Generic;
using System;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaBoxDbContext _db;

    public OrderController(PizzaBoxDbContext _dbContext)
    {
      _db = _dbContext;
    }

    public IActionResult Orders()
    {
      UnitOfWork unitOfWork = new UnitOfWork(_db);
      ViewBag.Orders = unitOfWork.Orders.GetAll();
      return View("OrderHistory", new OrderViewModel());
    }

    public IActionResult AddPizza()
    {
      UnitOfWork unitOfWork = new UnitOfWork(_db);

      ViewBag.MenuItems = unitOfWork.MenuItems.GetAll();
      ViewBag.Sizes = unitOfWork.Sizes.GetAll();
      ViewBag.Crusts = unitOfWork.Crusts.GetAll();
      ViewBag.Toppings = unitOfWork.Toppings.GetAll();

      return View("AddPizza", new PizzaViewModel());
    }

    [HttpPost]
    public IActionResult PlaceOrder(PizzaViewModel model)
    {
      UnitOfWork unitOfWork = new UnitOfWork(_db);

      ViewBag.MenuItems = unitOfWork.MenuItems.GetAll();
      ViewBag.Sizes = unitOfWork.Sizes.GetAll();
      ViewBag.Crusts = unitOfWork.Crusts.GetAll();
      ViewBag.Toppings = unitOfWork.Toppings.GetAll();
      ViewBag.Orders = unitOfWork.Orders.GetAll();

      if (ModelState.IsValid)
      {
        List<PizzaModel> pizzas = new List<PizzaModel>();
        pizzas.Add(new PizzaModel{ Name = model.MenuItems, Price = 9.99m });

        OrderModel order = new OrderModel();
        order.Pizzas = pizzas;
        order.ComputeTotal();
        order.GetDetails();
        order.Date = DateTime.Now;

        unitOfWork.Orders.Add(order);
        unitOfWork.Complete();
        unitOfWork.Dispose();

        return RedirectToAction("Orders");
      }


      return View("AddPizza", model);
    }

    public IActionResult OrderDetails()
    {
      UnitOfWork unitOfWork = new UnitOfWork(_db);
      ViewBag.Pizzas = unitOfWork.Pizzas.GetAll();
  
      return View("Details");
    }
  }
}