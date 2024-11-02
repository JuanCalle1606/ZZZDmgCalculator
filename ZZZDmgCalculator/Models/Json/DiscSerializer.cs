namespace ZZZDmgCalculator.Models.Json;

using System.Text.Json;
using System.Text.Json.Serialization;
using State;
using ZZZ.ApiModels;
using Enum=System.Enum;

public class DiscSerializer : JsonConverter<DiscState> {

	public override DiscState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		var getDummy = options.Converters.OfType<DummyConverter>().First();
		var info = getDummy.Info;
		string id = null!;
		var level = 0;
		var rank = ItemRank.S;
		string mainStat = null!;
		
		DiscState dev = null!;

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
						id = reader.GetString()!;
						break;
					case "Level":
						level = reader.GetInt32();
						break;
					case "Rank":
						rank = (ItemRank)reader.GetInt32();
						break;
					case "MainStat":
						mainStat = reader.GetString()!;
						break;
					case "SubStats":
						var subStatsList = new List<(string, int)>();
						while (reader.Read())
						{
							if (reader.TokenType == JsonTokenType.EndArray)
							{
								break;
							}
							if (reader.TokenType != JsonTokenType.StartObject) continue;
							string? subStat = null;
							var roll = 0;
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
										case "SubStat":
											subStat = reader.GetString();
											break;
										case "Roll":
											roll = reader.GetInt32();
											break;
									}
								}
							}
							subStatsList.Add((subStat!, roll));
						}
						dev = new(info[Enum.Parse<Discs>(id)], info[Enum.Parse<DiscStats>(mainStat)])
						{
							Level = level,
							Rank = rank
						};
						
						foreach (var (subStat, roll) in subStatsList) {
							dev.SubStats.Add(info[Enum.Parse<DiscStats>(subStat)], roll);
						}
						break;
				}
			}
		}

		return dev;
	}
	
	
	public override void Write(Utf8JsonWriter writer, DiscState value, JsonSerializerOptions options) {
		writer.WriteStartObject();
		writer.WriteString("Id", value.Info.Id);
		writer.WriteNumber("Level", value.Level);
		writer.WriteNumber("Rank", (int)value.Rank);
		
		writer.WriteString("MainStat", value.MainStatInfo.Id);
		
		
		writer.WritePropertyName("SubStats");
		writer.WriteStartArray();
		var rolls = 0;
		foreach (var stat in value.SubStats) {
			writer.WriteStartObject();

			writer.WriteString("SubStat", stat.Id);
			writer.WriteNumber("Roll", value.SubStats.Rolls[rolls++]);
			
			writer.WriteEndObject();
		}
		writer.WriteEndArray();
		
		writer.WriteEndObject();
	}
}