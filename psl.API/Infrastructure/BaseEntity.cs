using System;
using System.Collections.Generic;
using System.Text;

namespace psl.API.Infrastructure
{
    // Authors: Royce Brown, Corey Gelbaugh
    // Description: The base entity class contains audit fields.
    public abstract class BaseEntity
    {
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastModifiedById { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
