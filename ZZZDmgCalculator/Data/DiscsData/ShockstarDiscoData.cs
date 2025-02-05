namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Discs>(Discs.ShockstarDisco)]
public class ShockstarDiscoData {
	public readonly static DiscInfo Data = new ()
	{
		Uid = Discs.ShockstarDisco,
		StatBuff = new ()
		{
			Stat = Stats.Impact,
			Value = 6,
			Type = StatModifiers.BasePercent
		},
		Buffs = new BuffInfo()
		{
			Type = BuffTrigger.Permanent,
			SkillCondition = info => info.Type is Skills.Basic or Skills.Dash or Skills.Dodge,
			Modifiers = new StatModifier
			{
				Stat = Stats.Daze,
				Value = 20,
				Type = StatModifiers.Combat
			}
		}
	};
}