using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Jellyfin.Server.Integration.Tests
{
    /// <summary>
    /// Defines the test for encoded querystrings in the url.
    /// </summary>
    public class EncodedQueryStringTest : IClassFixture<JellyfinApplicationFactory>
    {
        private readonly JellyfinApplicationFactory _factory;

        public EncodedQueryStringTest(JellyfinApplicationFactory factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("a=1&b=2&c=3", "a=1&b=2&c=3")] // won't be processed as there is more than 1.
        [InlineData("a=1", "a=1")] // won't be processed as it has a value
        [InlineData("a%3D1%26b%3D2%26c%3D3", "a=1&b=2&c=3")] // will be processed.
        public async Task Ensure_Decoding_Of_Urls_Is_Working(string sourceUrl, string unencodedUrl)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("Encoder/UrlDecode?" + sourceUrl).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string reply = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.Equal(unencodedUrl, reply);
        }
    }
}
