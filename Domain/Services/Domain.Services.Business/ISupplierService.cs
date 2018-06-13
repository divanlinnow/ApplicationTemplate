using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface ISupplierService
    {
        GenericServiceResponse<IEnumerable<SupplierDto>> GetAllSuppliers();

        GenericServiceResponse<SupplierDto> FindSupplierById(Guid Id);

        GenericServiceResponse<bool> CreateSupplier(SupplierDto supplier);

        GenericServiceResponse<bool> UpdateSupplier(SupplierDto supplier);

        GenericServiceResponse<bool> DeleteSupplier(SupplierDto supplier);

        GenericServiceResponse<bool> DeleteSupplier(Guid Id);
    }
}