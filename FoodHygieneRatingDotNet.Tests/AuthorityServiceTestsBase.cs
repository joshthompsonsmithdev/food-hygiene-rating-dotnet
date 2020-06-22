using Moq;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services;

namespace FoodHygieneRatingDotNet.Tests
{
    public abstract class AuthorityServiceTestsBase : ServiceTestsBase
    {
        protected AuthorityService Service { get; }

        protected IHttpService HttpService { get; }

        protected Mock<IHttpProvider> MockHttpProvider { get; }

        protected AuthorityServiceTestsBase()
        {
            MockHttpProvider = new Mock<IHttpProvider>();
            HttpService = new HttpService(MockHttpProvider.Object);
            Service = new AuthorityService(HttpService);
        }
    }
}
