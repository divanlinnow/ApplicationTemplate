using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface ILanguageService
    {
        GenericServiceResponse<IEnumerable<LanguageDto>> GetAllLanguages();

        GenericServiceResponse<LanguageDto> FindLanguageById(int Id);

        GenericServiceResponse<bool> CreateLanguage(LanguageDto language);

        GenericServiceResponse<bool> UpdateLanguage(LanguageDto language);

        GenericServiceResponse<bool> DeleteLanguage(LanguageDto language);

        GenericServiceResponse<bool> DeleteLanguage(int Id);
    }
}