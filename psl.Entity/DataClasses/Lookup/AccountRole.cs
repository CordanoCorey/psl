using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class AccountRole : ILookup
    {
        public AccountRole()
        {
            AccountUsers = new HashSet<AccountUserXref>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }

        public virtual ICollection<AccountUserXref> AccountUsers { get; set; }
    }
}
