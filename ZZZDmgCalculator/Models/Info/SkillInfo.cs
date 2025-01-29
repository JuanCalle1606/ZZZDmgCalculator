namespace ZZZDmgCalculator.Models.Info;

using Enum;
using ZZZ.ApiModels;

public class SkillInfo {
	public string DisplayName { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public Stats Stat { get; set; }

	public bool Engine { get; set; }

	public Skills Type { get; set; }

	public Attributes DmgType { get; set; }

	public double Value { get; set; }

	public int Hits { get; set; } = 1;

	public int Ticks { get; set; } = 1;

	public double[]? Dmg { get; set; }
	
	public double[]? Daze { get; set; }

	public bool Cinema { get; set; }
}