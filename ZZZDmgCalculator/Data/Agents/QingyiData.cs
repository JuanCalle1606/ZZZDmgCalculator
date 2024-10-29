namespace ZZZDmgCalculator.Data.Agents;

using Models.Enum;
using Models.Info;
using static AgentScales;
using static Models.Enum.Agents;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Factions;
using static Models.Enum.Skills;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static Models.Info.DodgeTypes;

[InfoData<Agents>(Qingyi)]
public class QingyiData {
	public readonly static AgentInfo Data = new()
	{
		Id = nameof(Qingyi),
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
				Stat = StunDmg, Enemy = true
			}
		},
		// TODO: Add qingyi additional buff
		Abilities =
		[
			new()// Basic Attack: Penultimate
			{
				Id = "Penultimate",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [47.2, 51.5, 55.8, 60.1, 64.4, 68.7, 73.0, 77.3, 81.6, 85.9, 90.2, 94.5, 98.8, 103.1, 107.4, 111.7]
					},
					new()// 1st-Hit DMG Multiplier (ALT)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [110.3, 120.4, 130.5, 140.6, 150.7, 160.8, 170.9, 181.0, 191.1, 201.2, 211.3, 221.4, 231.5, 241.6, 251.7, 261.8]
					},
					new()// 2nd-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [122.1, 133.2, 144.3, 155.4, 166.5, 177.6, 188.7, 199.8, 210.9, 222.0, 233.1, 244.2, 255.3, 266.4, 277.5, 288.6]
					},
					new()// 3rd-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Electric,
						Scales = [17.6, 19.2, 20.8, 22.4, 24.0, 25.6, 27.2, 28.8, 30.4, 32.0, 33.6, 35.2, 36.8, 38.4, 40.0, 41.6]
					},
					new()// 4th-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Electric,
						Scales = [106.4, 116.1, 125.8, 135.5, 145.2, 154.9, 164.6, 174.3, 184.0, 193.7, 203.4, 213.1, 222.8, 232.5, 242.2, 251.9]
					},
					new()// 4th-Hit DMG Multiplier (Enhanced)
					{
						Type = Basic,
						DmgType = Electric,
						Scales = [234.4, 255.8, 277.2, 298.6, 320.0, 341.4, 362.8, 384.2, 405.6, 427.0, 448.4, 469.8, 491.2, 512.6, 534.0, 555.4]
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
						Scales = [85.6, 93.4, 101.2, 109.0, 116.8, 124.6, 132.4, 140.2, 148, 155.8, 163.6, 171.4, 179.2, 187.0, 194.8, 202.6]
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
						Scales = [448.7, 489.5, 530.3, 571.1, 611.9, 652.7, 693.5, 734.3, 775.1, 815.9, 856.7, 897.5, 938.3, 979.1, 1019.9, 1060.7]
					},
					new()// Finishing Move DMG Multiplier
					{
						Type = Basic,
						DmgType = Electric,
						Scales = [394.4, 430.3, 466.2, 502.1, 538.0, 573.9, 609.8, 645.7, 681.6, 717.5, 753.4, 789.3, 825.2, 861.1, 897.0, 932.9]
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
						Scales = [49.5, 54, 58.5, 63, 67.5, 72, 76.5, 81, 85.5, 90, 94.5, 99, 103.5, 108, 112.5, 117]
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
						Scales = [284, 309.9, 335.8, 361.7, 387.6, 413.5, 439.4, 465.3, 491.2, 517.1, 543.0, 568.9, 594.8, 620.7, 646.6, 672.5]
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
						Scales = [133.9, 146.1, 158.3, 170.5, 182.7, 194.9, 207.1, 219.3, 231.5, 243.7, 255.9, 268.1, 280.3, 292.5, 304.7, 316.9]
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
						Scales = [376.4, 410.7, 445, 479.3, 513.6, 547.9, 582.2, 616.5, 650.8, 685.1, 719.4, 753.7, 788.0, 822.3, 856.6, 890.9]
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
						Scales = [62.4, 68.1, 73.8, 79.5, 85.2, 90.9, 96.6, 102.3, 108.0, 113.7, 119.4, 125.1, 130.8, 136.5, 142.2, 147.9]
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
						Scales = [602.8, 657.7, 712.6, 767.5, 822.4, 877.3, 932.2, 987.1, 1042.0, 1096.9, 1151.8, 1206.7, 1261.6, 1316.5, 1371.4, 1426.3]
					}
				]
			},
			new()// Chain Attack: Tranquil Serenade
			{
				Id = "TranquilSerenade",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Electric,
						Scales = [647.9, 706.8, 765.7, 824.6, 883.5, 942.4, 1001.3, 1060.2, 1119.1, 1178, 1236.9, 1295.8, 1354.7, 1413.6, 1472.5, 1531.4]
						//TODO: increase damage for each stack of core pasive
					}
				]
			},
			new()// Ultimate: Eight Sounds of Ganzhou
			{
				Id = "EightSoundsofGanzhou",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Electric,
						Scales = [1670.7, 1822.6, 1974.5, 2126.4, 2278.3, 2430.2, 2582.1, 2734.0, 2885.9, 3037.8, 3189.7, 3341.6, 3493.5, 3645.4, 3797.3, 3949.2]
					}
				]
			}
		],
		Cinema =
		{
			[1] = new BuffInfo
			{
				Modifiers =
				[
					new() { Stat = Def, Value = -15, Type = CombatPercent, Enemy = true },
					new() { Stat = CritRate, Value = 20, Type = Combat }
				]
			},
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
						Stat = DmgRes, Value = 20, Enemy = true
					}
				]
			}
		}
	};
}