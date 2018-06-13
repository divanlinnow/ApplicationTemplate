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
    public class EmailService : ServiceBase, IEmailService
    {
        #region Constructor

        public EmailService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<EmailDto>> GetAllEmails()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<EmailDto>>>((response) =>
            {
                response.Result = Repository.All<Email>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllEmails' was unable to find any email records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<EmailDto> FindEmailById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<EmailDto>>((response) =>
            {
                response.Result = Repository.FindById<Email>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindEmailById' was unable to find the given email record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateEmail(EmailDto email)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(email.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateEmail' was unable to insert a new email record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateEmail(EmailDto email)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(email.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateEmail' was unable to update the given email record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteEmail(EmailDto email)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(email.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteEmail' was unable to delete the given email record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteEmail(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Email>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteEmail' was unable to delete the given email record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}