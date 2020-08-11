using System;
using PizzaBox.Storing;
using PizzaBox.Storing.Factories;

namespace PizzaBox.Exchange.Concierge
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly PizzaBoxDbContext _context;
    public UnitOfWork(PizzaBoxDbContext context)
    {
      _context = context;
      MenuItems = new MenuFactory(_context);
      Pizzas = new PizzaFactory(_context);
      Sizes = new SizeFactory(_context);
      Crusts = new CrustFactory(_context);
      Toppings = new ToppingFactory(_context);
      Orders = new OrderFactory(_context);
    }

    public IMenuFactory MenuItems {get; set;}
    public IPizzaFactory Pizzas {get; private set;}
    public ISizeFactory Sizes {get; private set;}
    public ICrustFactory Crusts {get; private set;}
    public IToppingFactory Toppings {get; private set;}
    public IOrderFactory Orders {get; private set;}

    public int Complete()
    {
      return _context.SaveChanges();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}