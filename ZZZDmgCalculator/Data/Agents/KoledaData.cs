namespace ZZZDmgCalculator.Data.Agents;

using Models.Enum;
using Models.Info;
using static AgentScales;
using static Models.Enum.AgentRank;
using static Models.Enum.Agents;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Factions;
using static Models.Enum.Skills;
using static Models.Enum.Specialties;
using static Models.Enum.Stats;
using static Models.Info.DodgeTypes;

[InfoData<Agents>(Koleda)]
public class KoledaData {
	public readonly static AgentInfo Data = new()
	{
		Id = nameof(Koleda),
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
		// TODO: Add core buff when app support daze
		AdditionalBuff = new BuffInfo()
		{
			Type = Stack,
			Stacks = 2,
			SkillCondition = skill => skill.Type == Chain,
			Modifiers = new StatModifier
			{
				Stat = BonusDmg, Value = 35, Shared = true
			}
		},
		Abilities =
		[
			new()// Basic Attack: Smash 'n' Bash
			{
				Id = "SmashnBash",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [63.6, 69.4, 75.2, 81, 86.8, 92.6, 98.4, 104.2, 110.0, 115.8, 121.6, 127.4, 133.2, 139, 144.8, 150.6]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [79.2, 86.4, 93.6, 100.8, 108.0, 115.2, 122.4, 129.6, 136.8, 144, 151.2, 158.4, 165.6, 172.8, 180.0, 187.2]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [126.1, 137.6, 149.1, 160.6, 172.1, 183.6, 195.1, 206.6, 218.1, 229.6, 241.1, 252.6, 264.1, 275.6, 287.1, 298.6]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [317.4, 346.3, 375.2, 404.1, 433.0, 461.9, 490.8, 519.7, 548.6, 577.5, 606.4, 635.3, 664.2, 693.1, 722.0, 750.9]
					},
					new()// Enhanced Basic Attack 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Scales = [160.8, 175.5, 190.2, 204.9, 219.6, 234.3, 249.0, 263.7, 278.4, 293.1, 307.8, 322.5, 337.2, 351.9, 366.6, 381.3]
					},
					new()// Enhanced Basic Attack 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Scales = [404.8, 441.7, 478.6, 515.5, 552.4, 589.3, 626.2, 663.1, 700.0, 736.9, 773.8, 810.7, 847.6, 884.5, 921.4, 958.3]
					},
					new()// Enhanced Basic Attack 2nd-Hit DMG Multiplier (Teamwork) (%)
					{
						Type = Basic,
						DmgType = Fire,
						Scales = [501.3, 546.9, 592.5, 638.1, 683.7, 729.3, 774.9, 820.5, 866.1, 911.7, 957.3, 1002.9, 1048.5, 1094.1, 1139.7, 1185.3]
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
						Scales = [56.1, 61.2, 66.3, 71.4, 76.5, 81.6, 86.7, 91.8, 96.9, 102.0, 107.1, 112.2, 117.3, 122.4, 127.5, 132.6]
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
						Scales = [343.9, 375.2, 406.5, 437.8, 469.1, 500.4, 531.7, 563, 594.3, 625.6, 656.9, 688.2, 719.5, 750.8, 782.1, 813.4]
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
						Scales = [183.8, 200.6, 217.4, 234.2, 251.0, 267.8, 284.6, 301.4, 318.2, 335.0, 351.8, 368.6, 385.4, 402.2, 419.0, 435.8]
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
						Scales = [359.2, 391.9, 424.6, 457.3, 490.0, 522.7, 555.4, 588.1, 620.8, 653.5, 686.2, 718.9, 751.6, 784.3, 817.0, 849.7]
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
						Scales = [51.9, 56.7, 61.5, 66.3, 71.1, 75.9, 80.7, 85.5, 90.3, 95.1, 99.9, 104.7, 109.5, 114.3, 119.1, 123.9]
					},
					new()// Explosion DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Fire,
						Scales = [77.8, 84.9, 92.0, 99.1, 106.2, 113.3, 120.4, 127.5, 134.6, 141.7, 148.8, 155.9, 163.0, 170.1, 177.2, 184.3]
					},
					new()// Explosion DMG Multiplier (Teamwork) (%)
					{
						Type = Special,
						DmgType = Fire,
						Scales = [85.5, 93.3, 101.1, 108.9, 116.7, 124.5, 132.3, 140.1, 147.9, 155.7, 163.5, 171.3, 179.1, 186.9, 194.7, 202.5]
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
						Scales = [152.3, 166.2, 180.1, 194.0, 207.9, 221.8, 235.7, 249.6, 263.5, 277.4, 291.3, 305.2, 319.1, 333.0, 346.9, 360.8]
					},
					new()// Explosion DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Scales = [606, 661.1, 716.2, 771.3, 826.4, 881.5, 936.6, 991.7, 1046.8, 1101.9, 1157, 1212.1, 1267.2, 1322.3, 1377.4, 1432.5]
					},
					new()// Explosion DMG Multiplier (Teamwork) (%)
					{
						Type = Ex,
						DmgType = Fire,
						Scales = [666.6, 727.2, 787.8, 848.4, 909.0, 969.6, 1030.2, 1090.8, 1151.4, 1212.0, 1272.6, 1333.2, 1393.8, 1454.4, 1515.0, 1575.6]
					}
				]
			},
			new()// Chain Attack: Natural Disaster
			{
				Id = "NaturalDisaster",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Fire,
						Scales = [636, 693.9, 751.8, 809.7, 867.6, 925.5, 983.4, 1041.3, 1099.2, 1157.1, 1215.0, 1272.9, 1330.8, 1388.7, 1446.6, 1504.5]
					}
				]
			},
			new()// Ultimate: Hammerquake
			{
				Id = "Hammerquake",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Fire,
						Scales = [1548.8, 1689.6, 1830.4, 1971.2, 2112, 2252.8, 2393.6, 2534.4, 2675.2, 2816.0, 2956.8, 3097.6, 3238.4, 3379.2, 3520.0, 3660.8]
					},
					new()// DMG Multiplier (Teamwork) (%)
					{
						Type = Ultimate,
						DmgType = Fire,
						Scales = [1694, 1848, 2002, 2156, 2310, 2464, 2618, 2772, 2926, 3080, 3234, 3388, 3542, 3696, 3850, 4004]
					}
				]
			}
		],
		Cinema =
		{
			[4] = new BuffInfo
			{
				Type = Stack,
				Stacks = 2,
				AbilityCondition = skill => skill.Category == Chain,// this covers chain and ultimate
				Modifiers = new StatModifier { Stat = BonusDmg, Value = 18 },
			},
			[6] = new SkillInfo
			{
				Value = 360,
				Cinema = true
			}
		}
	};
}