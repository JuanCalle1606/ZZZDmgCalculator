namespace ZZZDmgCalculator.Data.AgentsData.Belobog;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static AgentScales;
using static Models.Enum.AgentRank;
using static ZZZ.ApiModels.Agents;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Factions;
using static ZZZ.ApiModels.Skills;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static Models.Enum.DodgeTypes;

[InfoData<Agents>(Grace)]
public class GraceData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Grace,
		Icon = "Grace_Howard",
		Attribute = Electric,
		Faction = Belobog,
		Specialty = Specialties.Anomaly,
		AttackType = Pierce,
		DodgeType = Evasion,
		Rank = S,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = Mastery, Value = 12
			},
			new()
			{
				Stat = Atk, Value = 25
			}
		],
		BaseStats =
		[
			Templates["Grace.Atk"],
			Templates["Grace.Hp"],
			Templates["Rina.Def"],
		],
		FinalStats = [0, 83, 152, 115, 1.2],
		CoreBuff = new BuffInfo()
		{
			Scales = [[65, 75.8, 86.6, 97.5, 108.3, 119.1, 130]],
			// todo: add skill condition when implement anomaly build up
			Modifiers = new StatModifier
			{
				Stat = ShockBuildUp, Type = Combat
			}
		},
		AdditionalBuff = new BuffInfo()
		{
			Type = Stack,
			Stacks = 2,
			Modifiers = new StatModifier
			{
				Stat = ShockDmg, Type = Combat, Value = 18, Shared = true
			}
		},
		Abilities =
		[// TODO: look for physical damage
			new()// Basic Attack: High-Pressure Spike
			{
				Id = "HighPressureSpike",
				Category = Basic,
				UseCommonNames = true,
				MaxCommonName = 3,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [55.1, 60.2, 65.3, 70.4, 75.5, 80.6, 85.7, 90.8, 95.9, 101, 106.1, 111.2, 116.3, 121.4, 126.5, 131.6],
						Daze = [18, 18.90, 19.8, 20.7, 21.6, 22.5, 23.4, 24.3, 25.2, 26.1, 27, 27.9, 28.8, 29.7, 30.6, 31.5]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [59.7, 65.2, 70.7, 76.2, 81.7, 87.2, 92.7, 98.2, 103.7, 109.2, 114.7, 120.2, 125.7, 131.2, 136.7, 142.2],
						Daze = [34.7, 36.3, 37.9, 39.5, 41.1, 42.7, 44.3, 45.9, 47.5, 49.1, 50.7, 52.3, 53.9, 55.5, 57.1, 58.7]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [124.8, 136.2, 147.6, 159, 170.4, 181.8, 193.2, 204.6, 216, 227.4, 238.8, 250.2, 261.6, 273, 284.4, 295.8],
						Daze = [71.6, 74.9, 78.2, 81.5, 84.8, 88.1, 91.4, 94.7, 98, 101.3, 104.6, 107.9, 111.2, 114.5, 117.8, 121.1]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [186.3, 203.3, 220.3, 237.3, 254.3, 271.3, 288.3, 305.3, 322.3, 339.3, 356.3, 373.3, 390.3, 407.3, 424.3, 441.3],
						Daze = [107.2, 112.1, 117, 121.9, 126.8, 131.7, 136.6, 141.5, 146.4, 151.3, 156.2, 161.1, 166, 170.9, 175.8, 180.7]
					},
					new()// Moving Shot DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [40.3, 44, 47.7, 51.40, 55.1, 58.8, 62.5, 66.2, 69.9, 73.6, 77.3, 81, 84.7, 88.4, 92.1, 95.8],
						Daze = [40.3, 42.2, 44.1, 46, 47.9, 49.8, 51.7, 53.6, 55.5, 57.4, 59.3, 61.2, 63.1, 65, 66.9, 68.8]
					}
				]
			},
			new()// Dash Attack: Quick Inspection
			{
				Id = "QuickInspection",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Electric,
						Dmg = [33.3, 36.4, 39.5, 42.6, 45.7, 48.8, 51.9, 55, 58.1, 61.2, 64.3, 67.4, 70.5, 73.6, 76.7, 79.8],
						Daze = [16.7, 17.5, 18.3, 19.1, 19.9, 20.7, 21.5, 22.3, 23.1, 23.9, 24.7, 25.5, 26.3, 27.1, 27.9, 28.7]
					}
				]
			},
			new()// Dodge Counter: Violation Penalty
			{
				Id = "ViolationPenalty",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Electric,
						Dmg = [164.2, 179.2, 194.2, 209.2, 224.2, 239.2, 254.2, 269.2, 284.2, 299.2, 314.2, 329.2, 344.2, 359.2, 374.2, 389.2],
						Daze = [150.5, 157.4, 164.3, 171.2, 178.1, 185, 191.9, 198.8, 205.7, 212.6, 219.5, 226.4, 233.3, 240.2, 247.1, 254.0]
					}
				]
			},
			new()// Quick Assist: Incident Management
			{
				Id = "IncidentManagement",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Electric,
						Dmg = [45.5, 49.7, 53.9, 58.1, 62.3, 66.5, 70.7, 74.9, 79.1, 83.3, 87.5, 91.7, 95.9, 100.1, 104.3, 108.5],
						Daze = [45.5, 47.6, 49.7, 51.8, 53.9, 56.0, 58.1, 60.2, 62.3, 64.4, 66.5, 68.6, 70.7, 72.8, 74.9, 77.0]
					}
				]
			},
			new()// Assist Follow-Up: Counter Volt Needle
			{
				Id = "CounterVoltNeedle",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Electric,
						Dmg = [359.3, 392, 424.7, 457.4, 490.1, 522.8, 555.5, 588.2, 620.9, 653.6, 686.3, 719, 751.7, 784.4, 817.1, 849.8],
						Daze = [312.8, 327.1, 341.4, 355.7, 370, 384.3, 398.6, 412.9, 427.2, 441.5, 455.8, 470.1, 484.4, 498.7, 513, 527.3]
					}
				]
			},
			new()// Special Attack: Obstruction Removal
			{
				Id = "ObstructionRemoval",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Electric,
						Dmg = [42.1, 46.0, 49.9, 53.8, 57.7, 61.6, 65.5, 69.4, 73.3, 77.2, 81.1, 85.0, 88.9, 92.8, 96.7, 100.6],
						Daze = [42.1, 44.1, 46.1, 48.1, 50.1, 52.1, 54.1, 56.1, 58.1, 60.1, 62.1, 64.1, 66.1, 68.1, 70.1, 72.1]
					}
				]
			},
			new()// EX Special Attack: Supercharged Obstruction Removal
			{
				Id = "SuperchargedObstructionRemoval",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%*2)
					{
						Type = Ex,
						DmgType = Electric,
						Dmg = [166.9, 182.1, 197.3, 212.5, 227.7, 242.9, 258.1, 273.3, 288.5, 303.7, 318.9, 334.1, 349.3, 364.5, 379.7, 394.9],
						Daze = [134.2, 140.3, 146.4, 152.5, 158.6, 164.7, 170.8, 176.9, 183, 189.1, 195.2, 201.3, 207.4, 213.5, 219.6, 225.7]
					}
				]
			},
			new()// Chain Attack: Collaborative Construction
			{
				Id = "CollaborativeConstruction",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Electric,
						Dmg = [571.3, 623.3, 675.3, 727.3, 779.3, 831.3, 883.3, 935.3, 987.3, 1039.3, 1091.3, 1143.3, 1195.3, 1247.3, 1299.3, 1351.3],
						Daze = [152.3, 159.3, 166.3, 173.3, 180.3, 187.3, 194.3, 201.3, 208.3, 215.3, 222.3, 229.3, 236.3, 243.3, 250.3, 257.3]
					}
				]
			},
			new()// Ultimate: Demolition Blast - Beware
			{
				Id = "DemolitionBlastBeware",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Electric,
						Dmg = [1478.8, 1613.3, 1747.8, 1882.3, 2016.8, 2151.3, 2285.8, 2420.3, 2554.8, 2689.3, 2823.8, 2958.3, 3092.8, 3227.3, 3361.8, 3496.3],
						Daze = [133.1, 139.2, 145.3, 151.4, 157.5, 163.6, 169.7, 175.8, 181.9, 188.0, 194.1, 200.2, 206.3, 212.4, 218.5, 224.6]
					}
				]
			},
		],
		Cinemas =
		{
			[2] = new BuffInfo
			{
				Modifiers = [
					new StatModifier { Stat = ElectricRes, Type = Combat, Value = 8.5, Enemy = true},
					new StatModifier { Stat = ShockBuildUpRes, Type = Combat, Value = 8.5, Enemy = true}
				]
			},
			[6] = new BuffInfo
			{
				AbilityCondition = skill=> skill.Category == Special,
				Modifiers = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 200 },
			}
		}
	};
}