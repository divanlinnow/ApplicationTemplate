using Domain.Models.Business;
using Domain.Services.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Business
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