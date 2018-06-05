using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IPhoneNumberService
    {
        GenericServiceResponse<IEnumerable<PhoneNumberDto>> GetAllPhoneNumbers();

        GenericServiceResponse<PhoneNumberDto> FindPhoneNumberById(Guid Id);

        GenericServiceResponse<bool> CreatePhoneNumber(PhoneNumberDto phoneNumber);

        GenericServiceResponse<bool> UpdatePhoneNumber(PhoneNumberDto phoneNumber);

        GenericServiceResponse<bool> DeletePhoneNumber(PhoneNumberDto phoneNumber);

        GenericServiceResponse<bool> DeletePhoneNumber(Guid Id);
    }
}