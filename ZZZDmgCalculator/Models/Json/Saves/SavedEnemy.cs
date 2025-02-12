namespace ZZZDmgCalculator.Models.Json.Saves;

using Enum;

public class SavedEnemy {

	public int Level { get; set; }

	public bool Stunned { get; set; }

	public List<Attributes> Resistances { get; set; } = [];

	public int StunMultiplier { get; set; }

	public List<Attributes> Weaknesses { get; set; } = [];

	public int BaseDefense { get; set; }
}