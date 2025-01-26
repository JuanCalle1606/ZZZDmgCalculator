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

[InfoData<Agents>(Nicole)]
public class NicoleData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Nicole,
		Icon = "Nicole_Demara",
		Attribute = Ether,
		Faction = Hares,
		Specialty = Support,
		AttackType = Strike,
		DodgeType = Parry,
		Rank = AgentRank.A,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = EnergyRegen, Value = 0.12
			},
			new()
			{
				Stat = Atk, Value = 25
			}
		],
		BaseStats =
		[
			Templates["Nicole.Atk"],
			Templates["Nicole.Hp"],
			Templates["Nicole.Def"],
		],
		FinalStats = [0, 88, 93, 90, 1.2],
		CoreBuff = new BuffInfo
		{
			Scales = [[-20, -25, -30, -34, -36, -38, -40]],
			Modifiers = new StatModifier
			{
				Stat = Def, Type = CombatPercent, Enemy = true
			}
		},
		AdditionalBuff = new StatModifier
		{
			Stat = EtherDmg, Type = Combat, Shared = true, Value = 25
		},
		Abilities =
		[
			new()// Basic Attack: Cunning Combo
			{
				Id = "CunningCombo",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (% +&nbsp;%*2)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 4,
						Scales = [65.9, 71.9, 77.9, 83.9, 89.9, 95.9, 101.9, 107.9, 113.9, 119.9, 125.9, 131.9, 137.9, 143.9, 149.9, 155.9]
					},
					new()// 2nd-Hit DMG Multiplier (% +&nbsp;%*4)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 5,
						Scales = [71.3, 77.8, 84.3, 90.8, 97.3, 103.8, 110.3, 116.8, 123.3, 129.8, 136.3, 142.8, 149.3, 155.8, 162.3, 168.8]
					},
					new()// 3rd-Hit DMG Multiplier (% +&nbsp;%*20)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 21,
						Scales = [304.3, 331.6, 358.9, 386.2, 413.5, 440.8, 468.1, 495.4, 522.7, 550.0, 577.3, 604.6, 631.9, 659.2, 686.5, 713.8]
					}
				]
			},
			new()// Basic Attack: Do As I Please
			{
				Id = "DoAsIPlease",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (% +&nbsp;%*2)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 4,
						Scales = [88.1, 96.2, 104.3, 112.4, 120.5, 128.6, 136.7, 144.8, 152.9, 161.0, 169.1, 177.2, 185.3, 193.4, 201.5, 209.6]
					},
					new()// 2nd-Hit DMG Multiplier (% +&nbsp;%*4)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 5,
						Scales = [100.9, 110.2, 119.5, 128.8, 138.1, 147.4, 156.7, 166.0, 175.3, 184.6, 193.9, 203.2, 212.5, 221.8, 231.1, 240.4]
					},
					new()// 3rd-Hit DMG Multiplier (% +&nbsp;%*20)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 21,
						Scales = [452.3, 493.6, 534.9, 576.2, 617.5, 658.8, 700.1, 741.4, 782.7, 824.0, 865.3, 906.6, 947.9, 989.2, 1030.5, 1071.8]
					}
				]
			},
			new()// Dash Attack: Jack in the Box
			{
				Id = "JackintheBox",
				Category = Dodge,
				Skills =
				[
					new()// Forward Dash DMG Multiplier (% +&nbsp;%*13)
					{
						Type = Dash,
						DmgType = Physical,
						Ticks = 14,
						Scales = [158.2, 172.4, 186.6, 200.8, 215.0, 229.2, 243.4, 257.6, 271.8, 286.0, 300.2, 314.4, 328.6, 342.8, 357.0, 371.2]
					},
					new()// Backward Vault DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Scales = [60, 65.5, 71, 76.5, 82, 87.5, 93, 98.5, 104, 109.5, 115, 120.5, 126, 131.5, 137, 142.5]
					}
				]
			},
			new()// Dash Attack: Do As I Please
			{
				Id = "DoAsIPlease",
				Category = Dodge,
				Skills =
				[
					new()// Forward Dash DMG Multiplier (% +&nbsp;%*13)
					{
						Type = Dash,
						DmgType = Physical,
						Ticks = 14,
						Scales = [158.2, 172.4, 186.6, 200.8, 215.0, 229.2, 243.4, 257.6, 271.8, 286.0, 300.2, 314.4, 328.6, 342.8, 357.0, 371.2]
					}
				]
			},
			new()// Dodge Counter: Diverted Bombard
			{
				Id = "DivertedBombard",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Ether,
						Scales = [182.4, 199, 215.6, 232.2, 248.8, 265.4, 282, 298.6, 315.2, 331.8, 348.4, 365, 381.6, 398.2, 414.8, 431.4]
					}
				]
			},
			new()// Quick Assist: Emergency Bombard
			{
				Id = "EmergencyBombard",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Ether,
						Scales = [63.4, 69.2, 75.0, 80.8, 86.6, 92.4, 98.2, 104.0, 109.8, 115.6, 121.4, 127.2, 133.0, 138.8, 144.6, 150.4]
					}
				]
			},
			new()// Assist Follow-Up: Window of Opportunity
			{
				Id = "WindowofOpportunity",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Ether,
						Scales = [377.1, 411.4, 445.7, 480, 514.3, 548.6, 582.9, 617.2, 651.5, 685.8, 720.1, 754.4, 788.7, 823, 857.3, 891.6]
					}
				]
			},
			new()// Special Attack: Sugarcoated Bullet
			{
				Id = "SugarcoatedBullet",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ether,
						Scales = [50, 52.4, 54.8, 57.2, 59.6, 62.0, 64.4, 66.8, 69.2, 71.6, 74.0, 76.4, 78.8, 81.2, 83.6, 86.0]
					}
				]
			},
			new()// EX Special Attack: Stuffed Sugarcoated Bullet
			{
				Id = "StuffedSugarcoatedBullet",
				Category = Special,
				Skills =
				[
					new()// Charged Attack DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ether,
						Scales = [215, 234.6, 254.2, 273.8, 293.4, 313, 332.6, 352.2, 371.8, 391.4, 411, 430.6, 450.2, 469.8, 489.4, 509]
					},
					new()// Bombard DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ether,
						Scales = [215, 234.6, 254.2, 273.8, 293.4, 313, 332.6, 352.2, 371.8, 391.4, 411, 430.6, 450.2, 469.8, 489.4, 509]
					},
					new()// Energy Field DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ether,
						Scales = [387, 422.2, 457.4, 492.6, 527.8, 563.0, 598.2, 633.4, 668.6, 703.8, 739.0, 774.2, 809.4, 844.6, 879.8, 915.0]
					}
				]
			},
			new()// Chain Attack: Ether Shellacking
			{
				Id = "EtherShellacking",
				Category = Chain,
				Skills =
				[
					new()// Bombard DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ether,
						Scales = [209.6, 228.8, 248, 267.2, 286.4, 305.6, 324.8, 344, 363.2, 382.4, 401.6, 420.8, 440, 459.2, 478.4, 497.6]
					},
					new()// Energy Field DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ether,
						Scales = [283, 308.8, 334.6, 360.4, 386.2, 412, 437.8, 463.6, 489.4, 515.2, 541, 566.8, 592.6, 618.4, 644.2, 670]
					}
				]
			},
			new()// Ultimate: Ether Grenade
			{
				Id = "EtherGrenade",
				Category = Chain,
				Skills =
				[
					new()// Bombard DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ether,
						Scales = [646.8, 705.6, 764.4, 823.2, 882, 940.8, 999.6, 1058.4, 1117.2, 1176, 1234.8, 1293.6, 1352.4, 1411.2, 1470, 1528.8]
					},
					new()// Energy Field DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ether,
						Scales = [873.2, 952.6, 1032, 1111.4, 1190.8, 1270.2, 1349.6, 1429, 1508.4, 1587.8, 1667.2, 1746.6, 1826, 1905.4, 1984.8, 2064.2]
					}
				]
			}
		],
		Cinema =
		{
			[1] = new BuffInfo
			{
				Type = BuffTrigger.Permanent,
				SkillCondition = skill => skill.Type == Ex, // only applies to ex skills
				Modifiers =
				[
					new() { Stat = BonusDmg, Type = Combat, Value = 16 }, // we dont use ExDmg here because BuildUp need to be conditioned
					new() { Stat = BuildUp, Type = Combat, Value = 16 }
				]
			},
			[6] = new BuffInfo
			{
				Type = BuffTrigger.Stack,
				Stacks = 10,
				Modifiers = new StatModifier { Stat = CritRate, Value = 1.5, Type = Combat, Shared = true }
			}
		}
	};
}