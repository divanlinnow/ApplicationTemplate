using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class ProductOrderItemDto
    {
        #region Properties

        public virtual Guid OrderId { get; set; }

        public virtual Guid ProductId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}