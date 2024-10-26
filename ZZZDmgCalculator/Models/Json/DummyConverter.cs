namespace ZZZDmgCalculator.Models.Json;

using System.Text.Json;
using System.Text.Json.Serialization;
using Services;

public class DummyConverter(InfoService info) : JsonConverter<object> {
	
	public InfoService Info { get; } = info;
	
	public override bool CanConvert(Type typeToConvert) => false;
	public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotSupportedException();
	public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options) {
		throw new NotSupportedException();
	}
}