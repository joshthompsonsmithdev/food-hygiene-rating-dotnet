using Moq;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services;

namespace FoodHygieneRatingDotNet.Tests
{
    public abstract class ScoreDescriptorServiceTestsBase : ServiceTestsBase
    {
        protected ScoreDescriptorService Service { get; }

        protected IHttpService HttpService { get; }

        protected Mock<IHttpProvider> MockHttpProvider { get; }

        protected ScoreDescriptorServiceTestsBase()
        {
            MockHttpProvider = new Mock<IHttpProvider>();
            HttpService = new HttpService(MockHttpProvider.Object);
            Service = new ScoreDescriptorService(HttpService);
        }
    }
}
