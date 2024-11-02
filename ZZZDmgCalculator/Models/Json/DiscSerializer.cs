namespace ZZZDmgCalculator.Models.Json;

using System.Text.Json;
using System.Text.Json.Serialization;
using State;
using ZZZ.ApiModels;
using Enum=System.Enum;

public class DiscSerializer : JsonConverter<DiscState> {

	public override DiscState? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		var getDummy = options.Converters.OfType<DummyConverter>().First();
		var info = getDummy.Info;
		var mainStats = info.AllStatInfos.Where(i=>i.IsMain).ToArray();
		var subStats = info.AllStatInfos.Where(i=>i.IsSub).ToArray();
		
		string id = null!;
		var level = 0;
		var rank = ItemRank.S;
		string mainStat = null!;
		var mainStatIndex = 0;
		
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
					case "MainStatIndex":
						mainStatIndex = reader.GetInt32();
						break;
					case "SubStats":
						var subStatsList = new List<(string, int, int)>();
						while (reader.Read())
						{
							if (reader.TokenType == JsonTokenType.EndArray)
							{
								break;
							}
							if (reader.TokenType != JsonTokenType.StartObject) continue;
							string? subStat = null;
							var subStatIndex = 0;
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
										case "SubStatIndex":
											subStatIndex = reader.GetInt32();
											break;
										case "Roll":
											roll = reader.GetInt32();
											break;
									}
								}
							}
							subStatsList.Add((subStat!, subStatIndex, roll));
						}
						dev = new(info[Enum.Parse<Discs>(id!)], mainStats.First(s=>s.Id==mainStat).DiscData[mainStatIndex])
						{
							Level = level,
							Rank = rank
						};
						
						foreach (var (subStat, subStatIndex, roll) in subStatsList) {
							dev.SubStats.Add(subStats.First(i=>i.Id == subStat).DiscData[subStatIndex], roll);
						}
						break;
				}
			}
		}

		return dev;
	}
	
	
	public override void Write(Utf8JsonWriter writer, DiscState value, JsonSerializerOptions options) {
		var getDummy = options.Converters.OfType<DummyConverter>().First();
		var info = getDummy.Info;
		var mainStats = info.AllStatInfos.Where(i=>i.IsMain).ToArray();
		var subStats = info.AllStatInfos.Where(i=>i.IsSub).ToArray();
		
		writer.WriteStartObject();
		writer.WriteString("Id", value.Info.Id);
		writer.WriteNumber("Level", value.Level);
		writer.WriteNumber("Rank", (int)value.Rank);
		
		writer.WriteString("MainStat", value.MainStat.ToString());
		var t = mainStats.First(i=>i.Id == value.MainStat.ToString());
		writer.WriteNumber("MainStatIndex", Array.IndexOf(t.DiscData, value.MainStatInfo));
		
		
		writer.WritePropertyName("SubStats");
		writer.WriteStartArray();
		var rolls = 0;
		foreach (var stat in value.SubStats) {
			writer.WriteStartObject();

			writer.WriteString("SubStat", stat.Buff.Stat.ToString());
			var q = subStats.First(i=>i.Id == stat.Buff.Stat.ToString());
			writer.WriteNumber("SubStatIndex", Array.IndexOf(q.DiscData, stat));
			writer.WriteNumber("Roll", value.SubStats.Rolls[rolls++]);
			
			writer.WriteEndObject();
		}
		writer.WriteEndArray();
		
		writer.WriteEndObject();
	}
}