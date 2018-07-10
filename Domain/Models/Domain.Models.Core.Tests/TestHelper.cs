using Domain.Enums.Core;
using System;
using System.Collections.Generic;

namespace Domain.Models.Core.Tests
{
    public static class TestHelper
    {
        public static AddressDto AddressDto()
        {
            return new AddressDto
            {
                Type = AddressType.Other,
                AddressLine1 = "Test Address Line 1",
                AddressLine2 = "Test Address Line 2",
                AddressLine3 = "Test Address Line 3",
                Suburb = "Test Suburb",
                City = CityDto(),
                Province = ProvinceDto(),
                Country = CountryDto(),
                PostalCode = "ABC123",
                Latitude = 1,
                Longitude = 1,
                PriorityOrder = 1,
                Created = DateTime.Now,
                CreatedBy = UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = UserDto(),
                IsDeleted = false
            };
        }

        public static List<AddressDto> AddressDtos()
        {
            return new List<AddressDto>
            {
                new AddressDto
                {
                    Type = AddressType.Other,
                    AddressLine1 = "Test Address Line 1",
                    AddressLine2 = "Test Address Line 2",
                    AddressLine3 = "Test Address Line 3",
                    Suburb = "Test Suburb",
                    City = CityDto(),
                    Province = ProvinceDto(),
                    Country = CountryDto(),
                    PostalCode = "ABC123",
                    Latitude = 1,
                    Longitude = 1,
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsDeleted = false
                },
                new AddressDto
                {
                    Type = AddressType.Other,
                    AddressLine1 = "Test Address Line 1",
                    AddressLine2 = "Test Address Line 2",
                    AddressLine3 = "Test Address Line 3",
                    Suburb = "Test Suburb",
                    City = CityDto(),
                    Province = ProvinceDto(),
                    Country = CountryDto(),
                    PostalCode = "ABC123",
                    Latitude = 1,
                    Longitude = 1,
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsDeleted = false
                }
            };
        }

        public static CityDto CityDto()
        {
            return new CityDto
            {
                ISOCode = "XXX",
                Abbreviation = "TC",
                Name = "Test City",
                Province = ProvinceDto(),
                Country = CountryDto()
            };
        }

        public static List<CityDto> CityDtos()
        {
            return new List<CityDto>
            {
                new CityDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test City 1",
                    Province = ProvinceDto(),
                    Country = CountryDto()
                },
                new CityDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test City 2",
                    Province = ProvinceDto(),
                    Country = CountryDto()
                }
            };
        }

        public static CountryDto CountryDto()
        {
            return new CountryDto
            {
                ISOCode = "XXX",
                Abbreviation = "TC",
                Name = "Test Country"
            };
        }

        public static List<CountryDto> CountryDtos()
        {
            return new List<CountryDto>
            {
                new CountryDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Country 1"
                },
                new CountryDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Country 2"
                }
            };
        }

        public static EmailDto EmailDto()
        {
            return new EmailDto
            {
                Type = EmailType.Test,
                AccountType = EmailAccountType.IMAP,
                EmailAddress = "test@test.com",
                IncomingMailServer = "imap.test.com",
                OutgoingMailServer = "smtp.test.com",
                IncomingMailServerPort = 993,
                OutgoingMailServerPort = 465,
                IncomingServerUseSSL = true,
                OutgoingServerUseSSL = true,
                PriorityOrder = 1,
                Created = DateTime.Now,
                CreatedBy = UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = UserDto(),
                IsDeleted = false
            };
        }

        public static List<EmailDto> EmailDtos()
        {
            return new List<EmailDto>
            {
                new EmailDto
                {
                    Type = EmailType.Test,
                    AccountType = EmailAccountType.IMAP,
                    EmailAddress = "test1@test.com",
                    IncomingMailServer = "imap.test.com",
                    OutgoingMailServer = "smtp.test.com",
                    IncomingMailServerPort = 993,
                    OutgoingMailServerPort = 465,
                    IncomingServerUseSSL = true,
                    OutgoingServerUseSSL = true,
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsDeleted = false
                },
                new EmailDto
                {
                    Type = EmailType.Test,
                    AccountType = EmailAccountType.IMAP,
                    EmailAddress = "test2@test.com",
                    IncomingMailServer = "imap.test.com",
                    OutgoingMailServer = "smtp.test.com",
                    IncomingMailServerPort = 993,
                    OutgoingMailServerPort = 465,
                    IncomingServerUseSSL = true,
                    OutgoingServerUseSSL = true,
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsDeleted = false
                }
            };
        }

        public static FolderDto FolderDto()
        {
            return new FolderDto
            {
                Name = "Test Folder",
                ParentFolderID = new Guid(),
                Created = DateTime.Now,
                CreatedBy = UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = UserDto(),
                IsDeleted = false
            };
        }

        public static FileDto FileDto()
        {
            return new FileDto
            {
                Name = "Test Folder",
                Extension = ".txt",
                FolderID = new Guid(),
                Created = DateTime.Now,
                CreatedBy = UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = UserDto(),
                IsDeleted = false
            };
        }

        public static LanguageDto LanguageDto()
        {
            return new LanguageDto
            {
                ISOCode = "XXX",
                Abbreviation = "TL",
                Name = "Test Language"
            };
        }

        public static List<LanguageDto> LanguageDtos()
        {
            return new List<LanguageDto>
            {
                new LanguageDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TL",
                    Name = "Test Language 1"
                },
                new LanguageDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TL",
                    Name = "Test Language 2"
                }
            };
        }

        public static NotificationTemplateDto NotificationTemplateDto()
        {
            return new NotificationTemplateDto
            {
                Name = "Test Notification Template",
                SubjectHeader = "Test Subject",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.",
                Created = DateTime.Now,
                CreatedBy = UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<NotificationTemplateDto> NotificationTemplateDtos()
        {
            return new List<NotificationTemplateDto>
            {
                new NotificationTemplateDto
                {
                    Name = "Test Notification Template 1",
                    SubjectHeader = "Test Subject",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.",
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsActive = true,
                    IsDeleted = false
                },
                new NotificationTemplateDto
                {
                    Name = "Test Notification Template 2",
                    SubjectHeader = "Test Subject",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.",
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static PermissionDto PermissionDto()
        {
            return new PermissionDto
            {
                Name = "Test Permission",
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<PermissionDto> PermissionDtos()
        {
            return new List<PermissionDto>
            {
                new PermissionDto
                {
                    Name = "Test Permission 1",
                    IsActive = true,
                    IsDeleted = false
                },
                new PermissionDto
                {
                    Name = "Test Permission 2",
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static PhoneNumberDto PhoneNumberDto()
        {
            return new PhoneNumberDto
            {
                Type = PhoneType.Other,
                Number = "1234567890",
                PriorityOrder = 1,
                Created = DateTime.Now,
                CreatedBy = UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<PhoneNumberDto> PhoneNumberDtos()
        {
            return new List<PhoneNumberDto>
            {
                new PhoneNumberDto
                {
                    Type = PhoneType.Other,
                    Number = "1111234567890",
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsActive = true,
                    IsDeleted = false
                },
                new PhoneNumberDto
                {
                    Type = PhoneType.Other,
                    Number = "2221234567890",
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = UserDto(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static ProvinceDto ProvinceDto()
        {
            return new ProvinceDto
            {
                ISOCode = "XXX",
                Abbreviation = "TP",
                Name = "Test Province"
            };
        }

        public static List<ProvinceDto> ProvinceDtos()
        {
            return new List<ProvinceDto>
            {
                new ProvinceDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TP",
                    Name = "Test Province 1"
                },
                new ProvinceDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TP",
                    Name = "Test Province 2"
                }
            };
        }

        public static RoleDto RoleDto()
        {
            return new RoleDto
            {
                Name = "Test Role",
                Permissions = PermissionDtos(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<RoleDto> RoleDtos()
        {
            return new List<RoleDto>
            {
                new RoleDto
                {
                    Name = "Test Role 1",
                    Permissions = PermissionDtos(),
                    IsActive = true,
                    IsDeleted = false
                },
                new RoleDto
                {
                    Name = "Test Role 2",
                    Permissions = PermissionDtos(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static UserDto UserDto()
        {
            return new UserDto
            {
                Prefix = Prefix.Mr,
                FirstName = "Tester",
                LastName = "McTester",
                Suffix = Suffix.Jr,
                UserName = "Tester",
                Password = "P@ssw0rd123",
                Salt = "P@ssw0rdS@lt123",
                Type = UserType.System_Administrator,
                Status = UserStatus.Online,
                Gender = GenderType.Male,
                Language = LanguageDto(),
                Roles = RoleDtos(),

                BloodType = BloodType.O_Positive,
                FoodPreferenceType = FoodPreferenceType.Dairy_Free,
                DateOfBirth = DateTime.Now,
                Created = DateTime.Now,

                Modified = DateTime.Now,

                IsConfirmed = true,
                IsDeleted = false
            };
        }

        public static List<UserDto> UserDtos()
        {
            return new List<UserDto>
            {
                new UserDto
                {
                    Prefix = Prefix.Mr,
                    FirstName = "Tester",
                    LastName = "McTester",
                    Suffix = Suffix.Jr,
                    UserName = "Tester",
                    Password = "P@ssw0rd123",
                    Salt = "P@ssw0rdS@lt123",
                    Type = UserType.System_Administrator,
                    Status = UserStatus.Online,
                    Gender = GenderType.Male,
                    Language = LanguageDto(),
                    Roles = RoleDtos(),

                    BloodType = BloodType.O_Positive,
                    FoodPreferenceType = FoodPreferenceType.Dairy_Free,
                    DateOfBirth = DateTime.Now,
                    Created = DateTime.Now,

                    Modified = DateTime.Now,

                    IsConfirmed = true,
                    IsDeleted = false
                },
                new UserDto
                {
                    Prefix = Prefix.Mr,
                    FirstName = "Tester",
                    LastName = "McTester",
                    Suffix = Suffix.Jr,
                    UserName = "Tester",
                    Password = "P@ssw0rd123",
                    Salt = "P@ssw0rdS@lt123",
                    Type = UserType.System_Administrator,
                    Status = UserStatus.Online,
                    Gender = GenderType.Male,
                    Language = LanguageDto(),
                    Roles = RoleDtos(),

                    BloodType = BloodType.O_Positive,
                    FoodPreferenceType = FoodPreferenceType.Dairy_Free,
                    DateOfBirth = DateTime.Now,
                    Created = DateTime.Now,

                    Modified = DateTime.Now,

                    IsConfirmed = true,
                    IsDeleted = false
                }
            };
        }
    }
}