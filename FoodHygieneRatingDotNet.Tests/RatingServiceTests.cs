using Moq;
using NUnit.Framework;
using FoodHygieneRatingDotNet.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Tests
{
    public class RatingServiceTests
    {
        public class GetAsyncMethod : RatingServiceTestsBase
        {
            [Test]
            public async Task ProvidesCorrectApiUrl()
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(string.Empty)));

                // Act
                await Service.GetAsync();

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Ratings";
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
                await Service.GetAsync();

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

            [TestCase("{ ratings: [{ ratingName: \"Foo\" }] }", "Foo")]
            [TestCase("{ ratings: [{ ratingName: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetAsync();

                // Assert
                Assert.AreEqual(response.Response.Data[0].RatingName, expectedName);
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
                var response = await Service.GetAsync();

                // Assert
                Assert.IsNull(response.Response);
            }
        }
    }
}