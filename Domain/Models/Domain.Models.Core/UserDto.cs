using Domain.Enums.Core;
using System;
using System.Collections.Generic;

namespace Domain.Models.Core
{
    public class UserDto : EntityBaseDto
    {
        #region Properties

        public virtual Prefix Prefix { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual Suffix Suffix { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string Salt { get; set; }

        public virtual UserType Type { get; set; }

        public virtual UserStatus Status { get; set; }

        public virtual GenderType Gender { get; set; }

        public virtual LanguageDto Language { get; set; }

        public virtual IList<RoleDto> Roles { get; set; }

        public virtual IList<EmailDto> Emails { get; set; }

        public virtual IList<PhoneNumberDto> PhoneNumbers { get; set; }

        public virtual IList<AddressDto> Addresses { get; set; }

        public virtual BloodType BloodType { get; set; }

        public virtual FoodPreferenceType FoodPreferenceType { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsConfirmed { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}