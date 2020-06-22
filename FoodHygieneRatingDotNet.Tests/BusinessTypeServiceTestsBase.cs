using Moq;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services;

namespace FoodHygieneRatingDotNet.Tests
{
    public abstract class BusinessTypeServiceTestsBase : ServiceTestsBase
    {
        protected BusinessTypeService Service { get;}

        protected IHttpService HttpService { get; }

        protected Mock<IHttpProvider> MockHttpProvider { get; }

        protected BusinessTypeServiceTestsBase()
        {
            MockHttpProvider = new Mock<IHttpProvider>();
            HttpService = new HttpService(MockHttpProvider.Object);
            Service = new BusinessTypeService(HttpService);
        }
    }
}
