using System.Collections.Generic;

namespace Domain.Entities.Core
{
    public class Country : EntityBase
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties

        #region Navigational properties

        public virtual List<Province> Provinces { get; set; }

        #endregion Navigational properties

        #region Constructor

        public Country()
        {
            this.Provinces = new List<Province>();
        }

        #endregion Constructor
    }
}