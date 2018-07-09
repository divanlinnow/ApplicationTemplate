using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IProvinceService
    {
        GenericServiceResponse<IEnumerable<ProvinceDto>> GetAllProvinces();

        GenericServiceResponse<ProvinceDto> FindProvinceById(int Id);

        GenericServiceResponse<bool> CreateProvince(ProvinceDto province);

        GenericServiceResponse<bool> UpdateProvince(ProvinceDto province);

        GenericServiceResponse<bool> DeleteProvince(ProvinceDto province);

        GenericServiceResponse<bool> DeleteProvince(int Id);
    }
}