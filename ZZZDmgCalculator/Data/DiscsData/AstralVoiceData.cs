namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.BuffTrigger;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Discs;
using static ZZZ.ApiModels.Skills;

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
				Modifiers = new StatModifier
				{
					Stat = QuickDmg, Value = 8, Type = Combat, Shared = true
				}
			}
		]
	};
}