namespace Domain.Entities.Core
{
    public class Language : EntityBase
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties
    }
}