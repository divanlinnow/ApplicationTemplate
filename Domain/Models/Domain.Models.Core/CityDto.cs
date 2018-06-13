namespace Domain.Models.Core
{
    public class CityDto : EntityBaseDto
    {
        #region Properties

        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }

        public virtual ProvinceDto Province { get; set; }

        public virtual CountryDto Country { get; set; }

        #endregion Properties
    }
}