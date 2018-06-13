namespace Domain.Entities.Core
{
    public class City : EntityBase
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties

        #region Navigational properties

        public virtual Province Province { get; set; }

        public virtual Country Country { get; set; }

        #endregion Navigational properties
    }
}