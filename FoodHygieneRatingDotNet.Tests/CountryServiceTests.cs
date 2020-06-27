using Moq;
using NUnit.Framework;
using FoodHygieneRatingDotNet.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Tests
{
    public class CountryServiceTests
    {
        public class GetAsyncMethod : CountryServiceTestsBase
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
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Countries";
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

            [TestCase("{ countries: [{ name: \"Foo\" }] }", "Foo")]
            [TestCase("{ countries: [{ name: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetAsync();

                // Assert
                Assert.AreEqual(response.Response.Data[0].Name, expectedName);
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

        public class GetAsyncIntMethod : CountryServiceTestsBase
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
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Countries/{id}";
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

            [TestCase("{ name: \"Foo\" }", "Foo")]
            [TestCase("{ name: \"Bar\" }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetAsync(0);

                // Assert
                Assert.AreEqual(response.Response.Name, expectedName);
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

        public class GetBasicAsyncMethod : CountryServiceTestsBase
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
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Countries/basic";
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

            [TestCase("{ countries: [{ name: \"Foo\" }] }", "Foo")]
            [TestCase("{ countries: [{ name: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetBasicAsync();

                // Assert
                Assert.AreEqual(response.Response.Data[0].Name, expectedName);
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

        public class GetPagedAsyncMethod : CountryServiceTestsBase
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
                await Service.GetPagedAsync(page, size);

                // Assert
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Countries/{page}/{size}";
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
                await Service.GetPagedAsync(0, 0);

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

            [TestCase("{ countries: [{ name: \"Foo\" }] }", "Foo")]
            [TestCase("{ countries: [{ name: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetPagedAsync(1, 1);

                // Assert
                Assert.AreEqual(response.Response.Data[0].Name, expectedName);
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
                var response = await Service.GetPagedAsync(1, 1);

                // Assert
                Assert.IsNull(response.Response);
            }
        }

        public class GetPagedBasicAsyncMethod : CountryServiceTestsBase
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
                var expected = $"{HttpConstants.FhrHttpProtocol}://{HttpConstants.FhrBaseApiUrl}/Countries/basic/{page}/{size}";
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

            [TestCase("{ countries: [{ name: \"Foo\" }] }", "Foo")]
            [TestCase("{ countries: [{ name: \"Bar\" }] }", "Bar")]
            public async Task SerialisesContentStringToCorrectObject(string content, string expectedName)
            {
                // Arrange
                MockHttpProvider
                    .Setup(http => http.GetAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
                    .Returns(Task.FromResult(GenerateHttpResponse(content)));

                // Act
                var response = await Service.GetPagedBasicAsync(1, 1);

                // Assert
                Assert.AreEqual(response.Response.Data[0].Name, expectedName);
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