using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class AccountUserXref
    {
        public AccountUserXref()
        {
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
