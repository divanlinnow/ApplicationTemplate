using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface ICurrencyService
    {
        GenericServiceResponse<IEnumerable<CurrencyDto>> GetAllCurrencies();

        GenericServiceResponse<CurrencyDto> FindCurrencyById(int Id);

        GenericServiceResponse<bool> CreateCurrency(CurrencyDto currency);

        GenericServiceResponse<bool> UpdateCurrency(CurrencyDto currency);

        GenericServiceResponse<bool> DeleteCurrency(CurrencyDto currency);

        GenericServiceResponse<bool> DeleteCurrency(int Id);
    }
}