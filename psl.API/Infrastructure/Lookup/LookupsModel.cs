using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using psl.Entity.DataClasses;

namespace psl.API.Infrastructure.Lookup
{
  public class LookupModel
  {
    public string Name { get; set; }
    public IEnumerable<ILookup> Values { get; set; }
  }
}
