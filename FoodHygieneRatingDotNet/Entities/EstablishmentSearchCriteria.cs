namespace FoodHygieneRatingDotNet.Entities
{
    public class EstablishmentSearchCriteria
    {
        /// <summary>
        /// Terms to search for within the Business address and postcode of the establishments.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Terms to search for within the Business name of the establishments.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The longitude of the centre point of a spatial query.
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// The latitude of the centre point of a spatial query.
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// The max distance limit in miles from the centre of the spatial query. 
        /// Note: This value maybe capped by the system to limit the size of the result set.
        /// </summary>
        public string MaxDistanceLimit { get; set; }

        /// <summary>
        /// Filter the results based on the Business Type of the establishment (See BusinessTypes for more details).
        /// </summary>
        public string BusinessTypeId { get; set; }

        /// <summary>
        /// Filter the results based on the Scheme Type (FHRS or FHIS) of the establishment (See SchemeTypes for more details). 
        /// Valid options are 'FHRS' and 'FHIS'.
        /// </summary>
        public string SchemeTypeKey { get; set; }

        /// <summary>
        /// Filter the results based on the FHIS/FHRS Rating of the establishment (See Ratings for more details).
        /// Valid options for FHRS are '0', '1', '2', '3', '4' and '5' and for FHIS are 'Pass', 'ImprovementRequired',  'AwaitingPublication', 'AwatingInspection' and 'Exempt'.
        /// </summary>
        public string RatingKey { get; set; }

        /// <summary>
        /// Operator for increasing the flexibility of the rating search. 
        /// Valid options are 'LessThanOrEqual', 'GreaterThanOrEqual' and 'Equal', the default for this value is 'Equal' (See RatingOperators for more details). 
        /// Note: These operators only function on FHRS Ratings.
        /// </summary>
        public string RatingOperatorKey { get; set; }

        /// <summary>
        /// Filter the results based on the Local Authority of the establishment (See Authorities for more details).
        /// </summary>
        public string LocalAuthorityId { get; set; }

        /// <summary>
        /// Filter the results based on the Country of the establishment (See Countries for more details).
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// Set the options for sort field and direction of the results (See SortOptions for more details). 
        /// Valid options are 'Relevance', 'rating', 'desc_rating', 'alpha', 'desc_alpha' and 'distance'
        /// </summary>
        public string SortOptionKey { get; set; }

        /// <summary>
        /// The page number of the result set to return.
        /// </summary>
        public string PageNumber { get; set; }

        /// <summary>
        /// Size of the page of results to return. 
        /// (Note: Maximum value is system capped, so less results maybe returned than requested)
        /// </summary>
        public string PageSize { get; set; }
    }
}
