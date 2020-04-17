using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace psl.Entity.DataClasses
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
        }

        public int PrimaryAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordResetCode { get; set; }

        public virtual Account PrimaryAccount { get; set; }
        public virtual ICollection<AccountUserXref> Accounts { get; set; }
        public virtual ICollection<Carrier> CarrierCreatedBy { get; set; }
        public virtual ICollection<Carrier> CarrierLastModifiedBy { get; set; }
        public virtual ICollection<Dealer> DealerCreatedBy { get; set; }
        public virtual ICollection<Dealer> DealerLastModifiedBy { get; set; }
        public virtual ICollection<Location> LocationCreatedBy { get; set; }
        public virtual ICollection<Location> LocationLastModifiedBy { get; set; }
        public virtual ICollection<Product> ProductCreatedBy { get; set; }
        public virtual ICollection<Product> ProductLastModifiedBy { get; set; }
        public virtual ICollection<Routing> RoutingCreatedBy { get; set; }
        public virtual ICollection<Routing> RoutingLastModifiedBy { get; set; }
    }
}
