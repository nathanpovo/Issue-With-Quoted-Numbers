﻿using JsonSerializerIssueWithQuotedNumbers.Entities;
using System.IO;
using System.Text.Json;
using Xunit;

namespace JsonSerializerIssueWithQuotedNumbers
{
    /// <summary>
    /// Testing the JSON deserializer using the synchronous method.
    /// </summary>
    [Collection("Test collection")]
    public class SynchronousTests
    {
        private readonly TestFixture fixture;

        public SynchronousTests(TestFixture testFixture)
        {
            fixture = testFixture;
        }

        /// <summary>
        /// This test is failing!!
        /// </summary>
        [Fact]
        public void ResponseWithAllPropertiesTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithAllProperties);
            string text = File.ReadAllText(path);

            Result result = JsonSerializer.Deserialize<Result>(text, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.True(result.Album.UserPlayCount.HasValue);
            Assert.InRange(result.Album.UserPlayCount.Value, 0, long.MaxValue);
        }

        [Fact]
        public void ResponseWithoutUserPlayCountTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithoutUserPlayCount);
            string text = File.ReadAllText(path);

            Result result = JsonSerializer.Deserialize<Result>(text, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.False(result.Album.UserPlayCount.HasValue);
        }

        [Fact]
        public void ResponseWithoutWikiTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithoutWiki);
            string text = File.ReadAllText(path);

            Result result = JsonSerializer.Deserialize<Result>(text, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.True(result.Album.UserPlayCount.HasValue);
            Assert.InRange(result.Album.UserPlayCount.Value, 0, long.MaxValue);
        }

        [Fact]
        public void ResponseWithWikiBeforeUserPlayCountTest()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fixture.ResponseWithWikiBeforeUserPlayCount);
            string text = File.ReadAllText(path);

            Result result = JsonSerializer.Deserialize<Result>(text, fixture.JsonSerializerOptions);

            Assert.NotNull(result);
            Assert.NotNull(result.Album);
            Assert.True(result.Album.UserPlayCount.HasValue);
            Assert.InRange(result.Album.UserPlayCount.Value, 0, long.MaxValue);
        }
    }
}
