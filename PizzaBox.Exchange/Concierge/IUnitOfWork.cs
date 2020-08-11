using System;
using PizzaBox.Storing.Factories;

namespace PizzaBox.Exchange.Concierge
{
  public interface IUnitOfWork : IDisposable
  {
    IPizzaFactory Pizzas {get;}
    ISizeFactory Sizes{get;}
    ICrustFactory Crusts {get;}
    IToppingFactory Toppings {get;}
    IMenuFactory MenuItems {get;}
    int Complete();
  }
}