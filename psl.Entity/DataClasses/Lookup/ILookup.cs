using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
  public interface ILookup
  {
    int Id { get; set; }
    string Name { get; set; }
    bool IsActive { get; set; }
    int Sort { get; set; }
  }
}
