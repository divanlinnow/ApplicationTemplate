using Domain.Enums.Core;
using System;

namespace Domain.Entities.Core
{
    public class Address : EntityBase
    {
        #region Properties

        public virtual AddressType Type { get; set; }

        public virtual string AddressLine1 { get; set; }

        public virtual string AddressLine2 { get; set; }

        public virtual string AddressLine3 { get; set; }

        public virtual string Suburb { get; set; }

        public virtual City City { get; set; }

        public virtual Province Province { get; set; }

        public virtual Country Country { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual decimal Latitude { get; set; }

        public virtual decimal Longitude { get; set; }
        
        public virtual short PriorityOrder { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }
        
        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}