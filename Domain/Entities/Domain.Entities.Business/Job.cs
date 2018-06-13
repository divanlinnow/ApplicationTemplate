using Domain.Entities.Core;
using System;

namespace Domain.Entities.Business
{
    public class Job : EntityBase
    {
        #region Properties

        public virtual Organization Organization { get; set; }

        public virtual OrganizationBranch Branch { get; set; }

        public virtual OrganizationDepartment Department { get; set; }

        public virtual string Title { get; set; }

        public virtual Role Role { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}