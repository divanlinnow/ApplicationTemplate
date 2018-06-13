using Domain.Entities.Core;
using System;

namespace Domain.Entities.Business
{
    public class TaskStatus : EntityBase
    {
        #region Properties

        public virtual string Name { get; set; }
        
        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}