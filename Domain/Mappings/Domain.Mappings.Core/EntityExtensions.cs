using System.Collections.Generic;
using System.Linq;
using Domain.Models.Core;
using Domain.Entities.Core;

namespace Domain.Mappings.Core
{
    /*
     * Here we are manually mapping out our objects instead of using a tool such as "AutoMapper". 
     * This is done to avoid mistakes such as silent mapping failures that get hidden from the developer and to see mapping failures clearly break during build compilation.
     * If we use a mapping tool, then we would also need to write additional unit tests to prove that our mapping tool works correctly.
     */

    public static class EntityExtensions
    {
        public static AddressDto AsDto(this Address address)
        {
            if (address == null)
            {
                return null;
            }

            return new AddressDto
            {
                Id = address.ID,
                Type = address.Type,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                Suburb = address.Suburb,
                City = address.City.AsDto(),
                Province = address.Province.AsDto(),
                Country = address.Country.AsDto(),
                PostalCode = address.PostalCode,
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                PriorityOrder = address.PriorityOrder,
                Created = address.Created,
                CreatedBy = address.CreatedBy.AsDto(),
                Modified = address.Modified,
                ModifiedBy = address.ModifiedBy.AsDto(),
                IsDeleted = address.IsDeleted
            };
        }

        public static IList<AddressDto> AsDto(this IList<Address> addresses)
        {
            return addresses == null ? new List<AddressDto>() : addresses.Select(x => x.AsDto()).ToList();
        }

        public static CityDto AsDto(this City city)
        {
            if (city == null)
            {
                return null;
            }

            return new CityDto
            {
                Id = city.ID,
                ISOCode = city.ISOCode,
                Abbreviation = city.Abbreviation,
                Name = city.Name,
                Province = city.Province.AsDto(),
                Country = city.Country.AsDto()
            };
        }

        public static IList<CityDto> AsDto(this IList<City> cities)
        {
            return cities == null ? new List<CityDto>() : cities.Select(x => x.AsDto()).ToList();
        }

        public static CountryDto AsDto(this Country country)
        {
            if (country == null)
            {
                return null;
            }

            return new CountryDto
            {
                Id = country.ID,
                ISOCode = country.ISOCode,
                Abbreviation = country.Abbreviation,
                Name = country.Name
            };
        }

        public static IList<CountryDto> AsDto(this IList<Country> countries)
        {
            return countries == null ? new List<CountryDto>() : countries.Select(x => x.AsDto()).ToList();
        }

        public static EmailDto AsDto(this Email email)
        {
            if (email == null)
            {
                return null;
            }

            return new EmailDto
            {
                Id = email.ID,
                Type = email.Type,
                AccountType = email.AccountType,
                EmailAddress = email.EmailAddress,
                IncomingMailServer = email.IncomingMailServer,
                OutgoingMailServer = email.OutgoingMailServer,
                IncomingMailServerPort = email.IncomingMailServerPort,
                OutgoingMailServerPort = email.OutgoingMailServerPort,
                IncomingServerUseSSL = email.IncomingServerUseSSL,
                OutgoingServerUseSSL = email.OutgoingServerUseSSL,
                PriorityOrder = email.PriorityOrder,
                Created = email.Created,
                CreatedBy = email.CreatedBy.AsDto(),
                Modified = email.Modified,
                ModifiedBy = email.ModifiedBy.AsDto(),
                IsDeleted = email.IsDeleted

            };
        }

        public static FolderDto AsDto(this Folder folder)
        {
            if (folder == null)
            {
                return null;
            }

            return new FolderDto
            {
                Id = folder.ID,
                Name = folder.Name,
                ParentFolderID = folder.ParentFolderID,
                Created = folder.Created,
                CreatedBy = folder.CreatedBy.AsDto(),
                Modified = folder.Modified,
                ModifiedBy = folder.ModifiedBy.AsDto(),
                IsDeleted = folder.IsDeleted
            };
        }

        public static FileDto AsDto(this File file)
        {
            if (file == null)
            {
                return null;
            }

            return new FileDto
            {
                Id = file.ID,
                Name = file.Name,
                Extension = file.Extension,
                FolderID = file.FolderID,
                Created = file.Created,
                CreatedBy = file.CreatedBy.AsDto(),
                Modified = file.Modified,
                ModifiedBy = file.ModifiedBy.AsDto(),
                IsDeleted = file.IsDeleted
            };
        }

        public static IList<EmailDto> AsDto(this IList<Email> emails)
        {
            return emails == null ? new List<EmailDto>() : emails.Select(x => x.AsDto()).ToList();
        }

        public static LanguageDto AsDto(this Language language)
        {
            if (language == null)
            {
                return null;
            }

            return new LanguageDto
            {
                Id = language.ID,
                ISOCode = language.ISOCode,
                Abbreviation = language.Abbreviation,
                Name = language.Name
            };
        }

        public static IList<LanguageDto> AsDto(this IList<Language> languages)
        {
            return languages == null ? new List<LanguageDto>() : languages.Select(x => x.AsDto()).ToList();
        }

        public static NotificationTemplateDto AsDto(this NotificationTemplate notificationTemplate)
        {
            if (notificationTemplate == null)
            {
                return null;
            }

            return new NotificationTemplateDto
            {
                Id = notificationTemplate.ID,
                Name = notificationTemplate.Name,
                SubjectHeader = notificationTemplate.SubjectHeader,
                Body = notificationTemplate.Body,
                Created = notificationTemplate.Created,
                CreatedBy = notificationTemplate.CreatedBy.AsDto(),
                Modified = notificationTemplate.Modified,
                ModifiedBy = notificationTemplate.ModifiedBy.AsDto(),
                IsActive = notificationTemplate.IsActive,
                IsDeleted = notificationTemplate.IsDeleted
            };
        }

        public static IList<NotificationTemplateDto> AsDto(this IList<NotificationTemplate> notificationTemplates)
        {
            return notificationTemplates == null ? new List<NotificationTemplateDto>() : notificationTemplates.Select(x => x.AsDto()).ToList();
        }

        public static PermissionDto AsDto(this Permission permission)
        {
            if (permission == null)
            {
                return null;
            }

            return new PermissionDto
            {
                Id = permission.ID,
                Name = permission.Name,
                IsActive = permission.IsActive,
                IsDeleted = permission.IsDeleted
            };
        }

        public static IList<PermissionDto> AsDto(this IList<Permission> permissions)
        {
            return permissions == null ? new List<PermissionDto>() : permissions.Select(x => x.AsDto()).ToList();
        }

        public static PhoneNumberDto AsDto(this PhoneNumber phoneNumber)
        {
            if (phoneNumber == null)
            {
                return null;
            }

            return new PhoneNumberDto
            {
                Id = phoneNumber.ID,
                Type = phoneNumber.Type,
                Number = phoneNumber.Number,
                PriorityOrder = phoneNumber.PriorityOrder,
                Created = phoneNumber.Created,
                CreatedBy = phoneNumber.CreatedBy.AsDto(),
                Modified = phoneNumber.Modified,
                ModifiedBy = phoneNumber.ModifiedBy.AsDto(),
                IsActive = phoneNumber.IsActive,
                IsDeleted = phoneNumber.IsDeleted
            };
        }

        public static IList<PhoneNumberDto> AsDto(this IList<PhoneNumber> phoneNumbers)
        {
            return phoneNumbers == null ? new List<PhoneNumberDto>() : phoneNumbers.Select(x => x.AsDto()).ToList();
        }

        public static ProvinceDto AsDto(this Province province)
        {
            if (province == null)
            {
                return null;
            }

            return new ProvinceDto
            {
                Id = province.ID,
                ISOCode = province.ISOCode,
                Abbreviation = province.Abbreviation,
                Name = province.Name
            };
        }

        public static IList<ProvinceDto> AsDto(this IList<Province> provinces)
        {
            return provinces == null ? new List<ProvinceDto>() : provinces.Select(x => x.AsDto()).ToList();
        }

        public static RoleDto AsDto(this Role role)
        {
            if (role == null)
            {
                return null;
            }

            return new RoleDto
            {
                Id = role.ID,
                Name = role.Name,
                Permissions = role.Permissions.AsDto(),
                IsActive = role.IsActive,
                IsDeleted = role.IsDeleted
            };
        }

        public static IList<RoleDto> AsDto(this IList<Role> roles)
        {
            return roles == null ? new List<RoleDto>() : roles.Select(x => x.AsDto()).ToList();
        }

        public static UserDto AsDto(this User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.ID,
                Prefix = user.Prefix,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Suffix = user.Suffix,
                UserName = user.UserName,
                Password = user.Password,
                Salt = user.Salt,
                Type = user.Type,
                Status = user.Status,
                Gender = user.Gender,
                Language = user.Language.AsDto(),
                Roles = user.Roles.AsDto(),
                Emails = user.Emails.AsDto(),
                PhoneNumbers = user.PhoneNumbers.AsDto(),
                Addresses = user.Addresses.AsDto(),
                BloodType = user.BloodType,
                FoodPreferenceType = user.FoodPreferenceType,
                DateOfBirth = user.DateOfBirth,
                Created = user.Created,
                CreatedBy = user.CreatedBy.AsDto(),
                Modified = user.Modified,
                ModifiedBy = user.ModifiedBy.AsDto(),
                IsConfirmed = user.IsConfirmed,
                IsDeleted = user.IsDeleted
            };
        }

        public static IList<UserDto> AsDto(this IList<User> users)
        {
            return users == null ? new List<UserDto>() : users.Select(x => x.AsDto()).ToList();
        }
    }
}
