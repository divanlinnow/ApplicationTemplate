using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class ServiceOrderItemDto
    {
        #region Properties

        public virtual Guid OrderId { get; set; }

        public virtual Guid ServiceId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}