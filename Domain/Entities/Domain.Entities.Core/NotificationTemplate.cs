using System;

namespace Domain.Entities.Core
{
    public class NotificationTemplate : EntityBase
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual string SubjectHeader { get; set; }

        public virtual string Body { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}