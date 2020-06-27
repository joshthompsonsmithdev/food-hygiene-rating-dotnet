using System.Net.Http;

namespace FoodHygieneRatingDotNet.Tests
{
    public abstract class ServiceTestsBase
    {
        /// <summary>
        /// Instantiates a basic <see cref="HttpResponseMessage"/> with specified <paramref name="content"/>.
        /// </summary>
        /// <param name="content">The content for the response.</param>
        /// <returns>Returns a basic <see cref="HttpResponseMessage"/> with specified <paramref name="content"/></returns>
        protected HttpResponseMessage GenerateHttpResponse(string content)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(content)
            };
        }
    }
}
