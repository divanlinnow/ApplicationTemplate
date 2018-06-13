using Domain.Enums.Core;
using System;

namespace Domain.Entities.Core
{
    public class PhoneNumber : EntityBase
    {
        #region Properties

        public virtual PhoneType Type { get; set; }

        public virtual string Number { get; set; }

        public virtual short PriorityOrder { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}