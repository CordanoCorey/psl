using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class Location
    {
        public Location()
        {
            DestinationRoutings = new HashSet<Routing>();
            OriginRoutings = new HashSet<Routing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser LastModifiedBy { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<DealerLocationXref> Dealers { get; set; }
        public virtual ICollection<Routing> DestinationRoutings { get; set; }
        public virtual ICollection<Routing> OriginRoutings { get; set; }
    }
}
