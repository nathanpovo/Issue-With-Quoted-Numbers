# nullable enable

namespace JsonSerializerIssueWithQuotedNumbers.Entities
{
    public class ResultWithNoConstructor
    {
        public AlbumWithNoConstructor? Album { get; init; }
    }

    public class AlbumWithNoConstructor
    {
        public string? Name { get; init; }
        public string? Artist { get; init; }
        public long? UserPlayCount { get; init; }
    }
}
