using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class ServiceDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal MinimumOrderQuantity { get; set; }

        public virtual decimal PriceEXCL { get; set; }

        public virtual decimal PriceINCL { get; set; }

        public virtual bool PriceMustChange { get; set; }

        public virtual DateTime PriceExpiryDate { get; set; }

        public virtual bool HasExpiryDate { get; set; }

        public virtual DateTime? ExpiryDate { get; set; }

        public virtual SupplierDto Supplier { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}