using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaBox.Storing.Factories
{
    public class MenuFactory : Factory<MenuModel>, IMenuFactory
    {
        public MenuFactory(PizzaBoxDbContext context) : base(context)
        {

        }



        public PizzaBoxDbContext PizzaBoxDbContext
        {
            get { return Context as PizzaBoxDbContext; }
        }
    }
}