using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menus.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; }

        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuSectionId Create(Guid value)
        {
            return new MenuSectionId(value);
        }
    }
}