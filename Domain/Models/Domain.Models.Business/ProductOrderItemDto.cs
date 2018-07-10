using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class ProductOrderItemDto
    {
        #region Properties

        public virtual int OrderId { get; set; }

        public virtual int ProductId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}