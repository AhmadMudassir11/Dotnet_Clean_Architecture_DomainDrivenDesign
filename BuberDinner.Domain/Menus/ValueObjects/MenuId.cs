﻿using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menus.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuId Create(Guid value)
        {
            return new MenuId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value ;
        }
    }
}
