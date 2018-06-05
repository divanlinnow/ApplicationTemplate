using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface ICityService
    {
        GenericServiceResponse<IEnumerable<CityDto>> GetAllCities();

        GenericServiceResponse<CityDto> FindCityById(Guid Id);

        GenericServiceResponse<bool> CreateCity(CityDto city);

        GenericServiceResponse<bool> UpdateCity(CityDto city);

        GenericServiceResponse<bool> DeleteCity(CityDto city);

        GenericServiceResponse<bool> DeleteCity(Guid Id);
    }
}