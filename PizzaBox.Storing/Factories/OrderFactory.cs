using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaBox.Storing.Factories
{
    public class OrderFactory : Factory<OrderModel>, IOrderFactory
    {
        public OrderFactory(PizzaBoxDbContext context) : base(context)
        {

        }

        public PizzaBoxDbContext PizzaBoxDbContext
        {
            get { return Context as PizzaBoxDbContext; }
        }
    }
}