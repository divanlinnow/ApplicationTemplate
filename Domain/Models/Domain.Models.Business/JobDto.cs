using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class JobDto : EntityBaseDto
    {
        #region Properties

        public virtual OrganizationDto Organization { get; set; }

        public virtual OrganizationBranchDto Branch { get; set; }

        public virtual OrganizationDepartmentDto Department { get; set; }

        public virtual string Title { get; set; }

        public virtual RoleDto Role { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}