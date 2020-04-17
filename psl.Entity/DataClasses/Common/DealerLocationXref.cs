using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class DealerLocationXref
    {
        public DealerLocationXref()
        {
        }

        public int Id { get; set; }
        public int DealerId { get; set; }
        public int LocationId { get; set; }

        public virtual Dealer Dealer { get; set; }
        public virtual Location Location { get; set; }
    }
}
