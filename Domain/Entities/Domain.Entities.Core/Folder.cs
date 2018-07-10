using System;

namespace Domain.Entities.Core
{
    public class Folder : EntityBase
    {
        #region Properties
        
        public virtual string Name { get; set; }

        public virtual int ParentFolderID { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}