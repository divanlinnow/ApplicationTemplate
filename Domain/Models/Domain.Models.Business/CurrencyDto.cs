using Domain.Models.Core;

namespace Domain.Models.Business
{
    public class CurrencyDto : EntityBaseDto
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties
    }
}