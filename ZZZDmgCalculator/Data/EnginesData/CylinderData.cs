namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Cylinder)]
public class CylinderData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Cylinder),
		Icon = "Big_Cylinder",
		Rank = ItemRank.A,
		Type = Specialties.Defense,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["TheVault.Main"],
		SubStat = new()
		{
			Stat = Stats.Def,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark2.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Spring.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.DmgReduction
				}
			}
		],
		Skill = new()
		{
			Stat = Stats.Def,
			Scales = EngineScales.Templates["Cylinder.Skill"],
			Engine = true
		}
	};
}