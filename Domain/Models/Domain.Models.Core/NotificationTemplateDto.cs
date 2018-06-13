using System;

namespace Domain.Models.Core
{
    public class NotificationTemplateDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual string SubjectHeader { get; set; }

        public virtual string Body { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}