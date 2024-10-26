namespace ZZZDmgCalculator.Models.Json;

using System.Text.Json;
using System.Text.Json.Serialization;
using Enum;
using State;
using Enum=System.Enum;

public class EngineSerializer : JsonConverter<EngineState> {

	public override EngineState? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		var getDummy = options.Converters.OfType<DummyConverter>().First();
		var info = getDummy.Info;

		while (reader.Read())
		{
			if (reader.TokenType == JsonTokenType.EndObject)
			{
				break;
			}
			if (reader.TokenType == JsonTokenType.PropertyName)
			{
				var propertyName = reader.GetString();
				reader.Read();
				switch (propertyName)
				{
					case "Id":
						var id = reader.GetString();
						var engine = info[Enum.Parse<Engines>(id!)];

						var dev = new EngineState(engine);
						while (reader.Read())
						{
							if (reader.TokenType == JsonTokenType.EndObject)
							{
								break;
							}
							if (reader.TokenType == JsonTokenType.PropertyName)
							{
								var propertyName2 = reader.GetString();
								reader.Read();
								switch (propertyName2)
								{
									case "Ascension":
										dev.Ascension = (AscensionState)reader.GetInt32();
										break;
									case "Refinement":
										dev.Refinement = reader.GetInt32();
										break;
								}
							}
						}
						return dev;
				}
			}
		}
		return null;
	}
	public override void Write(Utf8JsonWriter writer, EngineState value, JsonSerializerOptions options) {
		writer.WriteStartObject();
		writer.WriteString("Id", value.Info.Id);
		writer.WriteNumber("Ascension", (int)value.Ascension);
		writer.WriteNumber("Refinement", value.Refinement);
		writer.WriteEndObject();
	}
}