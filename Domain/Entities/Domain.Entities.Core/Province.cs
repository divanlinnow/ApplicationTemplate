using System.Collections.Generic;

namespace Domain.Entities.Core
{
    public class Province : EntityBase
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties

        #region Navigational properties

        public virtual Country Country { get; set; }

        public virtual List<City> Cities { get; set; }

        #endregion Navigational properties

        #region Constructor

        public Province()
        {
            this.Cities = new List<City>();
        }

        #endregion Constructor
    }
}