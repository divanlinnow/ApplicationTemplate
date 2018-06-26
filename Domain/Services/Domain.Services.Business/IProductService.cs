﻿using Domain.Models.Business;
using Domain.Services.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IProductService
    {
        GenericServiceResponse<IEnumerable<ProductDto>> GetAllProducts();

        GenericServiceResponse<ProductDto> FindProductById(Guid Id);

        GenericServiceResponse<bool> CreateProduct(ProductDto product);

        GenericServiceResponse<bool> UpdateProduct(ProductDto product);

        GenericServiceResponse<bool> DeleteProduct(ProductDto product);

        GenericServiceResponse<bool> DeleteProduct(Guid Id);
    }
}