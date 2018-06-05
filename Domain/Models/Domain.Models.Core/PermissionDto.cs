namespace Domain.Models.Core
{
    public class PermissionDto : EntityBaseDto
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}