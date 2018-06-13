using Domain.Entities.Core;

namespace Domain.Entities.Business
{
    public class Currency : EntityBase
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties
    }
}