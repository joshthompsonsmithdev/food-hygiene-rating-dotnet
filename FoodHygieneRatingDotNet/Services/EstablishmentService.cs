using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FoodHygieneRatingDotNet.Services
{
    /// <summary>
    /// Retrieves various data that's specific to establishments.
    /// </summary>
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IHttpService _httpService;

        public EstablishmentService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// Retrieves a details of a single establishment, selected by Id.
        /// </summary>
        /// <param name="id">The id of the establishment.</param>
        /// <returns>Returns a details of a single establishment, selected by Id.</returns>
        public async Task<FhrResponse<Establishment>> GetAsync(int id)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Establishment, id);

            var response = await _httpService.GetAsync<Establishment>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of establishments, details can be retrieved by calling establishments/{id}.
        /// </summary>
        /// <returns>Returns a basic list of establishments, details can be retrieved by calling establishments/{id}.</returns>
        public async Task<FhrResponse<Establishments>> GetBasicAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.EstablishmentsBasic);

            var response = await _httpService.GetAsync<Establishments>(url);

            return response;
        }

        /// <inheritdoc />
        public async Task<FhrResponse<Establishments>> GetBasicAsync(EstablishmentSearchCriteria criteria)
        {
            var url =  BuildEstablishmentCriteriaUrl(HttpConstants.Endpoints.EstablishmentsBasic, criteria);

            var response = await _httpService.GetAsync<Establishments>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of establishments (id/name), details can be retrieved by calling establishments/{id}, 
        /// page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>
        /// Returns a basic list of establishments (id/name), details can be retrieved by calling establishments/{id}, 
        /// page parameters allow for page number and size specification.
        /// </returns>
        public async Task<FhrResponse<Establishments>> GetPagedBasicAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.EstablishmentsPagedBasic, page, size);

            var response = await _httpService.GetAsync<Establishments>(url);

            return response;
        }

        /// <summary>
        /// Builds a valid Establishment Search API URL.
        /// </summary>
        /// <param name="endpoint">The endpoint for the search API.</param>
        /// <param name="criteria">The criteria to search.</param>
        /// <returns></returns>
        private string BuildEstablishmentCriteriaUrl(string endpoint, EstablishmentSearchCriteria criteria)
        {
            var queryStringParameters = new List<string>();

            if (criteria != null)
            {
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.Name, criteria.Name, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.Address, criteria.Address, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.Longitude, criteria.Longitude, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.Latitude, criteria.Latitude, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.MaxDistanceLimit, criteria.MaxDistanceLimit, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.BusinessTypeId, criteria.BusinessTypeId, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.SchemeTypeKey, criteria.SchemeTypeKey, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.RatingKey, criteria.RatingKey, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.RatingOperatorKey, criteria.RatingOperatorKey, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.LocalAuthorityId, criteria.LocalAuthorityId, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.CountryId, criteria.CountryId, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.SortOptionKey, criteria.SortOptionKey, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.PageNumber, criteria.PageNumber, queryStringParameters);
                AddQueryKeyValueToSource(EntityConstants.EstablishmentSearchCriteriaKeys.PageSize, criteria.PageSize, queryStringParameters);
            }

            return queryStringParameters.Any()
                ?
                $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/{endpoint}?{string.Join("&", queryStringParameters)}"
                :
                $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/{endpoint}";
        }

        /// <summary>
        /// Checks the given <paramref name="value"/> and adds to the <paramref name="source"/> collection, if it's not null.
        /// </summary>
        /// <param name="key">The key for this value.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="source">The source collection to add the value to.</param>
        private void AddQueryKeyValueToSource(string key, string value, List<string> source)
        {
            source.Add($"{key}={HttpUtility.UrlEncode(value)}");
        }
    }
}