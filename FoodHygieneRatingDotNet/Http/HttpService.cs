using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using FoodHygieneRatingDotNet.Entities;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("FoodHygieneRatingDotNet.Tests")]

namespace FoodHygieneRatingDotNet.Http
{
    internal class HttpService : IHttpService
    {
        private readonly IHttpProvider _httpProvider;

        public HttpService(IHttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        /// <inheritdoc />
        public async Task<FhrResponse<T>> GetAsync<T>(string requestUri) where T : EntityBase
        {
            // Add the version header
            var headers = new Dictionary<string, string>
            {
                {
                    HttpConstants.FhrApiVersionHeaderKey,
                    HttpConstants.FhrApiVersionHeaderValue
                }
            };

            // Get the http response
            var httpResponse = await _httpProvider.GetAsync(requestUri, headers);
            var contentJson = await httpResponse.Content.ReadAsStringAsync();

            try
            {
                // Return our deserialized object
                var response = JsonConvert.DeserializeObject<T>(contentJson);

                return new FhrResponse<T>
                {
                    Response = response,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new FhrResponse<T>
                {
                    Response = null,
                    Message = $"The following error occured: {ex.Message}"
                };
            }
        }

        /// <inheritdoc />
        public string BuildApiUrl(string endpoint, params object[] parameters)
        {
            return $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/{string.Format(endpoint, parameters)}";
        }
    }
}
