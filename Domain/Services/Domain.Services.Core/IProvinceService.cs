using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IProvinceService
    {
        GenericServiceResponse<IEnumerable<ProvinceDto>> GetAllProvinces();

        GenericServiceResponse<ProvinceDto> FindProvinceById(Guid Id);

        GenericServiceResponse<bool> CreateProvince(ProvinceDto province);

        GenericServiceResponse<bool> UpdateProvince(ProvinceDto province);

        GenericServiceResponse<bool> DeleteProvince(ProvinceDto province);

        GenericServiceResponse<bool> DeleteProvince(Guid Id);
    }
}