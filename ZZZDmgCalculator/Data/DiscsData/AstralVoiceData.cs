namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.BuffTrigger;
using static ZZZ.ApiModels.Discs;
using static ZZZ.ApiModels.Skills;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;

[InfoData<Discs>(AstralVoice)]
public class AstralVoiceData {
	public readonly static DiscInfo Data = new()
	{
		Uid = AstralVoice,
		StatBuff = new()
		{
			Stat = Atk,
			Value = 10,
			Type = BasePercent
		},
		Buffs =
		[
			new()
			{
				Type = Stack,
				Stacks = 3,
				SkillCondition = s => s.Type is Quick,
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Value = 8, Type = Combat, Shared = true
				}
			}
		]
	};
}