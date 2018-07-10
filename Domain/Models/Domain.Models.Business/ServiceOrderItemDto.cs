using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class ServiceOrderItemDto
    {
        #region Properties

        public virtual int OrderId { get; set; }

        public virtual int ServiceId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}