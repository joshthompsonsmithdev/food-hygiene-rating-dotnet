using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Http
{
    /// <summary>
    /// Wrapper around the <see cref="HttpClient"/>; allowing us to
    /// mock up http requests and responses easily.
    /// </summary>
    public interface IHttpProvider
    {
        /// <summary>Send a GET request to the specified Uri as an asynchronous operation.</summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri">requestUri</paramref> is null.</exception>
        /// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        Task<HttpResponseMessage> GetAsync(string requestUri);


        /// <summary>Send a GET request to the specified Uri as an asynchronous operation.</summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="headers">The additional headers the request should attach.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri">requestUri</paramref> is null.</exception>
        /// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        Task<HttpResponseMessage> GetAsync(string requestUri, IDictionary<string, string> headers);
    }
}
