namespace ZZZDmgCalculator.Data.AgentsData.Victoria;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static AgentScales;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.BuffTrigger;
using static Models.Enum.DodgeTypes;
using static Models.Enum.Factions;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Agents;
using static ZZZ.ApiModels.Skills;

[InfoData<Agents>(Corin)]
public class CorinData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Corin,
		Icon = "Corin_Wickes",
		Attribute = Physical,
		Faction = Victoria,
		Specialty = Attack,
		AttackType = Slash,
		DodgeType = Parry,
		Rank = AgentRank.A,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = CritDmg,
				Value = 9.6
			},
			new()
			{
				Stat = Atk,
				Value = 25
			}
		],
		BaseStats =
		[
			Templates["Corin.Atk"],
			Templates["Corin.Hp"],
			Templates["Corin.Def"],
		],
		FinalStats = [0, 93, 96, 93, 1.2],
		CoreBuff = new BuffInfo
		{
			// TODO
		},
		AdditionalBuff = new BuffInfo
		{
			// TODO: add stunned enemy condition or stat
		},
		Abilities =
		[
			new()// Basic Attack: Wipeout
			{
				Id = "Wipeout",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [82, 89.5, 97, 104.5, 112, 119.5, 127, 134.5, 142, 149.5, 157, 164.5, 172, 179.5, 187, 194.5],
						Daze = [41, 42.9, 44.8, 46.7, 48.6, 50.5, 52.4, 54.3, 56.2, 58.1, 60.0, 61.9, 63.8, 65.7, 67.6, 69.5]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [76.6, 83.6, 90.6, 97.6, 104.6, 111.6, 118.6, 125.6, 132.6, 139.6, 146.6, 153.6, 160.6, 167.6, 174.6, 181.6],
						Daze = [70.2, 73.4, 76.6, 79.8, 83.0, 86.2, 89.4, 92.6, 95.8, 99.0, 102.2, 105.4, 108.6, 111.8, 115.0, 118.2]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [179.2, 195.5, 211.8, 228.1, 244.4, 260.7, 277.0, 293.3, 309.6, 325.9, 342.2, 358.5, 374.8, 391.1, 407.4, 423.7],
						Daze = [123.8, 129.5, 135.2, 140.9, 146.6, 152.3, 158.0, 163.7, 169.4, 175.1, 180.8, 186.5, 192.2, 197.9, 203.6, 209.3]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [233.4, 254.7, 276, 297.3, 318.6, 339.9, 361.2, 382.5, 403.8, 425.1, 446.4, 467.7, 489.0, 510.3, 531.6, 552.9],
						Daze = [186.4, 194.9, 203.4, 211.9, 220.4, 228.9, 237.4, 245.9, 254.4, 262.9, 271.4, 279.9, 288.4, 296.9, 305.4, 313.9]
					},
					new()// 5th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [421.2, 459.5, 497.8, 536.1, 574.4, 612.7, 651.0, 689.3, 727.6, 765.9, 804.2, 842.5, 880.8, 919.1, 957.4, 995.7],
						Daze = [342, 357.6, 373.2, 388.8, 404.4, 420.0, 435.6, 451.2, 466.8, 482.4, 498.0, 513.6, 529.2, 544.8, 560.4, 576.0]
					}
				]
			},
			new()// Dash Attack: Oopsy-Daisy!
			{
				Id = "OopsyDaisy",
				Category = Dodge,
				Skills =
				[
					new()// Maximum DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [96.7, 105.5, 114.3, 123.1, 131.9, 140.7, 149.5, 158.3, 167.1, 175.9, 184.7, 193.5, 202.3, 211.1, 219.9, 228.7],
						Daze = [48.4, 50.6, 52.8, 55.0, 57.2, 59.4, 61.6, 63.8, 66.0, 68.2, 70.4, 72.6, 74.8, 77.0, 79.2, 81.4]
					}
				]
			},
			new()// Dodge Counter: Nope!
			{
				Id = "Nope",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Physical,
						Dmg = [271.2, 296, 320.8, 345.6, 370.4, 395.2, 420.0, 444.8, 469.6, 494.4, 519.2, 544, 568.8, 593.6, 618.4, 643.2],
						Daze = [131.8, 137.8, 143.8, 149.8, 155.8, 161.8, 167.8, 173.8, 179.8, 185.8, 191.8, 197.8, 203.8, 209.8, 215.8, 221.8]
					}
				]
			},
			new()// Quick Assist: Emergency Measures
			{
				Id = "EmergencyMeasures",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Physical,
						Dmg = [215, 234.6, 254.2, 273.8, 293.4, 313.0, 332.6, 352.2, 371.8, 391.4, 411.0, 430.6, 450.2, 469.8, 489.4, 509.0],
						Daze = [215, 224.8, 234.6, 244.4, 254.2, 264.0, 273.8, 283.6, 293.4, 303.2, 313.0, 322.8, 332.6, 342.4, 352.2, 362.0]
					}
				]
			},
			new()// Defensive Assist: P—Please Allow Me!
			{
				Id = "PPleaseAllowMe",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [246.7, 258, 269.3, 280.6, 291.9, 303.2, 314.5, 325.8, 337.1, 348.4, 359.7, 371.0, 382.3, 393.6, 404.9, 416.2]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [311.7, 325.9, 340.1, 354.3, 368.5, 382.7, 396.9, 411.1, 425.3, 439.5, 453.7, 467.9, 482.1, 496.3, 510.5, 524.7]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [151.7, 158.6, 165.5, 172.4, 179.3, 186.2, 193.1, 200.0, 206.9, 213.8, 220.7, 227.6, 234.5, 241.4, 248.3, 255.2]
					}
				]
			},
			new()// Assist Follow-Up: Quick Sweep
			{
				Id = "QuickSweep",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Physical,
						Dmg = [547.5, 597.3, 647.1, 696.9, 746.7, 796.5, 846.3, 896.1, 945.9, 995.7, 1045.5, 1095.3, 1145.1, 1194.9, 1244.7, 1294.5],
						Daze = [488.6, 510.9, 533.2, 555.5, 577.8, 600.1, 622.4, 644.7, 667.0, 689.3, 711.6, 733.9, 756.2, 778.5, 800.8, 823.1]
					}
				]
			},
			new()// Special Attack: Clean Sweep
			{
				Id = "CleanSweep",
				Category = Special,
				Skills =
				[
					new()// Spinning Slash DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Physical,
						Dmg = [66.7, 72.8, 78.9, 85.0, 91.1, 97.2, 103.3, 109.4, 115.5, 121.6, 127.7, 133.8, 139.9, 146.0, 152.1, 158.2],
						Daze = [66.7, 69.8, 72.9, 76.0, 79.1, 82.2, 85.3, 88.4, 91.5, 94.6, 97.7, 100.8, 103.9, 107.0, 110.1, 113.2]
					},
					new()// Extended Slash Maximum DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Physical,
						Dmg = [37.5, 41, 44.5, 48, 51.5, 55, 58.5, 62, 65.5, 69, 72.5, 76, 79.5, 83, 86.5, 90],
						Daze = [37.5, 39.3, 41.1, 42.9, 44.7, 46.5, 48.3, 50.1, 51.9, 53.7, 55.5, 57.3, 59.1, 60.9, 62.7, 64.5]
					},
					new()// Explosion DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Physical,
						Dmg = [25, 27.3, 29.6, 31.9, 34.2, 36.5, 38.8, 41.1, 43.4, 45.7, 48.0, 50.3, 52.6, 54.9, 57.2, 59.5],
						Daze = [25, 26.2, 27.4, 28.6, 29.8, 31.0, 32.2, 33.4, 34.6, 35.8, 37.0, 38.2, 39.4, 40.6, 41.8, 43.0]
					}
				]
			},
			new()// EX Special Attack: Skirt Alert
			{
				Id = "SkirtAlert",
				Category = Special,
				Skills =
				[
					new()// Spinning Slash DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [345.1, 376.5, 407.9, 439.3, 470.7, 502.1, 533.5, 564.9, 596.3, 627.7, 659.1, 690.5, 721.9, 753.3, 784.7, 816.1],
						Daze = [206.4, 215.8, 225.2, 234.6, 244.0, 253.4, 262.8, 272.2, 281.6, 291.0, 300.4, 309.8, 319.2, 328.6, 338.0, 347.4]
					},
					new()// Extended Slash Maximum DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [1035.2, 1129.4, 1223.6, 1317.8, 1412.0, 1506.2, 1600.4, 1694.6, 1788.8, 1883.0, 1977.2, 2071.4, 2165.6, 2259.8, 2354, 2448.2],
						Daze = [619, 647.2, 675.4, 703.6, 731.8, 760.0, 788.2, 816.4, 844.6, 872.8, 901.0, 929.2, 957.4, 985.6, 1013.8, 1042.0]
					},
					new()// Explosion DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [345.1, 376.5, 407.9, 439.3, 470.7, 502.1, 533.5, 564.9, 596.3, 627.7, 659.1, 690.5, 721.9, 753.3, 784.7, 816.1],
						Daze = [206.4, 215.8, 225.2, 234.6, 244.0, 253.4, 262.8, 272.2, 281.6, 291.0, 300.4, 309.8, 319.2, 328.6, 338.0, 347.4]
					}
				]
			},
			new()// Chain Attack: Sorry...
			{
				Id = "Sorry",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Physical,
						Dmg = [687.3, 749.8, 812.3, 874.8, 937.3, 999.8, 1062.3, 1124.8, 1187.3, 1249.8, 1312.3, 1374.8, 1437.3, 1499.8, 1562.3, 1624.8],
						Daze = [288.3, 301.5, 314.7, 327.9, 341.1, 354.3, 367.5, 380.7, 393.9, 407.1, 420.3, 433.5, 446.7, 459.9, 473.1, 486.3]
					}
				]
			},
			new()// Ultimate: Very, Very Sorry!
			{
				Id = "VeryVerySorry",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Physical,
						Dmg = [2028.8, 2213.3, 2397.8, 2582.3, 2766.8, 2951.3, 3135.8, 3320.3, 3504.8, 3689.3, 3873.8, 4058.3, 4242.8, 4427.3, 4611.8, 4796.3],
						Daze = [406.7, 425.2, 443.8, 462.3, 480.8, 499.3, 517.9, 536.4, 554.9, 573.5, 592.0, 610.5, 629.1, 647.6, 666.1, 684.6]
					}
				]
			},
		],
		Cinemas =
		{
			[1] = new BuffInfo
			{
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat, Value = 12
				}
			},
			[2] = new BuffInfo
			{
				Type = Stack,
				Stacks = 20,
				Modifiers = new StatModifier
				{
					Stat = PhysicalRes, Type = Combat, Value = 0.5, Enemy = true
				}
			},
			// Add m6 skill
		}
	};
}