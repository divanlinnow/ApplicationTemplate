using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Models.Business
{
    public class    OrganizationBranchDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual OrganizationDto Organization { get; set; }

        public virtual IList<OrganizationDepartmentDto> Departments { get; set; }
        
        public virtual AddressDto Address { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}