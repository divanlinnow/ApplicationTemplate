using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class TaskStatusDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }
        
        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}