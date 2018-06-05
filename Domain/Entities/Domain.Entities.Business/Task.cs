using Domain.Entities.Core;
using System;

namespace Domain.Entities.Business
{
    public class Task : EntityBase
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual Employee AssignedTo { get; set; }

        public virtual Employee AssignedBy { get; set; }

        public virtual DateTime EstimatedStart { get; set; }

        public virtual DateTime EstimatedEnd { get; set; }

        public virtual DateTime ActualStart { get; set; }

        public virtual DateTime ActualEnd { get; set; }

        public virtual TaskStatus Status { get; set; }
        
        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}