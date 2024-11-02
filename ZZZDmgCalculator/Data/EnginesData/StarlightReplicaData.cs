namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.StarlightReplica)]
public class StarlightReplicaData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.StarlightReplica),
		Icon = "Starlight_Engine_Replica",
		Rank = ItemRank.A,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["TheVault.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["SliceOfTime.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["StarlightReplica.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.PhysicalDmg,
					Type = StatModifiers.Combat
				}
			}
		]
	};
}