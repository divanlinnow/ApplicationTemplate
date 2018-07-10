using System;

namespace Domain.Entities.Business
{
    public class ProductOrderItem
    {
        #region Properties

        public virtual int OrderId { get; set; }

        public virtual int ProductId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}