using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IEmailService
    {
        GenericServiceResponse<IEnumerable<EmailDto>> GetAllEmails();

        GenericServiceResponse<EmailDto> FindEmailById(Guid Id);

        GenericServiceResponse<bool> CreateEmail(EmailDto email);

        GenericServiceResponse<bool> UpdateEmail(EmailDto email);

        GenericServiceResponse<bool> DeleteEmail(EmailDto email);

        GenericServiceResponse<bool> DeleteEmail(Guid Id);
    }
}