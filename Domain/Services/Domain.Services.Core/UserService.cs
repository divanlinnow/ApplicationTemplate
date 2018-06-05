using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Core;
using Domain.Mappings.Core;
using Domain.Models.Core;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Domain.Services.Core
{
    public class UserService : ServiceBase, IUserService
    {
        #region Constructor

        public UserService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<UserDto>> GetAllUsers()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<UserDto>>>((response) =>
            {
                response.Result = Repository.All<User>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllUsers' was unable to find any user records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<UserDto> FindUserById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<UserDto>>((response) =>
            {
                response.Result = Repository.FindById<User>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindUserById' was unable to find the given user record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateUser(UserDto user)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(user.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateUser' was unable to insert a new user record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateUser(UserDto user)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(user.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateUser' was unable to update the given user record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteUser(UserDto user)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(user.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteUser' was unable to delete the given user record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteUser(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<User>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteUser' was unable to delete the given user record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}