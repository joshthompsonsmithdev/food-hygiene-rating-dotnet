using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Entities;

namespace FoodHygieneRatingDotNet.Tests
{
    public class EstablishmentServiceTests
    {
        public class GetAsyncIntMethod : EstablishmentServiceTestsBase
        {
            [TestCase(1)]
            [TestCase(5)]
            public async Task ProvidesCorrectApiUrl(int id)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetAsync(id);

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Establishments/{id}";
                MockHttpProvider.Verify(http => http.GetAsync(It.Is<string>(response => response == expected), It.IsAny<IDictionary<string, string>>()));
            }

            [Test]
            public async Task ProvidesCorrectApiHeaders()
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetAsync(0);

                // Assert
                const string expectedKey = "x-api-version";
                const string expectedValue = "2";
                
                MockHttpProvider
                    .Verify(http => http.GetAsync(It.IsAny<string>(), It.Is<IDictionary<string, string>>
                    (
                        response =>
                        response[expectedKey] != null &&
                        response[expectedKey] == expectedValue
                    )));
            }

            [TestCase("{ addressLine1: \"Foo\" }", "Foo")]
            [TestCase("{ addressLine1: \"Bar\" }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetAsync(0);

                // Assert
                Assert.AreEqual(response.Response.AddressLine1, expectedName);
            }

            [TestCase("some failing string 1")]
            [TestCase("some failing string 2")]

            public async Task SerialisesContentStringToNullWhenInvalid(string content)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetAsync(0);

                // Assert
                Assert.IsNull(response.Response);
            }
        }

        public class GetBasicAsyncMethod : EstablishmentServiceTestsBase
        {
            [Test]
            public async Task ProvidesCorrectApiUrl()
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetBasicAsync();

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Establishments/basic";
                MockHttpProvider.Verify(http => http.GetAsync(It.Is<string>(response => response == expected), It.IsAny<IDictionary<string, string>>()));
            }

            [Test]
            public async Task ProvidesCorrectApiHeaders()
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetBasicAsync();

                // Assert
                const string expectedKey = "x-api-version";
                const string expectedValue = "2";
                
                MockHttpProvider
                    .Verify(http => http.GetAsync(It.IsAny<string>(), It.Is<IDictionary<string, string>>
                    (
                        response =>
                        response[expectedKey] != null &&
                        response[expectedKey] == expectedValue
                    )));
            }

            [TestCase("{ establishments: [{ addressLine1: \"Foo\" }] }", "Foo")]
            [TestCase("{ establishments: [{ addressLine1: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetBasicAsync();

                // Assert
                Assert.AreEqual(response.Response.Data[0].AddressLine1, expectedName);
            }

            [TestCase("some failing string 1")]
            [TestCase("some failing string 2")]

            public async Task SerialisesContentStringToNullWhenInvalid(string content)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetBasicAsync();

                // Assert
                Assert.IsNull(response.Response);
            }
        }

        public class GetBasicAsyncEstablishmentSearchCriteriaMethod : EstablishmentServiceTestsBase
        {
            [Test]
            public async Task ProvidesCorrectApiUrlWhenCriteriaNull()
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetBasicAsync(null);

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Establishments/basic";
                MockHttpProvider.Verify(http => http.GetAsync(It.Is<string>(response => response == expected), It.IsAny<IDictionary<string, string>>()));
            }

            [TestCase("Foo")]
            [TestCase("Bar")]
            public async Task ProvidesCorrectApiUrlWhenCriteriaExists(string name)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                var criteria = new EstablishmentSearchCriteria { Name = name };
                await Service.GetBasicAsync(criteria);

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Establishments/basic?name={name}&address=&longitude=&latitude=&maxDistanceLimit=&businessTypeId=&schemeTypeKey=&ratingKey=&ratingOperatorKey=&localAuthorityId=&countryId=&sortOptionKey=&pageNumber=&pageSize=";
                MockHttpProvider.Verify(http => http.GetAsync(It.Is<string>(s => s == expected), It.IsAny<IDictionary<string, string>>()));
            }

            [TestCase("Foo!")]
            [TestCase("#Bar")]
            public async Task ProvidesCorrectEncodedApiUrlWhenCriteriaExists(string name)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                var criteria = new EstablishmentSearchCriteria { Name = name };
                await Service.GetBasicAsync(criteria);

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Establishments/basic?name={WebUtility.UrlEncode(name)}&address=&longitude=&latitude=&maxDistanceLimit=&businessTypeId=&schemeTypeKey=&ratingKey=&ratingOperatorKey=&localAuthorityId=&countryId=&sortOptionKey=&pageNumber=&pageSize=";
                MockHttpProvider.Verify(http => http.GetAsync(It.Is<string>(s => s == expected), It.IsAny<IDictionary<string, string>>()));
            }

            [Test]
            public async Task ProvidesCorrectApiHeaders()
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetBasicAsync();

                // Assert
                const string expectedKey = "x-api-version";
                const string expectedValue = "2";
                
                MockHttpProvider
                    .Verify(http => http.GetAsync(It.IsAny<string>(), It.Is<IDictionary<string, string>>
                    (
                        s =>
                        s[expectedKey] != null &&
                        s[expectedKey] == expectedValue
                    )));
            }
        }

        public class GetPagedBasicAsyncMethod : EstablishmentServiceTestsBase
        {
            [TestCase(1, 20)]
            [TestCase(6, 90)]
            public async Task ProvidesCorrectApiUrl(int page, int size)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetPagedBasicAsync(page, size);

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Establishments/basic/{page}/{size}";
                MockHttpProvider.Verify(http => http.GetAsync(It.Is<string>(response => response == expected), It.IsAny<IDictionary<string, string>>()));
            }

            [Test]
            public async Task ProvidesCorrectApiHeaders()
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetPagedBasicAsync(0, 0);

                // Assert
                const string expectedKey = "x-api-version";
                const string expectedValue = "2";
                
                MockHttpProvider
                    .Verify(http => http.GetAsync(It.IsAny<string>(), It.Is<IDictionary<string, string>>
                    (
                        response =>
                        response[expectedKey] != null &&
                        response[expectedKey] == expectedValue
                    )));
            }

            [TestCase("{ establishments: [{ addressLine1: \"Foo\" }] }", "Foo")]
            [TestCase("{ establishments: [{ addressLine1: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetPagedBasicAsync(1, 1);

                // Assert
                Assert.AreEqual(response.Response.Data[0].AddressLine1, expectedName);
            }

            [TestCase("some failing string 1")]
            [TestCase("some failing string 2")]

            public async Task SerialisesContentStringToNullWhenInvalid(string content)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetPagedBasicAsync(1, 1);

                // Assert
                Assert.IsNull(response.Response);
            }
        }
    }
}
