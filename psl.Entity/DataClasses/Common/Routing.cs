using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class Routing
    {
        public Routing()
        {
        }

        public int Id { get; set; }
        public int CarrierId { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser LastModifiedBy { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual Location Origin { get; set; }
        public virtual Location Destination { get; set; }
    }
}
