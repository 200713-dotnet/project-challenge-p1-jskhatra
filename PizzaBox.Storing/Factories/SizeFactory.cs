using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaBox.Storing.Factories
{
    public class SizeFactory : Factory<SizeModel>, ISizeFactory
    {
        public SizeFactory(PizzaBoxDbContext context) : base(context)
        {

        }

        public PizzaBoxDbContext PizzaBoxDbContext
        {
            get { return Context as PizzaBoxDbContext; }
        }
    }
}