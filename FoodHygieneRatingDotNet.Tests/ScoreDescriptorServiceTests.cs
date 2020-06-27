using Moq;
using NUnit.Framework;
using FoodHygieneRatingDotNet.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Tests
{
    public class ScoreDescriptorServiceTests
    {
        public class GetAsyncIntMethod : ScoreDescriptorServiceTestsBase
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
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/ScoreDescriptors?establishmentId={id}";
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

            [TestCase("{ scoreDescriptors: [{ description: \"Foo\" }] }", "Foo")]
            [TestCase("{ scoreDescriptors: [{ description: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedDescription)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetAsync(0);

                // Assert
                Assert.AreEqual(response.Response.Data[0].Description, expectedDescription);
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
    }
}