namespace ZZZDmgCalculator.Data.AgentsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static AgentScales;
using static ZZZ.ApiModels.Agents;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.Factions;
using static ZZZ.ApiModels.Skills;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static Models.Info.DodgeTypes;

[InfoData<Agents>(Rina)]
public class RinaData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Rina,
		Icon = "Alexandrina_Sebastiane",
		Attribute = Electric,
		Faction = Victoria,
		Specialty = Support,
		AttackType = Strike,
		DodgeType = Evasion,
		Rank = AgentRank.S,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = PenRatio,
				Value = 4.8
			},
			new()
			{
				Stat = Atk,
				Value = 25
			}
		],
		BaseStats =
		[
			Templates["Rina.Atk"],
			Templates["Rina.Hp"],
			Templates["Rina.Def"],
		],
		FinalStats = [0, 83, 92, 93, 1.2],
		CoreBuff = new BuffInfo
		{
			Scales = [[6, 7.5, 9, 10.2, 10.8, 11.4, 12]],
			Modifiers =
			[
				new() { Stat = PenRatio, Type = Combat, Shared = true },
				new() { Stat = PenRatio, Type = BasePercent, Shared = true, Agent = true, Value = 25 },
			],
			BuffLimit = 30
		},
		AdditionalBuff = new StatModifier
		{
			Stat = ElectricDmg, Type = Combat, Shared = true, Value = 10
		},
		Abilities =
		[
			new()// Basic Attack: Whack the Dimwit
			{
				Id = "WhacktheDimwit",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [44, 48, 52, 56, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [111.4, 121.6, 131.8, 142, 152.2, 162.4, 172.6, 182.8, 193, 203.2, 213.4, 223.6, 233.8, 244, 254.2, 264.4]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Scales = [117.1, 127.8, 138.5, 149.2, 159.9, 170.6, 181.3, 192.0, 202.7, 213.4, 224.1, 234.8, 245.5, 256.2, 266.9, 277.6]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Scales = [183.9, 200.7, 217.5, 234.3, 251.1, 267.9, 284.7, 301.5, 318.3, 335.1, 351.9, 368.7, 385.5, 402.3, 419.1, 435.9]
					}
				]
			},
			new()// Basic Attack: Shoo the Fool
			{
				Id = "ShootheFool",
				Category = Basic,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Scales = [315.1, 343.8, 372.5, 401.2, 429.9, 458.6, 487.3, 516.0, 544.7, 573.4, 602.1, 630.8, 659.5, 688.2, 716.9, 745.6]
					}
				]
			},
			new()// Dash Attack: Sudden Surprise
			{
				Id = "SuddenSurprise",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Scales = [105, 114.6, 124.2, 133.8, 143.4, 153.0, 162.6, 172.2, 181.8, 191.4, 201.0, 210.6, 220.2, 229.8, 239.4, 249.0]
					}
				]
			},
			new()// Dodge Counter: Bangboo Callback
			{
				Id = "BangbooCallback",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Electric,
						Scales = [227.6, 248.3, 269.0, 289.7, 310.4, 331.1, 351.8, 372.5, 393.2, 413.9, 434.6, 455.3, 476.0, 496.7, 517.4, 538.1]
					}
				]
			},
			new()// Quick Assist: Duple Meter Allemande
			{
				Id = "DupleMeterAllemande",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Electric,
						Scales = [122.6, 133.8, 145.0, 156.2, 167.4, 178.6, 189.8, 201.0, 212.2, 223.4, 234.6, 245.8, 257.0, 268.2, 279.4, 290.6]
					}
				]
			},
			new()// Assist Follow-Up: Quadruple Meter Gavotte
			{
				Id = "QuadrupleMeterGavotte",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Electric,
						Scales = [349.4, 381.2, 413.0, 444.8, 476.6, 508.4, 540.2, 572.0, 603.8, 635.6, 667.4, 699.2, 731.0, 762.8, 794.6, 826.4]
					}
				]
			},
			new()// Special Attack: Beat the Blockhead
			{
				Id = "BeattheBlockhead",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Electric,
						Scales = [61.3, 66.9, 72.5, 78.1, 83.7, 89.3, 94.9, 100.5, 106.1, 111.7, 117.3, 122.9, 128.5, 134.1, 139.7, 145.3]
					}
				]
			},
			new()// EX Special Attack: Dimwit Disappearing Trick
			{
				Id = "DimwitDisappearingTrick",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Electric,
						Scales = [546, 595.7, 645.4, 695.1, 744.8, 794.5, 844.2, 893.9, 943.6, 993.3, 1043.0, 1092.7, 1142.4, 1192.1, 1241.8, 1291.5]
					}
				]
			},
			new()// Chain Attack: Code of Conduct
			{
				Id = "CodeofConduct",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Electric,
						Scales = [1013, 1105.1, 1197.2, 1289.3, 1381.4, 1473.5, 1565.6, 1657.7, 1749.8, 1841.9, 1934.0, 2026.1, 2118.2, 2210.3, 2302.4, 2394.5]
					}
				]
			},
			new()// Ultimate: The Queen's Attendants
			{
				Id = "TheQueensAttendants",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Electric,
						Scales = [2116.7, 2309.2, 2501.7, 2694.2, 2886.7, 3079.2, 3271.7, 3464.2, 3656.7, 3849.2, 4041.7, 4234.2, 4426.7, 4619.2, 4811.7, 5004.2]
					}
				]
			}
		],
		Cinemas =
		{
			// TODO: increment core buff
			[2] = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 15 },
			[4] = new StatModifier { Stat = EnergyRegen, Value = 0.5, Type = CombatFlat },
			[6] = new StatModifier { Stat = ElectricDmg, Value = 15, Type = Combat, Shared = true }
		}
	};
}