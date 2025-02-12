namespace ZZZDmgCalculator.Models.Json.Saves;

using System.Text.Json.Serialization;

public class SavedBuff {

	public string Id { get; set; } = string.Empty;

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int Stacks { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool Enabled { get; set; }
}