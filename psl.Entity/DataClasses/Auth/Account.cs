using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class Account
    {
        public Account()
        {
            PrimaryAccountUsers = new HashSet<ApplicationUser>();
            Users = new HashSet<AccountUserXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> PrimaryAccountUsers { get; set; }
        public virtual ICollection<AccountUserXref> Users { get; set; }
    }
}
