﻿using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IAddressService
    {
        GenericServiceResponse<IEnumerable<AddressDto>> GetAllAddresses();

        GenericServiceResponse<AddressDto> FindAddressById(int Id);

        GenericServiceResponse<bool> CreateAddress(AddressDto address);

        GenericServiceResponse<bool> UpdateAddress(AddressDto address);

        GenericServiceResponse<bool> DeleteAddress(AddressDto address);

        GenericServiceResponse<bool> DeleteAddress(int Id);
    }
}