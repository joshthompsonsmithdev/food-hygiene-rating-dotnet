namespace FoodHygieneRatingDotNet.Http
{
    internal class HttpConstants
    {
        public const string FhrHttpProtocol = "https";
        public const string FhrBaseApiUrl = "api.ratings.food.gov.uk";
        public const string FhrApiVersionHeaderKey = "x-api-version";
        public const string FhrApiVersionHeaderValue = "2";

        internal class Endpoints
        {
            public const string RegionsPaged = "Regions/{0}/{1}";
            public const string RegionsPagedBasic = "Regions/basic/{0}/{1}";
            public const string RegionsBasic = "Regions/basic";
            public const string Regions = "Regions";
            public const string Region = "Regions/{0}";

            public const string AuthoritiesPaged = "Authorities/{0}/{1}";
            public const string AuthoritiesPagedBasic = "Authorities/basic/{0}/{1}";
            public const string AuthoritiesBasic = "Authorities/basic";
            public const string Authorities = "Authorities";
            public const string Authority = "Authorities/{0}";

            public const string BusinessTypesPaged = "BusinessTypes/{0}/{1}";
            public const string BusinessTypesPagedBasic = "BusinessTypes/basic/{0}/{1}";
            public const string BusinessTypesBasic = "BusinessTypes/basic";
            public const string BusinessTypes = "BusinessTypes";
            public const string BusinessType = "BusinessTypes/{0}";

            public const string CountriesPaged = "Countries/{0}/{1}";
            public const string CountriesPagedBasic = "Countries/basic/{0}/{1}";
            public const string CountriesBasic = "Countries/basic";
            public const string Countries = "Countries";
            public const string Country = "Countries/{0}";

            public const string EstablishmentsPagedBasic = "Establishments/basic/{0}/{1}";
            public const string EstablishmentsBasic = "Establishments/basic";
            public const string Establishments = "Establishments";
            public const string Establishment = "Establishments/{0}";

            public const string SchemeTypes = "SchemeTypes";
            public const string SortOptions = "SortOptions";
            public const string ScoreDescriptors = "ScoreDescriptors?establishmentId={0}";
            public const string Ratings = "Ratings";
            public const string RatingOperators = "RatingOperators";
        }
    }
}