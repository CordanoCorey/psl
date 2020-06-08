using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class Product
    {
        public Product()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser LastModifiedBy { get; set; }
        public virtual ICollection<OrderProductXref> Orders { get; set; }
    }
}
