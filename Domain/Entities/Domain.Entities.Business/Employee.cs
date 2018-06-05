using Domain.Entities.Core;
using System;

namespace Domain.Entities.Business
{
    public class Employee : EntityBase
    {
        #region Properties
        
        public virtual User User { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual OrganizationBranch Branch { get; set; }

        public virtual OrganizationDepartment Department { get; set; }

        public virtual Job Job { get; set; }

        #endregion Properties
    }
}