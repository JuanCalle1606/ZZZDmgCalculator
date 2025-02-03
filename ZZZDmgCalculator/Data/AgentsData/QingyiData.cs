namespace ZZZDmgCalculator.Data.AgentsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static AgentScales;
using static ZZZ.ApiModels.Agents;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Factions;
using static ZZZ.ApiModels.Skills;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static Models.Info.DodgeTypes;

[InfoData<Agents>(Qingyi)]
public class QingyiData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Qingyi,
		Icon = "Qingyi",
		Attribute = Electric,
		Faction = Neps,
		Specialty = Stun,
		AttackType = Strike,
		DodgeType = Parry,
		Rank = AgentRank.S,
		AdditionalCondition = SpecialyAdditionalCondition(Attack),
		CoreStats =
		[
			new()
			{
				Stat = Impact, Value = 6
			},
			new()
			{
				Stat = Atk, Value = 25
			}
		],
		BaseStats =
		[
			Templates["Qingyi.Atk"],
			Templates["Qingyi.Hp"],
			Templates["Lucy.Def"],
		],
		FinalStats = [0, 118, 93, 94, 1.2],
		CoreBuff = new BuffInfo
		{
			Type = Stack,
			Stacks = 20,
			Scales = [[2, 2.4, 2.7, 3, 3.4, 3.7, 4]],
			Modifiers = new StatModifier
			{
				Stat = StunDmg, Type = Combat, Enemy = true
			}
		},
		// TODO: Add qingyi additional buff
		Abilities =
		[
			new()// Basic Attack: Penultimate
			{
				Id = "Penultimate",
				Category = Basic,
				UseCommonNames = true,
				MaxCommonName = 4,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [47.2, 51.5, 55.8, 60.1, 64.4, 68.7, 73.0, 77.3, 81.6, 85.9, 90.2, 94.5, 98.8, 103.1, 107.4, 111.7],
						Daze = [23.6, 24.7, 25.8, 26.9, 28.0, 29.1, 30.2, 31.3, 32.4, 33.5, 34.6, 35.7, 36.8, 37.9, 39.0, 40.1]
					},
					new()// 2nd-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [122.1, 133.2, 144.3, 155.4, 166.5, 177.6, 188.7, 199.8, 210.9, 222.0, 233.1, 244.2, 255.3, 266.4, 277.5, 288.6],
						Daze = [82.2, 86, 89.8, 93.6, 97.4, 101.2, 105.0, 108.8, 112.6, 116.4, 120.2, 124.0, 127.8, 131.6, 135.4, 139.2]
					},
					new()// 3rd-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [17.6, 19.2, 20.8, 22.4, 24.0, 25.6, 27.2, 28.8, 30.4, 32.0, 33.6, 35.2, 36.8, 38.4, 40.0, 41.6],
						Daze = [19.1, 20, 20.9, 21.8, 22.7, 23.6, 24.5, 25.4, 26.3, 27.2, 28.1, 29.0, 29.9, 30.8, 31.7, 32.6]
					},
					new()// 4th-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [106.4, 116.1, 125.8, 135.5, 145.2, 154.9, 164.6, 174.3, 184.0, 193.7, 203.4, 213.1, 222.8, 232.5, 242.2, 251.9],
						Daze = [106.3, 111.2, 116.1, 121.0, 125.9, 130.8, 135.7, 140.6, 145.5, 150.4, 155.3, 160.2, 165.1, 170.0, 174.9, 179.8]
					},
					new()// 1st-Hit DMG Multiplier (ALT)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [110.3, 120.4, 130.5, 140.6, 150.7, 160.8, 170.9, 181.0, 191.1, 201.2, 211.3, 221.4, 231.5, 241.6, 251.7, 261.8],
						Daze = [55.2, 57.8, 60.4, 63.0, 65.6, 68.2, 70.8, 73.4, 76.0, 78.6, 81.2, 83.8, 86.4, 89.0, 91.6, 94.2]
					},
					new()// 4th-Hit DMG Multiplier (Enhanced)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [234.4, 255.8, 277.2, 298.6, 320.0, 341.4, 362.8, 384.2, 405.6, 427.0, 448.4, 469.8, 491.2, 512.6, 534.0, 555.4],
						Daze = [204.7, 214.1, 223.5, 232.9, 242.3, 251.7, 261.1, 270.5, 279.9, 289.3, 298.7, 308.1, 317.5, 326.9, 336.3, 345.7]
					}
				]
			},
			new()// Basic Attack: Enchanted Blossoms
			{
				Id = "EnchantedBlossoms",
				Category = Basic,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [85.6, 93.4, 101.2, 109.0, 116.8, 124.6, 132.4, 140.2, 148, 155.8, 163.6, 171.4, 179.2, 187.0, 194.8, 202.6],
						Daze = [85.6, 89.5, 93.4, 97.3, 101.2, 105.1, 109.0, 112.9, 116.8, 120.7, 124.6, 128.5, 132.4, 136.3, 140.2, 144.1]
					}
				]
			},
			new()// Flash Connet
			{
				Id = "FlashConnet",
				Category = Basic,
				Buffs = new BuffInfo
				{
					Type = Stack,
					Stacks = 25,
					AbilityCondition = skill => skill.Id == "Basic.EnchantedMoonlitBlossoms",
					Modifiers = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 1 }
				}
			},
			new()// Basic Attack: Enchanted Moonlit Blossoms
			{
				Id = "EnchantedMoonlitBlossoms",
				Category = Basic,
				Skills =
				[
					new()// Rush Attack DMG Multiplier
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [448.7, 489.5, 530.3, 571.1, 611.9, 652.7, 693.5, 734.3, 775.1, 815.9, 856.7, 897.5, 938.3, 979.1, 1019.9, 1060.7],
						Daze = [271.9, 284.3, 296.7, 309.1, 321.5, 333.9, 346.3, 358.7, 371.1, 383.5, 395.9, 408.3, 420.7, 433.1, 445.5, 457.9]
					},
					new()// Finishing Move DMG Multiplier
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [394.4, 430.3, 466.2, 502.1, 538.0, 573.9, 609.8, 645.7, 681.6, 717.5, 753.4, 789.3, 825.2, 861.1, 897.0, 932.9],
						Daze = [217.6, 227.5, 237.4, 247.3, 257.2, 267.1, 277.0, 286.9, 296.8, 306.7, 316.6, 326.5, 336.4, 346.3, 356.2, 366.1]
					}
				]
			},
			new()// Dash Attack: Breach
			{
				Id = "Breach",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [49.5, 54, 58.5, 63, 67.5, 72, 76.5, 81, 85.5, 90, 94.5, 99, 103.5, 108, 112.5, 117],
						Daze = [24.8, 26, 27.2, 28.4, 29.6, 30.8, 32.0, 33.2, 34.4, 35.6, 36.8, 38.0, 39.2, 40.4, 41.6, 42.8]
					}
				]
			},
			new()// Dodge Counter: Lingering Sentiments
			{
				Id = "LingeringSentiments",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Electric,
						Dmg = [284, 309.9, 335.8, 361.7, 387.6, 413.5, 439.4, 465.3, 491.2, 517.1, 543.0, 568.9, 594.8, 620.7, 646.6, 672.5],
						Daze = [190.4, 199.1, 207.8, 216.5, 225.2, 233.9, 242.6, 251.3, 260.0, 268.7, 277.4, 286.1, 294.8, 303.5, 312.2, 320.9]
					}
				]
			},
			new()// Quick Assist: Wind Through the Pines
			{
				Id = "WindThroughthePines",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Electric,
						Dmg = [133.9, 146.1, 158.3, 170.5, 182.7, 194.9, 207.1, 219.3, 231.5, 243.7, 255.9, 268.1, 280.3, 292.5, 304.7, 316.9],
						Daze = [133.9, 140, 146.1, 152.2, 158.3, 164.4, 170.5, 176.6, 182.7, 188.8, 194.9, 201.0, 207.1, 213.2, 219.3, 225.4]
					}
				]
			},
			new()// Defensive Assist: Graceful Embellishment
			{
				Id = "GracefulEmbellishment",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [249.3, 260.7, 272.1, 283.5, 294.9, 306.3, 317.7, 329.1, 340.5, 351.9, 363.3, 374.7, 386.1, 397.5, 408.9, 420.3]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [304.3, 318.2, 332.1, 346.0, 359.9, 373.8, 387.7, 401.6, 415.5, 429.4, 443.3, 457.2, 471.1, 485.0, 498.9, 512.8]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [128.3, 134.2, 140.1, 146.0, 151.9, 157.8, 163.7, 169.6, 175.5, 181.4, 187.3, 193.2, 199.1, 205.0, 210.9, 216.8]
					}
				]
			},
			new()// Assist Follow-Up: Song of the Clear River
			{
				Id = "SongoftheClearRiver",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Electric,
						Dmg = [376.4, 410.7, 445, 479.3, 513.6, 547.9, 582.2, 616.5, 650.8, 685.1, 719.4, 753.7, 788.0, 822.3, 856.6, 890.9],
						Daze = [279, 291.7, 304.4, 317.1, 329.8, 342.5, 355.2, 367.9, 380.6, 393.3, 406.0, 418.7, 431.4, 444.1, 456.8, 469.5]
					}
				]
			},
			new()// Special Attack: Sunlit Glory
			{
				Id = "SunlitGlory",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Electric,
						Dmg = [62.4, 68.1, 73.8, 79.5, 85.2, 90.9, 96.6, 102.3, 108.0, 113.7, 119.4, 125.1, 130.8, 136.5, 142.2, 147.9],
						Daze = [62.4, 65.3, 68.2, 71.1, 74.0, 76.9, 79.8, 82.7, 85.6, 88.5, 91.4, 94.3, 97.2, 100.1, 103.0, 105.9]
					}
				]
			},
			new()// EX Special Attack: Moonlit Begonia
			{
				Id = "MoonlitBegonia",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Electric,
						Dmg = [602.8, 657.7, 712.6, 767.5, 822.4, 877.3, 932.2, 987.1, 1042.0, 1096.9, 1151.8, 1206.7, 1261.6, 1316.5, 1371.4, 1426.3],
						Daze = [444.3, 464.6, 484.9, 505.2, 525.5, 545.8, 566.1, 586.4, 606.7, 627.0, 647.3, 667.6, 687.9, 708.2, 728.5, 748.8]
					}
				]
			},
			new()// Chain Attack: Tranquil Serenade
			{
				Id = "TranquilSerenade",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Electric,
						Dmg = [647.9, 706.8, 765.7, 824.6, 883.5, 942.4, 1001.3, 1060.2, 1119.1, 1178, 1236.9, 1295.8, 1354.7, 1413.6, 1472.5, 1531.4],
						//TODO: increase damage for each stack of core pasive
						Daze = [209, 218.5, 228, 237.5, 247, 256.5, 266, 275.5, 285, 294.5, 304, 313.5, 323, 332.5, 342, 351.5]
					}
				]
			},
			new()// Ultimate: Eight Sounds of Ganzhou
			{
				Id = "EightSoundsofGanzhou",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Electric,
						Dmg = [1670.7, 1822.6, 1974.5, 2126.4, 2278.3, 2430.2, 2582.1, 2734.0, 2885.9, 3037.8, 3189.7, 3341.6, 3493.5, 3645.4, 3797.3, 3949.2],
						Daze = [1097.1, 1147, 1196.9, 1246.8, 1296.7, 1346.6, 1396.5, 1446.4, 1496.3, 1546.2, 1596.1, 1646.0, 1695.9, 1745.8, 1795.7, 1845.6]
					}
				]
			}
		],
		Cinemas =
		{
			[1] = new BuffInfo
			{
				Modifiers =
				[
					new() { Stat = Def, Value = -15, Type = CombatPercent, Enemy = true },
					new() { Stat = CritRate, Value = 20, Type = Combat }
				]
			},
			// todo: add qingyi cinema 2
			[6] = new()
			{
				Buffs =
				[
					new()
					{
						Type = Permanent,
						AbilityCondition = skill => skill.Id == "Basic.EnchantedMoonlitBlossoms",
						Modifiers = new StatModifier { Stat = CritDmg, Value = 100 },
					},
					new StatModifier
					{
						Stat = DmgRes, Value = 20, Enemy = true, Type = Combat
					}
				]
			}
		}
	};
}