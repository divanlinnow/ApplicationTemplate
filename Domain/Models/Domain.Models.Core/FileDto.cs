using System;

namespace Domain.Models.Core
{
    public class FileDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual string Extension { get; set; }
        
        public virtual int FolderID { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

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