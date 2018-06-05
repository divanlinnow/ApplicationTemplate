using Domain.Entities.Core;
using System;

namespace Domain.Entities.Business
{
    public class Product : EntityBase
    {
        #region Properties
        
        public virtual string Name { get; set; }

        public virtual string Make { get; set; }

        public virtual string Model { get; set; }

        public virtual int Year { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal MinimumOrderQuantity { get; set; }

        public virtual decimal PriceEXCL { get; set; }

        public virtual decimal PriceINCL { get; set; }

        public virtual bool PriceMustChange { get; set; }

        public virtual DateTime PriceExpiryDate { get; set; }

        public virtual bool HasExpiryDate { get; set; }

        public virtual DateTime? ExpiryDate { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}