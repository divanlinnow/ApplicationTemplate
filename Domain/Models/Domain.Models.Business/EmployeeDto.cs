using Domain.Models.Core;
using System;

namespace Domain.Models.Business
{
    public class EmployeeDto : EntityBaseDto
    {
        #region Properties
        
        public virtual UserDto User { get; set; }

        public virtual OrganizationDto Organization { get; set; }

        public virtual OrganizationBranchDto Branch { get; set; }

        public virtual OrganizationDepartmentDto Department { get; set; }

        public virtual JobDto Job { get; set; }

        #endregion Properties
    }
}