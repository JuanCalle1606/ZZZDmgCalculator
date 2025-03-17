namespace ZZZDmgCalculator.Data;

using Models.Enum;
using Models.Info;
using static Models.Enum.Anomalies;
using static Models.Enum.Attributes;

[UrlTemplate("icons/factions/{Icon}_Icon.webp")]
[InfoData<Anomalies>]
public static class AnomaliesData {
	public readonly static Dictionary<Anomalies, AnomalyInfo> Data = new()
	{
		[Assault] = new()
		{
			Uid = Assault,
			DmgMultiplier = 713,
			DisorderMultiplier = 7.5,
			Attribute = Physical,
		},
		[Shatter] = new()
		{
			Uid = Shatter,
			DmgMultiplier = 500,
			DisorderMultiplier = 7.5,
			Attribute = Ice,
		},
		[Corruption] = new()
		{
			Uid = Corruption,
			DmgMultiplier = 1250,
			DisorderMultiplier = 62.5,
			DisorderFactor = 2,
			Attribute = Ether,
		},
		[Burn] = new()
		{
			Uid = Burn,
			DmgMultiplier = 1000,
			DisorderMultiplier = 50,
			DisorderFactor = 2,
			Attribute = Fire,
		},
		[Shock] = new()
		{
			Uid = Shock,
			DmgMultiplier = 1250,
			DisorderMultiplier = 125,
			Attribute = Electric,
		},
		
		// Special anomalies
		[Frostburn] = new()
		{
			Uid = Frostburn,
			DmgMultiplier = 0,
			AgentScale = true
		},
		
		// Ticks
		[CorruptionTick] = new()
		{
			Uid = CorruptionTick,
			DmgMultiplier = 62.5,
			Attribute = Ether,
		},
		[BurnTick] = new()
		{
			Uid = BurnTick,
			DmgMultiplier = 50,
			Attribute = Fire,
		},
		[ShockTick] = new()
		{
			Uid = ShockTick,
			DmgMultiplier = 125,
			Attribute = Electric,
		},
	};
}