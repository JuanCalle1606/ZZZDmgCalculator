namespace ZZZDmgCalculator.Models.Json;

using System.Text.Json;
using System.Text.Json.Serialization;
using Enum;
using State;
using Enum=System.Enum;

public class AgentSerializer : JsonConverter<AgentState> {

	public override AgentState? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
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
						var agent = info[Enum.Parse<Agents>(id!)];

						var dev = new AgentState(agent);
						dev.Loading = true;
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
									case "Cinema":
										dev.Cinema = reader.GetInt32();
										break;
									case "CoreSkillLevel":
										dev.CoreSkillLevel = (CoreSkills)reader.GetInt32();
										break;
									case "Engine":
										dev.Engine = JsonSerializer.Deserialize<EngineState?>(ref reader, options);
										break;
									case "Discs":
										var discs = JsonSerializer.Deserialize<DiscState?[]>(ref reader, options);
										for (var i = 0; i < discs!.Length; i++)
										{
											var disc = discs![i];
											if (disc != null)
											{
												dev.SetDisc(disc, i);
											}
										}
										break;
								}
							}
						}
						dev.Loading = false;
						dev.UpdateAllStats();
						return dev;
				}
			}
		}


		return null;
	}

	public override void Write(Utf8JsonWriter writer, AgentState value, JsonSerializerOptions options) {
		writer.WriteStartObject();
		writer.WriteString("Id", value.Info.Id);
		writer.WriteNumber("Ascension", (int)value.Ascension);
		writer.WriteNumber("Cinema", value.Cinema);
		writer.WriteNumber("CoreSkillLevel", (int)value.CoreSkillLevel);

		
		writer.WritePropertyName("Engine");
		JsonSerializer.Serialize(writer, value.Engine, options);

		writer.WritePropertyName("Discs");
		writer.WriteStartArray();
		foreach (var disc in value.Discs) {
			JsonSerializer.Serialize(writer, disc, options);
		}
		writer.WriteEndArray();


		writer.WriteEndObject();
	}
}