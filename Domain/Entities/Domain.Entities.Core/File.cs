using System;

namespace Domain.Entities.Core
{
    public class File : EntityBase
    {
        #region Properties
        
        public virtual string Name { get; set; }

        public virtual string Extension { get; set; }

        public virtual string Container { get; set; }

        public virtual byte[] Hash { get; set; }

        public virtual Guid FolderID { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties

        #region Methods
        public override string ToString()
        {
            return $"{Name}.{Extension}";
        }

        #endregion Methods
    }
}