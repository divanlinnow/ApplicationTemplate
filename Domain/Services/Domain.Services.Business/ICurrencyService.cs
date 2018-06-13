using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface ICurrencyService
    {
        GenericServiceResponse<IEnumerable<CurrencyDto>> GetAllCurrencies();

        GenericServiceResponse<CurrencyDto> FindCurrencyById(Guid Id);

        GenericServiceResponse<bool> CreateCurrency(CurrencyDto currency);

        GenericServiceResponse<bool> UpdateCurrency(CurrencyDto currency);

        GenericServiceResponse<bool> DeleteCurrency(CurrencyDto currency);

        GenericServiceResponse<bool> DeleteCurrency(Guid Id);
    }
}