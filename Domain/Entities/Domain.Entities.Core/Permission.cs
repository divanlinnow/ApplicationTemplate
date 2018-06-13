namespace Domain.Entities.Core
{
    public class Permission : EntityBase
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}