using Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Business
{
    public class OrganizationBranch : EntityBase
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual IList<OrganizationDepartment> Departments { get; set; }
        
        public virtual Address Address { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }
        
        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}