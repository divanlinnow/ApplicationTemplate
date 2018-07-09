using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface ICountryService
    {
        GenericServiceResponse<IEnumerable<CountryDto>> GetAllCountries();

        GenericServiceResponse<CountryDto> FindCountryById(int Id);

        GenericServiceResponse<bool> CreateCountry(CountryDto country);

        GenericServiceResponse<bool> UpdateCountry(CountryDto country);

        GenericServiceResponse<bool> DeleteCountry(CountryDto country);

        GenericServiceResponse<bool> DeleteCountry(int Id);
    }
}