using System.Collections.Generic;

namespace Domain.Models.Core
{
    public class RoleDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual IList<PermissionDto> Permissions { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}