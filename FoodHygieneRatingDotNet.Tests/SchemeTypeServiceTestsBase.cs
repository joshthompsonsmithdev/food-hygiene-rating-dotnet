using Moq;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services;

namespace FoodHygieneRatingDotNet.Tests
{
    public abstract class SchemeTypeServiceTestsBase : ServiceTestsBase
    {
        protected SchemeTypeService Service { get; }

        protected IHttpService HttpService { get; }

        protected Mock<IHttpProvider> MockHttpProvider { get; }

        protected SchemeTypeServiceTestsBase()
        {
            MockHttpProvider = new Mock<IHttpProvider>();
            HttpService = new HttpService(MockHttpProvider.Object);
            Service = new SchemeTypeService(HttpService);
        }
    }
}
