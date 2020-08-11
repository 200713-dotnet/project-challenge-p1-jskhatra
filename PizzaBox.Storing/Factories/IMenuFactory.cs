using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Factories
{
    public interface IMenuFactory : IFactory<MenuModel>
    {
        
    }
}