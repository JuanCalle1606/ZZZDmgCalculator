namespace ZZZDmgCalculator.Models.Info;

using Extensions;
using ZZZ.ApiModels;

public class AbilityInfo : BaseInfo {
	public string Description { get; set; } = string.Empty;

	public Skills Category { get; set; }

	public SingleList<SkillInfo> Skills { get; set; } = [];

	public SingleList<BuffInfo> Buffs { get; set; } = [];

	public static implicit operator AbilityInfo(StatModifier d) => new() { Buffs = [new() { Modifiers = [d] }] };

	public static implicit operator AbilityInfo(SkillInfo d) => new() { Skills = [d] };
	
	public static implicit operator AbilityInfo(BuffInfo d) => new() { Buffs = [d] };
}