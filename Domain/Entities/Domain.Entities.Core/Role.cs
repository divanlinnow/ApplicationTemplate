using System.Collections.Generic;

namespace Domain.Entities.Core
{
    public class Role : EntityBase
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual IList<Permission> Permissions { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}