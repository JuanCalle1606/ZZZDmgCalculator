namespace ZZZDmgCalculator.Data.AgentsData.Hares;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static AgentScales;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.DodgeTypes;
using static Models.Enum.Factions;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Agents;
using static ZZZ.ApiModels.Skills;

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
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (% +&nbsp;%*2)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 4,
						Dmg = [65.9, 71.9, 77.9, 83.9, 89.9, 95.9, 101.9, 107.9, 113.9, 119.9, 125.9, 131.9, 137.9, 143.9, 149.9, 155.9],
						Daze = [40.2, 42.3, 44.4, 46.5, 48.6, 50.7, 52.8, 54.9, 57, 59.1, 61.2, 63.3, 65.4, 67.5, 69.6, 71.7]
					},
					new()// 2nd-Hit DMG Multiplier (% +&nbsp;%*4)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 5,
						Dmg = [71.3, 77.8, 84.3, 90.8, 97.3, 103.8, 110.3, 116.8, 123.3, 129.8, 136.3, 142.8, 149.3, 155.8, 162.3, 168.8],
						Daze = [56.6, 59.2, 61.8, 64.4, 67, 69.6, 72.2, 74.8, 77.4, 80, 82.6, 85.2, 87.8, 90.4, 93, 95.6]
					},
					new()// 3rd-Hit DMG Multiplier (% +&nbsp;%*20)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 21,
						Dmg = [304.3, 331.6, 358.9, 386.2, 413.5, 440.8, 468.1, 495.4, 522.7, 550.0, 577.3, 604.6, 631.9, 659.2, 686.5, 713.8],
						Daze = [243.3, 253.1, 263.9, 274.7, 285.5, 296.3, 307.1, 317.9, 328.7, 339.5, 350.3, 361.1, 371.9, 382.7, 393.5, 404.3]
					}
				]
			},
			new()// Basic Attack: Do As I Please
			{
				Id = "DoAsIPlease",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (% +&nbsp;%*2)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 4,
						Dmg = [88.1, 96.2, 104.3, 112.4, 120.5, 128.6, 136.7, 144.8, 152.9, 161.0, 169.1, 177.2, 185.3, 193.4, 201.5, 209.6],
						Daze = [40.2, 42.3, 44.4, 46.5, 48.6, 50.7, 52.8, 54.9, 57, 59.1, 61.2, 63.3, 65.4, 67.5, 69.6, 71.7]
					},
					new()// 2nd-Hit DMG Multiplier (% +&nbsp;%*4)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 5,
						Dmg = [100.9, 110.2, 119.5, 128.8, 138.1, 147.4, 156.7, 166.0, 175.3, 184.6, 193.9, 203.2, 212.5, 221.8, 231.1, 240.4],
						Daze = [56.6, 59.2, 61.8, 64.4, 67, 69.6, 72.2, 74.8, 77.4, 80, 82.6, 85.2, 87.8, 90.4, 93, 95.6]
					},
					new()// 3rd-Hit DMG Multiplier (% +&nbsp;%*20)
					{
						Type = Basic,
						DmgType = Physical,
						Ticks = 21,
						Dmg = [452.3, 493.6, 534.9, 576.2, 617.5, 658.8, 700.1, 741.4, 782.7, 824.0, 865.3, 906.6, 947.9, 989.2, 1030.5, 1071.8],
						Daze = [243.3, 253.1, 263.9, 274.7, 285.5, 296.3, 307.1, 317.9, 328.7, 339.5, 350.3, 361.1, 371.9, 382.7, 393.5, 404.3]
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
						Dmg = [158.2, 172.4, 186.6, 200.8, 215.0, 229.2, 243.4, 257.6, 271.8, 286.0, 300.2, 314.4, 328.6, 342.8, 357.0, 371.2],
						Daze = [73.4, 77.2, 81.2, 85.2, 89.2, 93.2, 97.2, 101.2, 105.2, 109.2, 113.2, 117.2, 121.2, 125.2, 129.2, 133.2]
					},
					new()// Backward Vault DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [60, 65.5, 71, 76.5, 82, 87.5, 93, 98.5, 104, 109.5, 115, 120.5, 126, 131.5, 137, 142.5],
						Daze = [60, 62.8, 65.6, 68.4, 71.2, 74, 76.8, 79.6, 82.4, 85.2, 88, 90.8, 93.6, 96.4, 99.2, 102]
					}
				]
			},
			new()// Dash Attack: Do As I Please
			{
				Id = "DashDoAsIPlease",
				Category = Dodge,
				Skills =
				[
					new()// Forward Dash DMG Multiplier (% +&nbsp;%*13)
					{
						Type = Dash,
						DmgType = Physical,
						Ticks = 14,
						Dmg = [158.2, 172.4, 186.6, 200.8, 215.0, 229.2, 243.4, 257.6, 271.8, 286.0, 300.2, 314.4, 328.6, 342.8, 357.0, 371.2],
						Daze = [73.4, 77.2, 81.2, 85.2, 89.2, 93.2, 97.2, 101.2, 105.2, 109.2, 113.2, 117.2, 121.2, 125.2, 129.2, 133.2]
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
						Dmg = [182.4, 199, 215.6, 232.2, 248.8, 265.4, 282, 298.6, 315.2, 331.8, 348.4, 365, 381.6, 398.2, 414.8, 431.4],
						Daze = [163.4, 171, 178.6, 186.2, 193.8, 201.4, 209, 216.6, 224.2, 231.8, 239.4, 247, 254.6, 262.2, 269.8, 277.4]
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
						Dmg = [63.4, 69.2, 75.0, 80.8, 86.6, 92.4, 98.2, 104.0, 109.8, 115.6, 121.4, 127.2, 133.0, 138.8, 144.6, 150.4],
						Daze = [63.4, 66.4, 69.4, 72.4, 75.4, 78.4, 81.4, 84.4, 87.4, 90.4, 93.4, 96.4, 99.4, 102.4, 105.4, 108.4]
					}
				]
			},
			new()// Defensive Assist: The Hare Strikes Back!
			{
				Id = "TheHareStrikesBack",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [246.7, 258, 269.3, 280.6, 291.9, 303.2, 314.5, 325.8, 337.1, 348.4, 359.7, 371, 382.3, 393.6, 404.9, 416.2]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [311.7, 325.9, 340.1, 354.3, 368.5, 382.7, 396.9, 411.1, 425.3, 439.5, 453.7, 467.9, 482.1, 496.3, 510.5, 524.7]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [151.7, 158.6, 165.5, 172.4, 179.3, 186.2, 193.1, 200, 206.9, 213.8, 220.7, 227.6, 234.5, 241.4, 248.3, 255.2]
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
						Dmg = [377.1, 411.4, 445.7, 480, 514.3, 548.6, 582.9, 617.2, 651.5, 685.8, 720.1, 754.4, 788.7, 823, 857.3, 891.6],
						Daze = [330.3, 345.4, 360.5, 375.6, 390.7, 405.8, 420.9, 436, 451.1, 466.2, 481.3, 496.4, 511.5, 526.6, 541.7, 556.8]
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
						Dmg = [50, 52.4, 54.8, 57.2, 59.6, 62.0, 64.4, 66.8, 69.2, 71.6, 74.0, 76.4, 78.8, 81.2, 83.6, 86.0],
						Daze = [52.6, 57.4, 62.2, 67.0, 71.8, 76.6, 81.4, 86.2, 91.0, 95.8, 100.6, 105.4, 110.2, 115.0, 119.8, 124.6]
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
						Dmg = [215, 234.6, 254.2, 273.8, 293.4, 313, 332.6, 352.2, 371.8, 391.4, 411, 430.6, 450.2, 469.8, 489.4, 509],
						Daze = [179.8, 188, 196.2, 204.4, 212.6, 220.8, 229, 237.2, 245.4, 253.6, 261.8, 270, 278.2, 286.4, 294.6, 302.8]
					},
					new()// Bombard DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ether,
						Dmg = [215, 234.6, 254.2, 273.8, 293.4, 313, 332.6, 352.2, 371.8, 391.4, 411, 430.6, 450.2, 469.8, 489.4, 509],
						Daze = [179.8, 188, 196.2, 204.4, 212.6, 220.8, 229, 237.2, 245.4, 253.6, 261.8, 270, 278.2, 286.4, 294.6, 302.8]
					},
					new()// Energy Field DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ether,
						Dmg = [387, 422.2, 457.4, 492.6, 527.8, 563.0, 598.2, 633.4, 668.6, 703.8, 739.0, 774.2, 809.4, 844.6, 879.8, 915.0],
						Daze = [323.6, 338.4, 353.2, 368.0, 382.8, 397.6, 412.4, 427.2, 442.0, 456.8, 471.6, 486.4, 501.2, 516.0, 530.8, 545.6]
					}
				]
			},
			new()// Chain Attack: Ether Shellacking
			{
				Id = "EtherShellacking",
				Category = Ultimate,
				Skills =
				[
					new()// Bombard DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ether,
						Dmg = [209.6, 228.8, 248, 267.2, 286.4, 305.6, 324.8, 344, 363.2, 382.4, 401.6, 420.8, 440, 459.2, 478.4, 497.6],
						Daze = [50, 52.4, 54.8, 57.2, 59.6, 62, 64.4, 66.8, 69.2, 71.6, 74, 76.4, 78.8, 81.2, 83.6, 86]
					},
					new()// Energy Field DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ether,
						Dmg = [283, 308.8, 334.6, 360.4, 386.2, 412, 437.8, 463.6, 489.4, 515.2, 541, 566.8, 592.6, 618.4, 644.2, 670],
						Daze = [67.5, 70.6, 73.7, 76.8, 79.9, 83, 86.1, 89.2, 92.3, 95.4, 98.5, 101.6, 104.7, 107.8, 110.9, 114]
					}
				]
			},
			new()// Ultimate: Ether Grenade
			{
				Id = "EtherGrenade",
				Category = Ultimate,
				Skills =
				[
					new()// Bombard DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ether,
						Dmg = [646.8, 705.6, 764.4, 823.2, 882, 940.8, 999.6, 1058.4, 1117.2, 1176, 1234.8, 1293.6, 1352.4, 1411.2, 1470, 1528.8],
						Daze = [36, 37.7, 39.4, 41.1, 42.8, 44.5, 46.2, 47.9, 49.6, 51.3, 53, 54.7, 56.4, 58.1, 59.8, 61.5]
					},
					new()// Energy Field DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ether,
						Dmg = [873.2, 952.6, 1032, 1111.4, 1190.8, 1270.2, 1349.6, 1429, 1508.4, 1587.8, 1667.2, 1746.6, 1826, 1905.4, 1984.8, 2064.2],
						Daze = [48.6, 50.9, 53.2, 55.5, 57.8, 60.1, 62.4, 64.7, 67, 69.3, 71.6, 73.9, 76.2, 78.5, 80.8, 83.1]
					}
				]
			},
		],
		Cinemas =
		{
			[1] = new BuffInfo
			{
				Type = BuffTrigger.Permanent,
				SkillCondition = skill => skill.Type == Ex,// only applies to ex skills
				Modifiers =
				[
					new() { Stat = BonusDmg, Type = Combat, Value = 16 },// we dont use ExDmg here because BuildUp need to be conditioned
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