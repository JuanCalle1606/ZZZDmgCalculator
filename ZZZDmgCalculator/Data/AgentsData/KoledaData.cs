namespace ZZZDmgCalculator.Data.AgentsData;

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
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static Models.Info.DodgeTypes;

[InfoData<Agents>(Koleda)]
public class KoledaData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Koleda,
		Icon = "Koleda_Belobog",
		Attribute = Fire,
		Faction = Belobog,
		Specialty = Stun,
		AttackType = Strike,
		DodgeType = Parry,
		Rank = S,
		AdditionalCondition = BasicAdditionalCondition,
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
			Templates["Koleda.Atk"],
			Templates["Koleda.Hp"],
			Templates["Koleda.Def"],
		],
		FinalStats = [0, 116, 96, 97, 1.2],
		CoreBuff = new BuffInfo()
		{
			Scales = [[30, 35, 40, 45, 50, 55, 60]],
			Modifiers = new StatModifier
			{
				Stat = Daze, Type = Combat
			}
		},
		AdditionalBuff = new BuffInfo()
		{
			Type = Stack,
			Stacks = 2,
			Modifiers = new StatModifier
			{
				Stat = ChainDmg, Type = Combat, Value = 35, Shared = true
			}
		},
		Abilities =
		[
			new()// Basic Attack: Smash 'n' Bash
			{
				Id = "SmashnBash",
				Category = Basic,
				UseCommonNames = true,
				MaxCommonName = 4,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [63.6, 69.4, 75.2, 81, 86.8, 92.6, 98.4, 104.2, 110.0, 115.8, 121.6, 127.4, 133.2, 139, 144.8, 150.6],
						Daze = [31.8, 33.3, 34.8, 36.3, 37.8, 39.3, 40.8, 42.3, 43.8, 45.3, 46.8, 48.3, 49.8, 51.3, 52.8, 54.3]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [79.2, 86.4, 93.6, 100.8, 108.0, 115.2, 122.4, 129.6, 136.8, 144, 151.2, 158.4, 165.6, 172.8, 180.0, 187.2],
						Daze = [65.5, 68.5, 71.5, 74.5, 77.5, 80.5, 83.5, 86.5, 89.5, 92.5, 95.5, 98.5, 101.5, 104.5, 107.5, 110.5]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [126.1, 137.6, 149.1, 160.6, 172.1, 183.6, 195.1, 206.6, 218.1, 229.6, 241.1, 252.6, 264.1, 275.6, 287.1, 298.6],
						Daze = [104.3, 109.1, 113.9, 118.7, 123.5, 128.3, 133.1, 137.9, 142.7, 147.5, 152.3, 157.1, 161.9, 166.7, 171.5, 176.3]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [317.4, 346.3, 375.2, 404.1, 433.0, 461.9, 490.8, 519.7, 548.6, 577.5, 606.4, 635.3, 664.2, 693.1, 722.0, 750.9],
						Daze = [249.3, 260.7, 272.1, 283.5, 294.9, 306.3, 317.7, 329.1, 340.5, 351.9, 363.3, 374.7, 386.1, 397.5, 408.9, 420.3]
					},
					new()// Enhanced Basic Attack 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Dmg = [160.8, 175.5, 190.2, 204.9, 219.6, 234.3, 249.0, 263.7, 278.4, 293.1, 307.8, 322.5, 337.2, 351.9, 366.6, 381.3],
						Daze = [61.4, 64.2, 67, 69.8, 72.6, 75.4, 78.2, 81.0, 83.8, 86.6, 89.4, 92.2, 95.0, 97.8, 100.6, 103.4]
					},
					new()// Enhanced Basic Attack 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Dmg = [404.8, 441.7, 478.6, 515.5, 552.4, 589.3, 626.2, 663.1, 700.0, 736.9, 773.8, 810.7, 847.6, 884.5, 921.4, 958.3],
						Daze = [156.6, 163.8, 171.0, 178.2, 185.4, 192.6, 199.8, 207.0, 214.2, 221.4, 228.6, 235.8, 243.0, 250.2, 257.4, 264.6]
					},
					new()// Enhanced Basic Attack 2nd-Hit DMG Multiplier (Teamwork) (%)
					{
						Type = Basic,
						DmgType = Fire,
						Dmg = [501.3, 546.9, 592.5, 638.1, 683.7, 729.3, 774.9, 820.5, 866.1, 911.7, 957.3, 1002.9, 1048.5, 1094.1, 1139.7, 1185.3],
						Daze = [234.6, 245.3, 256.0, 266.7, 277.4, 288.1, 298.8, 309.5, 320.2, 330.9, 341.6, 352.3, 363.0, 373.7, 384.4, 395.1]
					}
				]
			},
			new()// Dash Attack: Tremble!
			{
				Id = "Tremble",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [56.1, 61.2, 66.3, 71.4, 76.5, 81.6, 86.7, 91.8, 96.9, 102.0, 107.1, 112.2, 117.3, 122.4, 127.5, 132.6],
						Daze = [28.1, 29.4, 30.7, 32, 33.3, 34.6, 35.9, 37.2, 38.5, 39.8, 41.1, 42.4, 43.7, 45.0, 46.3, 47.6]
					}
				]
			},
			new()// Dodge Counter: Don't Look Down on Me
			{
				Id = "DontLookDownonMe",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Fire,
						Dmg = [343.9, 375.2, 406.5, 437.8, 469.1, 500.4, 531.7, 563, 594.3, 625.6, 656.9, 688.2, 719.5, 750.8, 782.1, 813.4],
						Daze = [288.8, 302, 315.2, 328.4, 341.6, 354.8, 368.0, 381.2, 394.4, 407.6, 420.8, 434.0, 447.2, 460.4, 473.6, 486.8]
					}
				]
			},
			new()// Quick Assist: Coming Thru!
			{
				Id = "ComingThru",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Fire,
						Dmg = [183.8, 200.6, 217.4, 234.2, 251.0, 267.8, 284.6, 301.4, 318.2, 335.0, 351.8, 368.6, 385.4, 402.2, 419.0, 435.8],
						Daze = [183.8, 192.2, 200.6, 209.0, 217.4, 225.8, 234.2, 242.6, 251.0, 259.4, 267.8, 276.2, 284.6, 293.0, 301.4, 309.8]
					}
				]
			},
			new()// Defensive Assist: Protective Hammer
			{
				Id = "ProtectiveHammer",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [259, 270.8, 282.6, 294.4, 306.2, 318.0, 329.8, 341.6, 353.4, 365.2, 377.0, 388.8, 400.6, 412.4, 424.2, 436.0]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [327.3, 342.2, 357.1, 372.0, 386.9, 401.8, 416.7, 431.6, 446.5, 461.4, 476.3, 491.2, 506.1, 521.0, 535.9, 550.8]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [159.3, 166.6, 173.9, 181.2, 188.5, 195.8, 203.1, 210.4, 217.7, 225.0, 232.3, 239.6, 246.9, 254.2, 261.5, 268.8]
					}
				]
			},
			new()// Assist Follow-Up: Hammer Bell
			{
				Id = "HammerBell",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Fire,
						Dmg = [359.2, 391.9, 424.6, 457.3, 490.0, 522.7, 555.4, 588.1, 620.8, 653.5, 686.2, 718.9, 751.6, 784.3, 817.0, 849.7],
						Daze = [312.7, 327, 341.3, 355.6, 369.9, 384.2, 398.5, 412.8, 427.1, 441.4, 455.7, 470.0, 484.3, 498.6, 512.9, 527.2]
					}
				]
			},
			new()// Special Attack: Hammer Time
			{
				Id = "HammerTime",
				Category = Special,
				Skills =
				[
					new()// Strike DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Fire,
						Dmg = [51.9, 56.7, 61.5, 66.3, 71.1, 75.9, 80.7, 85.5, 90.3, 95.1, 99.9, 104.7, 109.5, 114.3, 119.1, 123.9],
						Daze = [51.9, 54.3, 56.7, 59.1, 61.5, 63.9, 66.3, 68.7, 71.1, 73.5, 75.9, 78.3, 80.7, 83.1, 85.5, 87.9]
					},
					new()// Explosion DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Fire,
						Dmg = [77.8, 84.9, 92.0, 99.1, 106.2, 113.3, 120.4, 127.5, 134.6, 141.7, 148.8, 155.9, 163.0, 170.1, 177.2, 184.3],
						Daze = [77.8, 81.4, 85.0, 88.6, 92.2, 95.8, 99.4, 103.0, 106.6, 110.2, 113.8, 117.4, 121.0, 124.6, 128.2, 131.8]
					},
					new()// Explosion DMG Multiplier (Teamwork) (%)
					{
						Type = Special,
						DmgType = Fire,
						Dmg = [85.5, 93.3, 101.1, 108.9, 116.7, 124.5, 132.3, 140.1, 147.9, 155.7, 163.5, 171.3, 179.1, 186.9, 194.7, 202.5],
						Daze = [77.8, 81.4, 85.0, 88.6, 92.2, 95.8, 99.4, 103.0, 106.6, 110.2, 113.8, 117.4, 121.0, 124.6, 128.2, 131.8]
					}
				]
			},
			new()// EX Special Attack: Boiling Furnace
			{
				Id = "BoilingFurnace",
				Category = Special,
				Skills =
				[
					new()// Strike DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [152.3, 166.2, 180.1, 194.0, 207.9, 221.8, 235.7, 249.6, 263.5, 277.4, 291.3, 305.2, 319.1, 333.0, 346.9, 360.8],
						Daze = [152.3, 159.3, 166.3, 173.3, 180.3, 187.3, 194.3, 201.3, 208.3, 215.3, 222.3, 229.3, 236.3, 243.3, 250.3, 257.3]
					},
					new()// Explosion DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [606, 661.1, 716.2, 771.3, 826.4, 881.5, 936.6, 991.7, 1046.8, 1101.9, 1157, 1212.1, 1267.2, 1322.3, 1377.4, 1432.5],
						Daze = [494, 516.5, 539, 561.5, 584, 606.5, 629, 651.5, 674, 696.5, 719, 741.5, 764, 786.5, 809, 831.5]
					},
					new()// Explosion DMG Multiplier (Teamwork) (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [666.6, 727.2, 787.8, 848.4, 909.0, 969.6, 1030.2, 1090.8, 1151.4, 1212.0, 1272.6, 1333.2, 1393.8, 1454.4, 1515.0, 1575.6],
						Daze = [494, 516.5, 539, 561.5, 584, 606.5, 629, 651.5, 674, 696.5, 719, 741.5, 764, 786.5, 809, 831.5]
					}
				]
			},
			new()// Chain Attack: Natural Disaster
			{
				Id = "NaturalDisaster",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Fire,
						Dmg = [636, 693.9, 751.8, 809.7, 867.6, 925.5, 983.4, 1041.3, 1099.2, 1157.1, 1215.0, 1272.9, 1330.8, 1388.7, 1446.6, 1504.5],
						Daze = [217, 226.9, 236.8, 246.7, 256.6, 266.5, 276.4, 286.3, 296.2, 306.1, 316.0, 325.9, 335.8, 345.7, 355.6, 365.5]
					}
				]
			},
			new()// Ultimate: Hammerquake
			{
				Id = "Hammerquake",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Fire,
						Dmg = [1548.8, 1689.6, 1830.4, 1971.2, 2112, 2252.8, 2393.6, 2534.4, 2675.2, 2816.0, 2956.8, 3097.6, 3238.4, 3379.2, 3520.0, 3660.8],
						Daze = [1004.9, 1050.6, 1096.3, 1142, 1187.7, 1233.4, 1279.1, 1324.8, 1370.5, 1416.2, 1461.9, 1507.6, 1553.3, 1599.0, 1644.7, 1690.4]
					},
					new()// DMG Multiplier (Teamwork) (%)
					{
						Type = Ultimate,
						DmgType = Fire,
						Dmg = [1694, 1848, 2002, 2156, 2310, 2464, 2618, 2772, 2926, 3080, 3234, 3388, 3542, 3696, 3850, 4004],
						Daze = [1096.5, 1146.4, 1196.3, 1246.2, 1296.1, 1346.0, 1395.9, 1445.8, 1495.7, 1545.6, 1595.5, 1645.4, 1695.3, 1745.2, 1795.1, 1845.0]
					}
				]
			}
		],
		Cinemas =
		{
			// TODO: Add c1
			[4] = new BuffInfo
			{
				Type = Stack,
				Stacks = 2,
				AbilityCondition = skill => skill.Category == Ultimate,// this covers chain and ultimate
				Modifiers = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 18 },
			},
			[6] = new SkillInfo
			{
				Value = 360,
				Cinema = true
			}
		}
	};
}