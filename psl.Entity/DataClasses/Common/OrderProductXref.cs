using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class OrderProductXref
    {
        public OrderProductXref()
        {
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderProductXref> Orders { get; set; }
    }
}
