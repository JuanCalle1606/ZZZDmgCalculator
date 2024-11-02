namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Decrescent)]
public class DecrescentData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Decrescent),
		Icon = "(Lunar)_Decrescent",
		Rank = ItemRank.B,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark1.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["ElectroLip.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}