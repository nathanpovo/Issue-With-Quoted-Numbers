# nullable enable

using System;
using System.Buffers;
using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerializerIssueWithQuotedNumbers.Entities
{
    public class ResultWithConverter
    {
        public AlbumWithConverter? Album { get; init; }
    }

    public class AlbumWithConverter
    {
        public AlbumWithConverter(string name, string artist)
        {
            Name = name;
            Artist = artist;
        }

        public string Name { get; init; }
        public string Artist { get; init; }

        [JsonConverter(typeof(JsonConverterNullableInt64))]
        public long? UserPlayCount { get; init; }
    }

    public class JsonConverterNullableInt64 : JsonConverter<long?>
    {
        public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                ReadOnlySpan<byte> span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;

                if (Utf8Parser.TryParse(span, out long number, out int bytesConsumed) && span.Length == bytesConsumed)
                {
                    return number;
                }

                if (long.TryParse(reader.GetString(), out number))
                {
                    return number;
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
