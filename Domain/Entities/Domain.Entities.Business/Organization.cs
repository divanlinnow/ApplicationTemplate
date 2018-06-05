using Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Business
{
    public class Organization : EntityBase
    {
        #region Properties

        public virtual string RegisteredName { get; set; }

        public virtual string PrintName { get; set; }
        
        public virtual IList<OrganizationBranch> Branches {get; set;}

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsRegistered { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}