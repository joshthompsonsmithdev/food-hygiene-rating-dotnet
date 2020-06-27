using Moq;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services;

namespace FoodHygieneRatingDotNet.Tests
{
    public abstract class CountryServiceTestsBase : ServiceTestsBase
    {
        protected CountryService Service { get; }

        protected IHttpService HttpService { get; }

        protected Mock<IHttpProvider> MockHttpProvider { get; }

        protected CountryServiceTestsBase()
        {
            MockHttpProvider = new Mock<IHttpProvider>();
            HttpService = new HttpService(MockHttpProvider.Object);
            Service = new CountryService(HttpService);
        }
    }
}
