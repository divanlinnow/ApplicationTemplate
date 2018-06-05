using System;
using Domain.Enums.Core;

namespace Domain.Models.Core
{
    public class AddressDto : EntityBaseDto
    {
        #region Properties

        public virtual AddressType Type { get; set; }

        public virtual string AddressLine1 { get; set; }

        public virtual string AddressLine2 { get; set; }

        public virtual string AddressLine3 { get; set; }

        public virtual string Suburb { get; set; }

        public virtual CityDto City { get; set; }

        public virtual ProvinceDto Province { get; set; }

        public virtual CountryDto Country { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual decimal Latitude { get; set; }

        public virtual decimal Longitude { get; set; }

        public virtual short PriorityOrder { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}