using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("FoodHygieneRatingDotNet.Tests")]

namespace FoodHygieneRatingDotNet.Http
{
    internal class HttpProvider : IHttpProvider
    {
        /// <inheritdoc>
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await GetAsync(requestUri, null);
        }

        /// <inheritdoc>
        public async Task<HttpResponseMessage> GetAsync(string requestUri, IDictionary<string, string> headers)
        {
            using (var httpClient = new HttpClient())
            {
                AppendHeaders(httpClient, headers);

                return await httpClient.GetAsync(requestUri);
            }
        }

        #region Private Methods

        /// <summary>
        /// Appends the specified <paramref name="headers"/> to the default request headers.
        /// </summary>
        /// <param name="headers">The headers to append.</param>
        private void AppendHeaders(HttpClient httpClient, IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        #endregion
    }
}
