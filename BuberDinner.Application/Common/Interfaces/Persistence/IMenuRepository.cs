using BuberDinner.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(Menu menu); 
    }
}
