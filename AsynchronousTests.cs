using JsonSerializerIssueWithQuotedNumbers.Entities;
using System.IO;
using System.Text.Json;
using Xunit;

namespace JsonSerializerIssueWithQuotedNumbers
{
    /// <summary>
    /// Testing the JSON deserializer using the async method
    /// by passing in a FileStream.
    /// </summary>
    [Collection("Test collection")]
    public class AsynchronousTests
    {
        private readonly TestFixture fixture;

        public AsynchronousTests(TestFixture testFixture)
        {
            fixture = testFixture;
        }

        [Fact]
        public async void ResponseWithAllPropertiesTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithAllProperties);

            using FileStream SourceStream = File.Open(path, FileMode.Open);

            Result result = await JsonSerializer.DeserializeAsync<Result>(SourceStream, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.True(result.Album.UserPlayCount.HasValue);
            Assert.InRange(result.Album.UserPlayCount.Value, 0, long.MaxValue);
        }

        [Fact]
        public async void ResponseWithoutUserPlayCountTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithoutUserPlayCount);

            using FileStream SourceStream = File.Open(path, FileMode.Open);

            Result result = await JsonSerializer.DeserializeAsync<Result>(SourceStream, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.False(result.Album.UserPlayCount.HasValue);
        }

        [Fact]
        public async void ResponseWithoutWikiTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithoutWiki);

            using FileStream SourceStream = File.Open(path, FileMode.Open);

            Result result = await JsonSerializer.DeserializeAsync<Result>(SourceStream, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.True(result.Album.UserPlayCount.HasValue);
            Assert.InRange(result.Album.UserPlayCount.Value, 0, long.MaxValue);
        }

        [Fact]
        public async void ResponseWithWikiBeforeUserPlayCountTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithWikiBeforeUserPlayCount);

            using FileStream SourceStream = File.Open(path, FileMode.Open);

            Result result = await JsonSerializer.DeserializeAsync<Result>(SourceStream, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.True(result.Album.UserPlayCount.HasValue);
            Assert.InRange(result.Album.UserPlayCount.Value, 0, long.MaxValue);
        }
    }
}
