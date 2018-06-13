using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using Domain.Models.Business;
using Domain.Models.Business.Tests;
using Domain.Services.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Domain.Actions.Core.Tests
{
    [TestClass]
    public class GetAllCurrenciesTests
    {
        private Mock<IClientServicesProvider> mockClientServicesProvider;

        [TestInitialize]
        public void Init()
        {
            mockClientServicesProvider = new Mock<IClientServicesProvider>();
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void GetAllCurrencies_Action_Success()
        {
            var fakeResponse = new GenericServiceResponse<IEnumerable<CurrencyDto>>
            {
                Result = TestHelper.CurrencyDtos()
            };

            //mockClientServicesProvider.Setup(x => x.CurrencyService.GetAllCities()).Returns(fakeResponse).Verifiable();

            ////TODO: Finish unit test

            //var action = new GetAllCities<GenericListViewModel<CurrencyDto>>(mockClientServicesProvider)
            //{
            //    OnComplete = model => model
            //};

            //var result = action.Invoke();


        }
    }
}
