using Domain.Entities.Core;
using System.Collections.Generic;

namespace Domain.Entities.Business
{
    public class Customer : EntityBase
    {
        #region Properties

        public virtual User User { get; set; }

        public virtual IList<Order> Orders { get; set; }

        public virtual bool CreditBlocked { get; set; }

        public virtual decimal CreditLimit { get; set; }

        public virtual short AllowancePeriod_Days { get; set; }

        public virtual short AllowancePeriod_Months { get; set; }

        public virtual bool IsPreferredCustomer { get; set; }

        #endregion Properties
    }
}