using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Models.Business
{
    public class CustomerDto : EntityBaseDto
    {
        #region Properties

        public virtual UserDto User { get; set; }

        public virtual IList<OrderDto> Orders { get; set; }

        public virtual bool CreditBlocked { get; set; }

        public virtual decimal CreditLimit { get; set; }

        public virtual short AllowancePeriod_Days { get; set; }

        public virtual short AllowancePeriod_Months { get; set; }

        public virtual bool IsPreferredCustomer { get; set; }

        #endregion Properties
    }
}