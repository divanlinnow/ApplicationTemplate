using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IPhoneNumberService
    {
        GenericServiceResponse<IEnumerable<PhoneNumberDto>> GetAllPhoneNumbers();

        GenericServiceResponse<PhoneNumberDto> FindPhoneNumberById(int Id);

        GenericServiceResponse<bool> CreatePhoneNumber(PhoneNumberDto phoneNumber);

        GenericServiceResponse<bool> UpdatePhoneNumber(PhoneNumberDto phoneNumber);

        GenericServiceResponse<bool> DeletePhoneNumber(PhoneNumberDto phoneNumber);

        GenericServiceResponse<bool> DeletePhoneNumber(int Id);
    }
}