using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Carriers
{
    public class CarrierModel : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbrevation { get; set; }
    }
}
