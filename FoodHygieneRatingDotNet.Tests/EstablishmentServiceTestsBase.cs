using Moq;
using FoodHygieneRatingDotNet.Services;
using FoodHygieneRatingDotNet.Http;

namespace FoodHygieneRatingDotNet.Tests
{
    public class EstablishmentServiceTestsBase : ServiceTestsBase
    {
        protected EstablishmentService Service { get; private set; }

        protected IHttpService HttpService { get; private set; }

        protected Mock<IHttpProvider> MockHttpProvider { get; private set; }

        public EstablishmentServiceTestsBase()
        {
            MockHttpProvider = new Mock<IHttpProvider>();
            HttpService = new HttpService(MockHttpProvider.Object);
            Service = new EstablishmentService(HttpService);
        }
    }
}
