using Domain.Enums.Core;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Core.Tests
{
    public class TestHelper
    {
        public static Address Address()
        {
            return new Address
            {
                Type = AddressType.Other,
                AddressLine1 = "Test Address Line 1",
                AddressLine2 = "Test Address Line 2",
                AddressLine3 = "Test Address Line 3",
                Suburb = "Test Suburb",
                City = City(),
                Province = Province(),
                Country = Country(),
                PostalCode = "ABC123",
                Latitude = 1,
                Longitude = 1,
                PriorityOrder = 1,
                Created = DateTime.Now,
                CreatedBy = User(),
                Modified = DateTime.Now,
                ModifiedBy = User(),
                IsDeleted = false
            };
        }

        public static List<Address> Addresses()
        {
            return new List<Address>
            {
                new Address
                {
                    Type = AddressType.Other,
                    AddressLine1 = "Test Address Line 1",
                    AddressLine2 = "Test Address Line 2",
                    AddressLine3 = "Test Address Line 3",
                    Suburb = "Test Suburb",
                    City = City(),
                    Province = Province(),
                    Country = Country(),
                    PostalCode = "ABC123",
                    Latitude = 1,
                    Longitude = 1,
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsDeleted = false
                },
                new Address
                {
                    Type = AddressType.Other,
                    AddressLine1 = "Test Address Line 1",
                    AddressLine2 = "Test Address Line 2",
                    AddressLine3 = "Test Address Line 3",
                    Suburb = "Test Suburb",
                    City = City(),
                    Province = Province(),
                    Country = Country(),
                    PostalCode = "ABC123",
                    Latitude = 1,
                    Longitude = 1,
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsDeleted = false
                }
            };
        }

        public static City City()
        {
            return new City
            {
                ISOCode = "XXX",
                Abbreviation = "TC",
                Name = "Test City",
                Province = Province(),
                Country = Country()
            };
        }

        public static List<City> Cities()
        {
            return new List<City>
            {
                new City
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test City",
                    Province = Province(),
                    Country = Country()
                },
                new City
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test City",
                    Province = Province(),
                    Country = Country()
                }
            };
        }

        public static Country Country()
        {
            return new Country
            {
                ISOCode = "XXX",
                Abbreviation = "TC",
                Name = "Test Country"
            };
        }

        public static List<Country> Countries()
        {
            return new List<Country>
            {
                new Country
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Country"
                },
                new Country
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Country"
                }
            };
        }

        public static Email Email()
        {
            return new Email
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
                CreatedBy = User(),
                Modified = DateTime.Now,
                ModifiedBy = User(),
                IsDeleted = false
            };
        }

        public static List<Email> Emails()
        {
            return new List<Email>
            {
                new Email
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
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsDeleted = false
                },
                new Email
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
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsDeleted = false
                }
            };
        }

        public static Folder Folder()
        {
            return new Folder
            {
                Name = "Test Folder",
                ParentFolderID = new Guid(),
                Created = DateTime.Now,
                CreatedBy = User(),
                Modified = DateTime.Now,
                ModifiedBy = User(),
                IsDeleted = false
            };
        }

        public static File File()
        {
            return new File
            {
                Name = "Test Folder",
                Extension = ".txt",
                Container = "Test Container",
                FolderID = new Guid(),
                Created = DateTime.Now,
                CreatedBy = User(),
                Modified = DateTime.Now,
                ModifiedBy = User(),
                IsDeleted = false
            };
        }

        public static Language Language()
        {
            return new Language
            {
                ISOCode = "XXX",
                Abbreviation = "TL",
                Name = "Test Language"
            };
        }

        public static List<Language> Languages()
        {
            return new List<Language>
            {
                new Language
                {
                    ISOCode = "XXX",
                    Abbreviation = "TL",
                    Name = "Test Language"
                },
                new Language
                {
                    ISOCode = "XXX",
                    Abbreviation = "TL",
                    Name = "Test Language"
                }
            };
        }

        public static NotificationTemplate NotificationTemplate()
        {
            return new NotificationTemplate
            {
                Name = "Test Notification Template",
                SubjectHeader = "Test Subject",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.",
                Created = DateTime.Now,
                CreatedBy = User(),
                Modified = DateTime.Now,
                ModifiedBy = User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<NotificationTemplate> NotificationTemplates()
        {
            return new List<NotificationTemplate>
            {
                new NotificationTemplate
                {
                    Name = "Test Notification Template",
                    SubjectHeader = "Test Subject",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.",
                    Created = DateTime.Now,
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new NotificationTemplate
                {
                    Name = "Test Notification Template",
                    SubjectHeader = "Test Subject",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.",
                    Created = DateTime.Now,
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static Permission Permission()
        {
            return new Permission
            {
                Name = "Test Permission",
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Permission> Permissions()
        {
            return new List<Permission>
            {
                new Permission
                {
                    Name = "Test Permission 1",
                    IsActive = true,
                    IsDeleted = false
                },
                new Permission
                {
                    Name = "Test Permission 2",
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static PhoneNumber PhoneNumber()
        {
            return new PhoneNumber
            {
                Type = PhoneType.Other,
                Number = "1234567890",
                PriorityOrder = 1,
                Created = DateTime.Now,
                CreatedBy = User(),
                Modified = DateTime.Now,
                ModifiedBy = User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<PhoneNumber> PhoneNumbers()
        {
            return new List<PhoneNumber>
            {
                new PhoneNumber
                {
                    Type = PhoneType.Other,
                    Number = "1111234567890",
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new PhoneNumber
                {
                    Type = PhoneType.Other,
                    Number = "2221234567890",
                    PriorityOrder = 1,
                    Created = DateTime.Now,
                    CreatedBy = User(),
                    Modified = DateTime.Now,
                    ModifiedBy = User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static Province Province()
        {
            return new Province
            {
                ISOCode = "XXX",
                Abbreviation = "TP",
                Name = "Test Province"
            };
        }

        public static List<Province> Provinces()
        {
            return new List<Province>
            {
                new Province
                {
                    ISOCode = "XXX",
                    Abbreviation = "TP",
                    Name = "Test Province"
                },
                new Province
                {
                    ISOCode = "XXX",
                    Abbreviation = "TP",
                    Name = "Test Province"
                }
            };
        }

        public static Role Role()
        {
            return new Role
            {
                Name = "Test Role",
                Permissions = Permissions(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Role> Roles()
        {
            return new List<Role>
            {
                new Role
                {
                    Name = "Test Role 1",
                    Permissions = Permissions(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Role
                {
                    Name = "Test Role 2",
                    Permissions = Permissions(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static User User()
        {
            return new User
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
                Language = Language(),
                Roles = Roles(),

                BloodType = BloodType.O_Positive,
                FoodPreferenceType = FoodPreferenceType.Dairy_Free,
                DateOfBirth = DateTime.Now,
                Created = DateTime.Now,

                Modified = DateTime.Now,

                IsConfirmed = true,
                IsDeleted = false
            };
        }

        public static List<User> Users()
        {
            return new List<User>
            {
                new User
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
                    Language = Language(),
                    Roles = Roles(),

                    BloodType = BloodType.O_Positive,
                    FoodPreferenceType = FoodPreferenceType.Dairy_Free,
                    DateOfBirth = DateTime.Now,
                    Created = DateTime.Now,

                    Modified = DateTime.Now,

                    IsConfirmed = true,
                    IsDeleted = false
                },
                new User
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
                    Language = Language(),
                    Roles = Roles(),

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