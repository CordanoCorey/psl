using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Widgets
{
    public class WidgetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string JustifyX { get; set; }
        public string JustifyY { get; set; }
        public double? OffsetX { get; set; }
        public double? OffsetY { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double ZIndex { get; set; }
    }
}
