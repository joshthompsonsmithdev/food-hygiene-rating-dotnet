## Food Hygiene Rating DotNet

[![Nuget](https://img.shields.io/nuget/v/FoodHygieneRatingDotNet)](https://www.nuget.org/packages/FoodHygieneRatingDotNet/)

> A C# .NET library for interacting with the government food hygiene rating API.

### Getting Started

First, you'll need to configure the following in your `Startup.cs` file:

`services.AddFoodHygieneRatingDotNet();`

Once, you've included the 'add' method, you can simply inject the required service and call one of its associated methods, like so: 

```c#
[ApiController, Route("api/[controller]")]
public class AuthorityController : Controller
{
    private readonly IAuthorityService _authorityService;

    public AuthorityController(IAuthorityService authorityService)
    {
        _authorityService = authorityService;
    }

    [HttpGet, Route("paged")]
    public async Task<FhrResponse<Authorities>> GetPagedAsync(int page, int size)
    {
        return await _authorityService.GetPagedAsync(page, size);
    }
}
```

### The API's

Each of the respective [Food Hygiene Rating API](https://api.ratings.food.gov.uk/help) calls have been wrapped into associated methods and can be invoked asynchronously.

A full breakdown of each API's associated class and method(s), can be found below:

### Regions
*RegionService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetPagedAsync(`int`, `int`)        | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Regions-pageNumber-pageSize)| `FhrResponse<Regions>` |
| GetPagedBasicAsync(`int`, `int`)   | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Regions-basic-pageNumber-pageSize)| `FhrResponse<Regions>` |
| GetBasicAsync                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Regions-basic)| `FhrResponse<Regions>` |
| GetAsync                       | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Regions)| `FhrResponse<Regions>` |
| GetAsync(`int`)                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Regions-id)| `FhrResponse<Region>` |

---
### Authorities
*AuthorityService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetPagedAsync(`int`, `int`)        | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Authorities-pageNumber-pageSize)| `FhrResponse<Authorities>` |
| GetPagedBasicAsync(`int`, `int`)   | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Authorities-basic-pageNumber-pageSize)| `FhrResponse<Authorities>` |
| GetBasicAsync                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Authorities-basic)| `FhrResponse<Authorities>` |
| GetAsync                       | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Authorities)| `FhrResponse<Authorities>` |
| GetAsync(`int`)                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Authorities-id)| `FhrResponse<Authority>` |

---
### Business Types
*BusinessTypeService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetPagedAsync(`int`, `int`)        | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-BusinessTypes-pageNumber-pageSize)| `FhrResponse<BusinessTypes>` |
| GetPagedBasicAsync(`int`, `int`)   | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-BusinessTypes-basic-pageNumber-pageSize)| `FhrResponse<BusinessTypes>` |
| GetBasicAsync                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-BusinessTypes-basic)| `FhrResponse<BusinessTypes>` |
| GetAsync                       | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-BusinessTypes)| `FhrResponse<BusinessTypes>` |
| GetAsync(`int`)                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-BusinessTypes-id)| `FhrResponse<BusinessType>` |

---
### Countries
*CountryService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetPagedAsync(`int`, `int`)        | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Countries-pageNumber-pageSize)| `FhrResponse<Countries>` |
| GetPagedBasicAsync(`int`, `int`)   | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Countries-basic-pageNumber-pageSize)| `FhrResponse<Countries>` |
| GetBasicAsync                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Countries-basic)| `FhrResponse<Countries>` |
| GetAsync                       | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Countries)| `FhrResponse<Countries>` |
| GetAsync(`int`)                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Countries-id)| `FhrResponse<Country>` |

---
### Establishments
*EstablishmentService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetPagedBasicAsync(`int`, `int`)   | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Establishments-basic-pageNumber-pageSize)| `FhrResponse<Establishments>` |
| GetBasicAsync                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Establishments-basic)| `FhrResponse<Establishments>` |
| GetAsync(`EstablishmentSearchCriteria`) | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Establishments_name_address_longitude_latitude_maxDistanceLimit_businessTypeId_schemeTypeKey_ratingKey_ratingOperatorKey_localAuthorityId_countryId_sortOptionKey_pageNumber_pageSize)| `FhrResponse<Establishments>` |
| GetAsync(`int`)                  | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Establishments-id)| `FhrResponse<Establishment>` |

---
### Scheme Types
*SchemeTypeService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetAsync() | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-SchemeTypes)| `FhrResponse<SchemeTypes>` |

---
### Sort Options
*SortOptionService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetAsync() | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-SortOptions)| `FhrResponse<SortOptions>` |

---
### Score Descriptors
*ScoreDescriptorService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetAsync(`int`) | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-ScoreDescriptors_establishmentId)| `FhrResponse<ScoreDescriptors>` |

---
### Ratings
*RatingService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetAsync() | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-Ratings)| `FhrResponse<Ratings>` |

---
### Rating Operators
*RatingOperatorService.cs*.

| Method Name                    | Async  | FHRS API Reference | Return Type   | 
|:-------------------------------|:-------|:--------------|:--------------|     
| GetAsync() | Yes    |[View Documentation](https://api.ratings.food.gov.uk/Help/Api/GET-RatingOperators)| `FhrResponse<RatingOperators>` |
