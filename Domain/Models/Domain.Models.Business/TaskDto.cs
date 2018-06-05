using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class TaskDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual EmployeeDto AssignedTo { get; set; }

        public virtual EmployeeDto AssignedBy { get; set; }

        public virtual DateTime EstimatedStart { get; set; }

        public virtual DateTime EstimatedEnd { get; set; }

        public virtual DateTime ActualStart { get; set; }

        public virtual DateTime ActualEnd { get; set; }

        public virtual TaskStatusDto Status { get; set; }
        
        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}