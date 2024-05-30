using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Abstractions;

namespace EconoTrack.Domain.Categories
{
    public class Category : Entity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        protected Category() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

    }
}
