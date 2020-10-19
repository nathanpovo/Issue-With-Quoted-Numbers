using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace JsonSerializerIssueWithQuotedNumbers
{
    [Collection("Test collection")]
    public class TestFixture
    {
        public readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNameCaseInsensitive = true
        };

        public readonly string ResponseWithAllProperties = "ResponseWithAllProperties.json";
        public readonly string ResponseWithoutUserPlayCount = "ResponseWithoutUserPlayCount.json";
        public readonly string ResponseWithoutWiki = "ResponseWithoutWiki.json";
        public readonly string ResponseWithWikiBeforeUserPlayCount = "ResponseWithWikiBeforeUserPlayCount.json";
    }


    [CollectionDefinition("Test collection")]
    public class TestCollection : ICollectionFixture<TestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
