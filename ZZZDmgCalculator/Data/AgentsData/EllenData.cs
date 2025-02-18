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

[InfoData<Agents>(Ellen)]
public class EllenData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Ellen,
		Icon = "Ellen_Joe",
		Attribute = Ice,
		Faction = Victoria,
		Specialty = Attack,
		AttackType = Slash,
		DodgeType = Parry,
		Rank = AgentRank.S,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = CritRate,
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
			Templates["Ellen.Atk"],
			Templates["Ellen.Hp"],
			Templates["Lycaon.Def"],
		],
		FinalStats = [0, 93, 93, 94, 1.2],
		CoreBuff = new BuffInfo
		{
			Type = Permanent,
			Scales = [Templates["Ellen.Core"]],
			SkillCondition = s => s.Ability is "FlashFreezeTrimming" || s is { Ability: "ArcticAmbush", Index: 2 },
			Modifiers = new StatModifier
			{
				Stat = CritDmg,
				Type = Combat
			}
		},
		AdditionalBuff = new BuffInfo
		{
			Type = Stack,
			Stacks = 10,
			Modifiers = new StatModifier { Stat = IceDmg, Type = Combat, Value = 3 }
		},
		Abilities =
		[
			new()// Basic Attack: Saw Teeth Trimming
			{
				Id = "SawTeethTrimming",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [48.8, 53.3, 57.8, 62.3, 66.8, 71.3, 75.8, 80.3, 84.8, 89.3, 93.8, 98.3, 102.8, 107.3, 111.8, 116.3],
						Daze = [24.4, 25.6, 26.8, 28, 29.2, 30.47, 31.68, 32.8, 34, 35.21, 36.4, 37.6, 107.3, 40, 41.2, 42.4]
					},
					new()// 2nd Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [111.1, 121.2, 131.3, 141.4, 151.5, 161.6, 171.7, 181.8, 191.9, 202, 212.1, 222.2, 232.3, 242.4, 252.5, 262.6],
						Daze = [86.8, 90.8, 94.8, 98.8, 102.8, 106.8, 110.8, 114.8, 118.8, 122.8, 126.8, 130.8, 242.4, 138.8, 142.86, 146.8]
					},
					new()// 3rd Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [250.6, 273.4, 296.2, 319, 341.8, 364.6, 387.4, 410.2, 433, 455.8, 478.6, 501.4, 524.2, 547, 569.86, 703.8],
						Daze = [204.5, 213.8, 223.1, 232.4, 241.7, 251, 260.3, 269.6, 278.90, 288.21, 297.52, 306.8, 547, 325.4, 334.7, 405.4]
					}
				]
			},
			new()// Basic Attack: Flash Freeze Trimming
			{
				Id = "FlashFreezeTrimming",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [99.6, 108.7, 117.8, 126.9, 136.0, 145.1, 154.2, 163.3, 172.4, 181.5, 190.6, 199.7, 208.8, 217.9, 227.0, 236.1],
						Daze = [48.8, 51.1, 53.4, 55.7, 58.0, 60.3, 62.6, 64.9, 67.2, 69.5, 71.8, 74.1, 76.4, 78.7, 81.0, 83.3]
					},
					new()// 2nd Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [184, 200.8, 217.6, 234.4, 251.2, 268.0, 284.8, 301.6, 318.4, 335.2, 352.0, 368.8, 385.6, 402.4, 419.2, 436.0],
						Daze = [90.2, 94.3, 98.4, 102.5, 106.6, 110.7, 114.8, 118.9, 123.0, 127.1, 131.2, 135.3, 139.4, 143.5, 147.6, 151.7]
					},
					new()// 3rd Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [496.2, 541.4, 586.6, 631.8, 677.0, 722.2, 767.4, 812.6, 857.8, 903.0, 948.2, 993.4, 1038.6, 1083.8, 1129.0, 1174.2],
						Daze = [245.5, 256.7, 267.9, 279.1, 290.3, 301.5, 312.7, 323.9, 335.1, 346.3, 357.5, 368.7, 379.9, 391.1, 402.3, 413.5]
					}
				]
			},
			new()// Dash Attack: Arctic Ambush
			{
				Id = "ArcticAmbush",
				Category = Dodge,
				Skills =
				[
					new()// Spinning Slash DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Ice,
						Dmg = [62.3, 68.0, 73.7, 79.4, 85.1, 90.8, 96.5, 102.2, 107.9, 113.6, 119.3, 125.0, 130.7, 136.4, 142.1, 147.8],
						Daze = [62.3, 65.2, 68.1, 71.0, 73.9, 76.8, 79.7, 82.6, 85.5, 88.4, 91.3, 94.2, 97.1, 100.0, 102.9, 105.8]
					},
					new()// Swift Scissors DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Ice,
						Dmg = [127.6, 139.2, 150.8, 162.4, 174.0, 185.6, 197.2, 208.8, 220.4, 232.0, 243.6, 255.2, 266.8, 278.4, 290.0, 301.6],
						Daze = [98.2, 102.7, 107.2, 111.7, 116.2, 120.7, 125.2, 129.7, 134.2, 138.7, 143.2, 147.7, 152.2, 156.7, 161.2, 165.7]
					},
					new()// Charged Scissors DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Ice,
						Dmg = [158.2, 172.6, 187.0, 201.4, 215.8, 230.2, 244.6, 259.0, 273.4, 287.8, 302.2, 316.6, 331.0, 345.4, 359.8, 374.2],
						Daze = [121.7, 127.3, 132.9, 138.5, 144.1, 149.7, 155.3, 160.9, 166.5, 172.1, 177.7, 183.3, 188.9, 194.5, 200.1, 205.7]
					}
				]
			},
			new()// Dash Attack: Monstrous Wave
			{
				Id = "MonstrousWave",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [77, 84, 91, 98, 105, 112, 119, 126, 133, 140, 147, 154, 161, 168, 175, 182],
						Daze = [38.5, 40.3, 42.1, 43.9, 45.7, 47.5, 49.3, 51.1, 52.9, 54.7, 56.5, 58.3, 60.1, 61.9, 63.7, 65.5]
					}
				]
			},
			new()// Dash Attack: Cold Snap
			{
				Id = "ColdSnap",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Ice,
						Dmg = [145.7, 159.0, 172.3, 185.6, 198.9, 212.2, 225.5, 238.8, 252.1, 265.4, 278.7, 292.0, 305.3, 318.6, 331.9, 345.2],
						Daze = [78.8, 82.4, 86.0, 89.6, 93.2, 96.8, 100.4, 104.0, 107.6, 111.2, 114.8, 118.4, 122.0, 125.6, 129.2, 132.8]
					}
				]
			},
			new()// Dodge Counter: Reef Rock
			{
				Id = "ReefRock",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Ice,
						Dmg = [152.6, 166.5, 180.4, 194.3, 208.2, 222.1, 236.0, 249.9, 263.8, 277.7, 291.6, 305.5, 319.4, 333.3, 347.2, 361.1],
						Daze = [227.4, 237.8, 248.2, 258.6, 269.0, 279.4, 289.8, 300.2, 310.6, 321.0, 331.4, 341.8, 352.2, 362.6, 373.0, 383.4]
					}
				]
			},
			new()// Quick Assist: Shark Sentinel
			{
				Id = "SharkSentinel",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Ice,
						Dmg = [121.1, 132.2, 143.3, 154.4, 165.5, 176.6, 187.7, 198.8, 209.9, 221.0, 232.1, 243.2, 254.3, 265.4, 276.5, 287.6],
						Daze = [121.1, 126.7, 132.3, 137.9, 143.5, 149.1, 154.7, 160.3, 165.9, 171.5, 177.1, 182.7, 188.3, 193.9, 199.5, 205.1]
					}
				]
			},
			new()// Defensive Assist: Wavefront Impact
			{
				Id = "WavefrontImpact",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [271.3, 283.7, 296.1, 308.5, 320.9, 333.3, 345.7, 358.1, 370.5, 382.9, 395.3, 407.7, 420.1, 432.5, 444.9, 457.3]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [342.8, 358.4, 374.0, 389.6, 405.2, 420.8, 436.4, 452.0, 467.6, 483.2, 498.8, 514.4, 530.0, 545.6, 561.2, 576.8]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [166.8, 174.4, 182.0, 189.6, 197.2, 204.8, 212.4, 220.0, 227.6, 235.2, 242.8, 250.4, 258.0, 265.6, 273.2, 280.8]
					}
				]
			},
			new()// Assist Follow-Up: Shark Cruiser
			{
				Id = "SharkCruiser",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Ice,
						Dmg = [437.9, 477.8, 517.7, 557.6, 597.5, 637.4, 677.3, 717.2, 757.1, 797.0, 836.9, 876.8, 916.7, 956.6, 996.5, 1036.4],
						Daze = [384.8, 402.3, 419.8, 437.3, 454.8, 472.3, 489.8, 507.3, 524.8, 542.3, 559.8, 577.3, 594.8, 612.3, 629.8, 647.3]
					}
				]
			},
			new()// Special Attack: Drift
			{
				Id = "Drift",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Dmg = [50.5, 55.1, 59.7, 64.3, 68.9, 73.5, 78.1, 82.7, 87.3, 91.9, 96.5, 101.1, 105.7, 110.3, 114.9, 119.5],
						Daze = [50.5, 52.8, 55.1, 57.4, 59.7, 62, 64.3, 66.6, 68.9, 71.2, 73.5, 75.8, 78.1, 80.4, 82.7, 85]
					}
				]
			},
			new()// EX Special Attack: Tail Swipe
			{
				Id = "TailSwipe",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ice,
						Dmg = [377.2, 411.5, 445.8, 480.1, 514.4, 548.7, 583, 617.3, 651.6, 685.9, 720.2, 754.5, 788.8, 823.1, 857.4, 891.7],
						Daze = [405.1, 423.6, 442.1, 460.6, 479.1, 497.6, 516.1, 534.6, 553.1, 571.6, 590.1, 608.6, 627.1, 645.6, 664.1, 682.6]
					}
				]
			},
			new()// EX Special Attack: Sharknami
			{
				Id = "Sharknami",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ice,
						Dmg = [553.3, 603.6, 653.9, 704.2, 754.5, 804.8, 855.1, 905.4, 955.7, 1006, 1056.3, 1106.6, 1156.9, 1207.2, 1257.5, 1307.8],
						Daze = [371.7, 388.6, 405.5, 422.4, 439.3, 456.2, 473.1, 490, 506.9, 523.8, 540.7, 557.6, 574.5, 591.4, 608.3, 625.2]
					}
				]
			},
			new()// Chain Attack: Avalanche
			{
				Id = "Avalanche",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ice,
						Dmg = [794.6, 866.9, 939.2, 1011.5, 1083.8, 1156.1, 1228.4, 1300.7, 1373.0, 1445.3, 1517.6, 1589.9, 1662.2, 1734.5, 1806.8, 1879.1],
						Daze = [355.7, 371.9, 388.1, 404.3, 420.5, 436.7, 452.9, 469.1, 485.3, 501.5, 517.7, 533.9, 550.1, 566.3, 582.5, 598.7]
					}
				]
			},
			new()// Ultimate: Endless Winter
			{
				Id = "EndlessWinter",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ice,
						Dmg = [1890.8, 2062.7, 2234.6, 2406.5, 2578.4, 2750.3, 2922.2, 3094.1, 3266.0, 3437.9, 3610.8, 3782.7, 3954.6, 4126.5, 4298.4, 4470.3],
						Daze = [185.2, 193.7, 202.2, 210.7, 219.2, 227.7, 236.2, 244.7, 253.2, 261.7, 270.2, 278.7, 287.2, 295.7, 304.2, 312.7]
					}
				]
			},
		],
		Cinemas =
		{
			[1] = new BuffInfo
			{
				Type = Stack,
				Stacks = 6,
				Modifiers = new StatModifier { Stat = CritRate, Type = Combat, Value = 2 }
			},
			[2] = new BuffInfo
			{
				Type = Stack,
				Stacks = 3,
				SkillCondition = skill => skill.Type is Ex,
				Modifiers = new StatModifier { Stat = CritDmg, Type = Combat, Value = 20 }
			},
			[6] = new()
			{
				Buffs =
				[
					new StatModifier
					{
						Stat = PenRatio, Type = Combat, Value = 20
					},
					new BuffInfo
					{
						SkillCondition = skill => skill is { Ability: "ArcticAmbush", Index: 2 },
						Modifiers = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 250 }
					}
				]
			}
		}
	};
}