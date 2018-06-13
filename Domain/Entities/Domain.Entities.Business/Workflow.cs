using Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Business
{
    public class Workflow : EntityBase
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual OrganizationDepartment Department { get; set; }

        public virtual IList<Employee> Employees { get; set; }

        public virtual IList<Task> Tasks { get; set; }
        
        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}