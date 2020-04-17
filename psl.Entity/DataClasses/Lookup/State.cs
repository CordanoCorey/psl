using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class State : ILookup
    {
        public State()
        {
            Locations = new HashSet<Location>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
