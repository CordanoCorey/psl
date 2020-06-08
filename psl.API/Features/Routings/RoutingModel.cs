using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Routings
{
    public class RoutingModel : BaseEntity
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string DestinationCity { get; set; }
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public int DestinationStateId { get; set; }
        public string DestinationStateName { get; set; }
        public DateTime? EndTime { get; set; }
        public string OriginCity { get; set; }
        public int OriginId { get; set; }
        public string OriginName { get; set; }
        public int OriginStateId { get; set; }
        public string OriginStateName { get; set; }
        public DateTime StartTime { get; set; }
    }
}
