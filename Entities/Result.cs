# nullable enable

namespace JsonSerializerIssueWithQuotedNumbers.Entities
{
    public class Result
    {
        public Album? Album { get; init; }
    }

    public class Album
    {
        public Album(string name, string artist)
        {
            Name = name;
            Artist = artist;
        }

        public string Name { get; init; }
        public string Artist { get; init; }

        public long? UserPlayCount { get; init; }
    }
}
