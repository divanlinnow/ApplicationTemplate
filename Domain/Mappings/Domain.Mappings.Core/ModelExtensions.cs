using Domain.Entities.Core;
using Domain.Models.Core;
using Domain.Models.Core.Precis;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Mappings.Core
{
    /*
     * Here we are manually mapping out our objects instead of using a tool such as "AutoMapper". 
     * This is done to avoid mistakes such as silent mapping failures that get hidden from the developer and to see mapping failures clearly break during build compilation.
     * If we use a mapping tool, then we would also need to write additional unit tests to prove that our mapping tool works correctly.
     */

    public static class ModelExtensions
    {
        public static Address AsEntity(this AddressDto addressDto)
        {
            if (addressDto == null)
            {
                return null;
            }

            return new Address
            {
                ID = addressDto.Id,
                Type = addressDto.Type,
                AddressLine1 = addressDto.AddressLine1,
                AddressLine2 = addressDto.AddressLine2,
                AddressLine3 = addressDto.AddressLine3,
                Suburb = addressDto.Suburb,
                City = addressDto.City.AsEntity(),
                Province = addressDto.Province.AsEntity(),
                Country = addressDto.Country.AsEntity(),
                PostalCode = addressDto.PostalCode,
                Latitude = addressDto.Latitude,
                Longitude = addressDto.Longitude,
                PriorityOrder = addressDto.PriorityOrder,
                Created = addressDto.Created,
                CreatedBy = addressDto.CreatedBy.AsEntity(),
                Modified = addressDto.Modified,
                ModifiedBy = addressDto.ModifiedBy.AsEntity(),
                IsDeleted = addressDto.IsDeleted
            };
        }

        public static IList<Address> AsEntity(this IList<AddressDto> addresses)
        {
            return addresses == null ? new List<Address>() : addresses.Select(x => x.AsEntity()).ToList();
        }

        public static City AsEntity(this CityDto cityDto)
        {
            if (cityDto == null)
            {
                return null;
            }

            return new City
            {
                ID = cityDto.Id,
                ISOCode = cityDto.ISOCode,
                Abbreviation = cityDto.Abbreviation,
                Name = cityDto.Name,
                Province = cityDto.Province.AsEntity(),
                Country = cityDto.Country.AsEntity()
            };
        }

        public static IList<City> AsEntity(this IList<CityDto> cities)
        {
            return cities == null ? new List<City>() : cities.Select(x => x.AsEntity()).ToList();
        }

        public static Country AsEntity(this CountryDto countryDto)
        {
            if (countryDto == null)
            {
                return null;
            }

            return new Country
            {
                ID = countryDto.Id,
                ISOCode = countryDto.ISOCode,
                Abbreviation = countryDto.Abbreviation,
                Name = countryDto.Name
            };
        }

        public static IList<Country> AsEntity(this IList<CountryDto> countries)
        {
            return countries == null ? new List<Country>() : countries.Select(x => x.AsEntity()).ToList();
        }

        public static Email AsEntity(this EmailPrecis emailPrecis)
        {
            if (emailPrecis == null)
            {
                return null;
            }

            return new Email
            {
                ID = emailPrecis.Id,
                EmailAddress = emailPrecis.EmailAddress
            };
        }

        public static Email AsEntity(this EmailDto emailDto)
        {
            if (emailDto == null)
            {
                return null;
            }

            return new Email
            {
                ID = emailDto.Id,
                Type = emailDto.Type,
                AccountType = emailDto.AccountType,
                EmailAddress = emailDto.EmailAddress,
                IncomingMailServer = emailDto.IncomingMailServer,
                OutgoingMailServer = emailDto.OutgoingMailServer,
                IncomingMailServerPort = emailDto.IncomingMailServerPort,
                OutgoingMailServerPort = emailDto.OutgoingMailServerPort,
                IncomingServerUseSSL = emailDto.IncomingServerUseSSL,
                OutgoingServerUseSSL = emailDto.OutgoingServerUseSSL,
                PriorityOrder = emailDto.PriorityOrder,
                Created = emailDto.Created,
                CreatedBy = emailDto.CreatedBy.AsEntity(),
                Modified = emailDto.Modified,
                ModifiedBy = emailDto.ModifiedBy.AsEntity(),
                IsDeleted = emailDto.IsDeleted
            };
        }

        public static Folder AsEntity(this FolderDto folderDto)
        {
            if (folderDto == null)
            {
                return null;
            }

            return new Folder
            {
                ID = folderDto.Id,
                Name = folderDto.Name,
                ParentFolderID = folderDto.ParentFolderID,
                Created = folderDto.Created,
                CreatedBy = folderDto.CreatedBy.AsEntity(),
                Modified = folderDto.Modified,
                ModifiedBy = folderDto.ModifiedBy.AsEntity(),
                IsDeleted = folderDto.IsDeleted
            };
        }

        public static File AsEntity(this FileDto fileDto)
        {
            if (fileDto == null)
            {
                return null;
            }

            return new File
            {
                ID = fileDto.Id,
                Name = fileDto.Name,
                Extension = fileDto.Extension,
                FolderID = fileDto.FolderID,
                Created = fileDto.Created,
                CreatedBy = fileDto.CreatedBy.AsEntity(),
                Modified = fileDto.Modified,
                ModifiedBy = fileDto.ModifiedBy.AsEntity(),
                IsDeleted = fileDto.IsDeleted
            };
        }

        public static IList<Email> AsEntity(this IList<EmailDto> emails)
        {
            return emails == null ? new List<Email>() : emails.Select(x => x.AsEntity()).ToList();
        }

        public static Language AsEntity(this LanguageDto languageDto)
        {
            if (languageDto == null)
            {
                return null;
            }

            return new Language
            {
                ID = languageDto.Id,
                ISOCode = languageDto.ISOCode,
                Abbreviation = languageDto.Abbreviation,
                Name = languageDto.Name
            };
        }

        public static IList<Language> AsEntity(this IList<LanguageDto> languages)
        {
            return languages == null ? new List<Language>() : languages.Select(x => x.AsEntity()).ToList();
        }

        public static NotificationTemplate AsEntity(this NotificationTemplateDto notificationTemplateDto)
        {
            if (notificationTemplateDto == null)
            {
                return null;
            }

            return new NotificationTemplate
            {
                ID = notificationTemplateDto.Id,
                Name = notificationTemplateDto.Name,
                SubjectHeader = notificationTemplateDto.SubjectHeader,
                Body = notificationTemplateDto.Body,
                Created = notificationTemplateDto.Created,
                CreatedBy = notificationTemplateDto.CreatedBy.AsEntity(),
                Modified = notificationTemplateDto.Modified,
                ModifiedBy = notificationTemplateDto.ModifiedBy.AsEntity(),
                IsActive = notificationTemplateDto.IsActive,
                IsDeleted = notificationTemplateDto.IsDeleted
            };
        }

        public static IList<NotificationTemplate> AsEntity(this IList<NotificationTemplateDto> notificationTemplates)
        {
            return notificationTemplates == null ? new List<NotificationTemplate>() : notificationTemplates.Select(x => x.AsEntity()).ToList();
        }

        public static Permission AsEntity(this PermissionDto permissionDto)
        {
            if (permissionDto == null)
            {
                return null;
            }

            return new Permission
            {
                ID = permissionDto.Id,
                Name = permissionDto.Name,
                IsActive = permissionDto.IsActive,
                IsDeleted = permissionDto.IsDeleted
            };
        }

        public static IList<Permission> AsEntity(this IList<PermissionDto> permissions)
        {
            return permissions == null ? new List<Permission>() : permissions.Select(x => x.AsEntity()).ToList();
        }

        public static PhoneNumber AsEntity(this PhoneNumberPrecis phoneNumberPrecis)
        {
            if (phoneNumberPrecis == null)
            {
                return null;
            }

            return new PhoneNumber
            {
                ID = phoneNumberPrecis.Id,
                Number = phoneNumberPrecis.Number
            };
        }

        public static PhoneNumber AsEntity(this PhoneNumberDto phoneNumberDto)
        {
            if (phoneNumberDto == null)
            {
                return null;
            }

            return new PhoneNumber
            {
                ID = phoneNumberDto.Id,
                Type = phoneNumberDto.Type,
                Number = phoneNumberDto.Number,
                PriorityOrder = phoneNumberDto.PriorityOrder,
                Created = phoneNumberDto.Created,
                CreatedBy = phoneNumberDto.CreatedBy.AsEntity(),
                Modified = phoneNumberDto.Modified,
                ModifiedBy = phoneNumberDto.ModifiedBy.AsEntity(),
                IsActive = phoneNumberDto.IsActive,
                IsDeleted = phoneNumberDto.IsDeleted
            };
        }

        public static IList<PhoneNumber> AsEntity(this IList<PhoneNumberDto> phoneNumbers)
        {
            return phoneNumbers == null ? new List<PhoneNumber>() : phoneNumbers.Select(x => x.AsEntity()).ToList();
        }

        public static Province AsEntity(this ProvinceDto provinceDto)
        {
            if (provinceDto == null)
            {
                return null;
            }

            return new Province
            {
                ID = provinceDto.Id,
                ISOCode = provinceDto.ISOCode,
                Abbreviation = provinceDto.Abbreviation,
                Name = provinceDto.Name
            };
        }

        public static IList<Province> AsEntity(this IList<ProvinceDto> provinces)
        {
            return provinces == null ? new List<Province>() : provinces.Select(x => x.AsEntity()).ToList();
        }

        public static Role AsEntity(this RolePrecis rolePrecis)
        {
            if (rolePrecis == null)
            {
                return null;
            }

            return new Role
            {
                ID = rolePrecis.Id,
                Name = rolePrecis.Name
            };
        }

        public static Role AsEntity(this RoleDto roleDto)
        {
            if (roleDto == null)
            {
                return null;
            }

            return new Role
            {
                ID = roleDto.Id,
                Name = roleDto.Name,
                Permissions = roleDto.Permissions.AsEntity(),
                IsActive = roleDto.IsActive,
                IsDeleted = roleDto.IsDeleted
            };
        }

        public static IList<Role> AsEntity(this IList<RoleDto> roles)
        {
            return roles == null ? new List<Role>() : roles.Select(x => x.AsEntity()).ToList();
        }

        public static User AsEntity(this UserPrecis userPrecis)
        {
            if (userPrecis == null)
            {
                return null;
            }

            return new User
            {
                ID = userPrecis.Id,
                Prefix = userPrecis.Prefix,
                FirstName = userPrecis.FirstName,
                LastName = userPrecis.LastName,
                Suffix = userPrecis.Suffix
            };
        }

        public static User AsEntity(this UserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            return new User
            {
                ID = userDto.Id,
                Prefix = userDto.Prefix,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Suffix = userDto.Suffix,
                UserName = userDto.UserName,
                Password = userDto.Password,
                Salt = userDto.Salt,
                Type = userDto.Type,
                Status = userDto.Status,
                Gender = userDto.Gender,
                Language = userDto.Language.AsEntity(),
                Roles = userDto.Roles.AsEntity(),
                Emails = userDto.Emails.AsEntity(),
                PhoneNumbers = userDto.PhoneNumbers.AsEntity(),
                Addresses = userDto.Addresses.AsEntity(),
                BloodType = userDto.BloodType,
                FoodPreferenceType = userDto.FoodPreferenceType,
                DateOfBirth = userDto.DateOfBirth,
                Created = userDto.Created,
                CreatedBy = userDto.CreatedBy.AsEntity(),
                Modified = userDto.Modified,
                ModifiedBy = userDto.ModifiedBy.AsEntity(),
                IsConfirmed = userDto.IsConfirmed,
                IsDeleted = userDto.IsDeleted
            };
        }

        public static IList<User> AsEntity(this IList<UserDto> users)
        {
            return users == null ? new List<User>() : users.Select(x => x.AsEntity()).ToList();
        }
    }
}