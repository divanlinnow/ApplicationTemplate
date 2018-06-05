using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Models.Business
{
    public class OrganizationDto : EntityBaseDto
    {
        #region Properties

        public virtual string RegisteredName { get; set; }

        public virtual string PrintName { get; set; }

        public virtual IList<OrganizationBranchDto> Branches { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsRegistered { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}