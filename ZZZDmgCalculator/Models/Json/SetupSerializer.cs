namespace ZZZDmgCalculator.Models.Json;

using System.Text.Json;
using System.Text.Json.Serialization;
using State;

public class SetupSerializer : JsonConverter<SetupState> {

	public override SetupState? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		var dev = new SetupState();

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
					case "Agents":
						var agents = JsonSerializer.Deserialize<AgentState?[]>(ref reader, options);
						if (agents != null)
						{
							for (var index = 0; index < agents.Length; index++)
							{
								var agent = agents[index];
								dev[index] = agent;
							}
						}
						break;
				}
			}
		}

		return dev;
	}

	public override void Write(Utf8JsonWriter writer, SetupState value, JsonSerializerOptions options) {
		writer.WriteStartObject();
		writer.WritePropertyName("Agents");
		writer.WriteStartArray();
		foreach (var agent in value.Agents)
		{
			JsonSerializer.Serialize(writer, agent, options);
		}
		writer.WriteEndArray();
		writer.WriteEndObject();
	}
}