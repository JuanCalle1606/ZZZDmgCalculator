namespace ZZZDmgCalculator.Models.Info;

using Enum;

public class StatRequirement {
	/// <summary>
	/// The stat required to enable this buff.
	/// </summary>
	public required Stats Stat { get; set; }
	
	/// <summary>
	/// The value required to enable this buff.
	/// This value is inclusive, meaning that the buff is enabled if the stat is equal or greater than this value.
	/// </summary>
	public double Value { get; set; }

	/// <summary>
	/// The type of stat required to enable this buff.
	/// Only accepts Combat and Base.
	/// </summary>
	public StatModifiers Type { get; set; } = StatModifiers.Combat;
}