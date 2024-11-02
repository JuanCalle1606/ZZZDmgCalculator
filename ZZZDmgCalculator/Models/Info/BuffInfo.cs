namespace ZZZDmgCalculator.Models.Info;

using System.Text.Json.Serialization;
using Enum;
using Extensions;

public class BuffInfo : BaseInfo {
	public string Description { get; set; } = string.Empty;
	
	public BuffTrigger Type { get; set; }
	/// <summary>
	/// Only used when <see cref="Type"/> is <see cref="BuffTrigger.Stack"/>.
	/// </summary>
	public int Stacks { get; set; }
	
	public double[]?[]? Scales { get; set; }
	
	/// <summary>
	/// A condition that must be met for this buff to be applied or enabled.
	/// </summary>
	[JsonIgnore]
    public Predicate<SkillInfo>? SkillCondition { get; set; }
	
	/// <summary>
	/// A condition that must be met for this buff to be applied or enabled.
	/// </summary>
	[JsonIgnore]
	public Predicate<AbilityInfo>? AbilityCondition { get; set; }
	
	public bool Pass { get; set; }
	
	/// <summary>
	/// This buff depends on another buff, this is used to create a chain of buffs.
	/// If the other buff is not active, this buff is not going to be applied and cannot by enabled on the UI.
	/// </summary>
	public int? Depends { get; set; }
	
	/// <summary>
	/// If <see cref="Depends"/> is set and the dependent buff is stackable, this is the amount of stacks required to enable this buff.
	/// </summary>
	public int? RequiredStacks { get; set; }
	
	public  SingleList<StatModifier> Modifiers { get; set; } = [];
	
	/// <summary>
	/// Mostly used for buffs from cores passive, specifies the maximum amount of the stat that can be applied.
	/// </summary>
	public double? BuffLimit { get; set; }
	
	public static implicit operator BuffInfo(StatModifier d) => new() { Modifiers = [d] };
}