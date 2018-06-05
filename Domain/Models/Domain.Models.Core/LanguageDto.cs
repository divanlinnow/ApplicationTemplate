namespace Domain.Models.Core
{
    public class LanguageDto : EntityBaseDto
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties
    }
}