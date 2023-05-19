using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menus.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description) : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            var menuSection = new MenuSection(MenuSectionId.CreateUnique(), name, description);
            menuSection._items.AddRange(items); // Add the provided items to the Items list
            return menuSection;
        }


#pragma warning disable CS8618
        private MenuSection() { }
#pragma warning restore CS8618
    }
}
