using Domain.Services.Business.ServiceProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Domain.Actions.Core.Tests
{
    [TestClass]
    public class GetAllCurrenciesTests
    {
        private Mock<IServiceProviderBusiness> mockClientServicesProvider;

        [TestInitialize]
        public void Init()
        {
            mockClientServicesProvider = new Mock<IServiceProviderBusiness>();
        }

        //[TestMethod]
        //[TestCategory("Actions")]
        //public void GetAllCurrencies_Action_Success()
        //{
        //    var fakeResponse = new Services.Core.GenericServiceResponse<IEnumerable<CurrencyDto>>
        //    {
        //        Result = TestHelper.CurrencyDtos()
        //    };

        //    mockClientServicesProvider.Setup(x => x.CurrencyService.GetAllCurrencies()).Returns(fakeResponse).Verifiable();

        //    //TODO: Finish unit test

        //    var action = new GetAllCities<GenericListViewModel<CurrencyDto>>(mockClientServicesProvider)
        //    {
        //        OnComplete = model => model
        //    };

        //    var result = action.Invoke();


        //}
    }
}
