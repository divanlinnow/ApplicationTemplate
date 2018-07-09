using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Services.Core;
using ORM.EF.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Business
{
    public class ProductService : ServiceBase, IProductService
    {
        #region Constructor

        public ProductService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<ProductDto>> GetAllProducts()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<ProductDto>>>((response) =>
            {
                response.Result = Repository.All<Product>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllProducts' was unable to find any product records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<ProductDto> FindProductById(int Id)
        {
            return TryExecute<GenericServiceResponse<ProductDto>>((response) =>
            {
                response.Result = Repository.FindById<Product>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindProductById' was unable to find the given product record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateProduct(ProductDto product)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(product.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateProduct' was unable to insert a new product record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateProduct(ProductDto product)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(product.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateProduct' was unable to update the given product record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteProduct(ProductDto product)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(product.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteProduct' was unable to delete the given product record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteProduct(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Product>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteProduct' was unable to delete the given product record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}