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
using static Models.Enum.Stats;
using static Models.Info.DodgeTypes;

[InfoData<Agents>(Lycaon)]
public class LycaonData {
	public readonly static AgentInfo Data = new()
	{
		Id = nameof(Lycaon),
		Icon = "Von_Lycaon",
		Attribute = Ice,
		Faction = Victoria,
		Specialty = Stun,
		AttackType = Strike,
		DodgeType = Parry,
		Rank = AgentRank.S,
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
			Templates["Lycaon.Atk"],
			Templates["Lycaon.Hp"],
			Templates["Lycaon.Def"],
		],
		FinalStats = [0, 119, 90, 91, 1.2],
		CoreBuff = new StatModifier
		{
			Stat = IceRes, Value = 25, Enemy = true
		},
		AdditionalBuff = new StatModifier
		{
			Stat = StunDmg, Value = 35, Enemy = true
		},
		Abilities =
		[
			new()// Basic Attack: Moon Hunter
			{
				Id = "MoonHunter",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Scales = [29.2, 31.9, 34.6, 37.3, 40, 42.7, 45.4, 48.1, 50.8, 53.5, 56.2, 58.9, 61.6, 64.3, 67, 69.7]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Scales = [34.9, 38.1, 41.3, 44.5, 47.7, 50.9, 54.1, 57.3, 60.5, 63.7, 66.9, 70.1, 73.3, 76.5, 79.7, 82.9]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Scales = [58.4, 63.8, 69.2, 74.6, 80.0, 85.4, 90.8, 96.2, 101.6, 107.0, 112.4, 117.8, 123.2, 128.6, 134.0, 139.4]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Scales = [152.0, 165.9, 179.8, 193.7, 207.6, 221.5, 235.4, 249.3, 263.2, 277.1, 291.0, 304.9, 318.8, 332.7, 346.6, 360.5]
					},
					new()// 5th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Scales = [180.7, 197.2, 213.7, 230.2, 246.7, 263.2, 279.7, 296.2, 312.7, 329.2, 345.7, 362.2, 378.7, 395.2, 411.7, 428.2]
					},
					new()// 1st-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [37.1, 40.5, 43.9, 47.3, 50.7, 54.1, 57.5, 60.9, 64.3, 67.7, 71.1, 74.5, 77.9, 81.3, 84.7, 88.1]
					},
					new()// 2nd-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [56.4, 61.6, 66.8, 72.0, 77.2, 82.4, 87.6, 92.8, 98.0, 103.2, 108.4, 113.6, 118.8, 124.0, 129.2, 134.4]
					},
					new()// 3rd-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [99.5, 108.6, 117.7, 126.8, 135.9, 145.0, 154.1, 163.2, 172.3, 181.4, 190.5, 199.6, 208.7, 217.8, 226.9, 236.0]
					},
					new()// 4th-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [210.9, 230.1, 249.3, 268.5, 287.7, 306.9, 326.1, 345.3, 364.5, 383.7, 402.9, 422.1, 441.3, 460.5, 479.7, 498.9]
					},
					new()// 5th-Hit Level-1 Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [277.6, 302.9, 328.2, 353.5, 378.8, 404.1, 429.4, 454.7, 480.0, 505.3, 530.6, 555.9, 581.2, 606.5, 631.8, 657.1]
					},
					new()// 5th-Hit Level-2 Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [355.7, 388.1, 420.5, 452.9, 485.3, 517.7, 550.1, 582.5, 614.9, 647.3, 679.7, 712.1, 744.5, 776.9, 809.3, 841.7]
					}
				]
			},
			new()// Dash Attack: Keep it Clean
			{
				Id = "KeepitClean",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Scales = [47.3, 51.6, 55.9, 60.2, 64.5, 68.8, 73.1, 77.4, 81.7, 86.0, 90.3, 94.6, 98.9, 103.2, 107.5, 111.8]
					}
				]
			},
			new()// Dodge Counter: Etiquette Manual
			{
				Id = "EtiquetteManual",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Ice,
						Scales = [187, 204, 221, 238, 255, 272, 289, 306, 323, 340, 357, 374, 391, 408, 425, 442]
					}
				]
			},
			new()// Quick Assist: Wolf Pack
			{
				Id = "WolfPack",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Ice,
						Scales = [63.1, 68.9, 74.7, 80.5, 86.3, 92.1, 97.9, 103.7, 109.5, 115.3, 121.1, 126.9, 132.7, 138.5, 144.3, 150.1]
					}
				]
			},
			new()// Assist Follow-Up: Vengeful Counterattack
			{
				Id = "VengefulCounterattack",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Ice,
						Scales = [288.3, 314.6, 340.9, 367.2, 393.5, 419.8, 446.1, 472.4, 498.7, 525.0, 551.3, 577.6, 603.9, 630.2, 656.5, 682.8]
					}
				]
			},
			new()// Special Attack: Time to Hunt
			{
				Id = "TimetoHunt",
				Category = Special,
				Skills =
				[
					new()// Damage Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Scales = [77.1, 84.2, 91.3, 98.4, 105.5, 112.6, 119.7, 126.8, 133.9, 141.0, 148.1, 155.2, 162.3, 169.4, 176.5, 183.6]
					},
					new()// Charged Attack DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Scales = [133.1, 145.3, 157.5, 169.7, 181.9, 194.1, 206.3, 218.5, 230.7, 242.9, 255.1, 267.3, 279.5, 291.7, 303.9, 316.1]
					}
				]
			},
			new()// EX Special Attack: Thrill of the Hunt
			{
				Id = "ThrilloftheHunt",
				Category = Special,
				Skills =
				[
					new()// Damage Multiplier (%)
					{
						Type = Ex,
						DmgType = Ice,
						Scales = [534.3, 583, 631.7, 680.4, 729.1, 777.8, 826.5, 875.2, 923.9, 972.6, 1021.3, 1070.0, 1118.7, 1167.4, 1216.1, 1264.8]
					},
					new()// Charged Attack DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ice,
						Scales = [789.5, 861.4, 933.3, 1005.2, 1077.1, 1149, 1220.9, 1292.8, 1364.7, 1436.6, 1508.5, 1580.4, 1652.3, 1724.2, 1796.1, 1868.0]
					}
				]
			},
			new()// Chain Attack: As You Wish
			{
				Id = "AsYouWish",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ice,
						Scales = [637.8, 695.8, 753.8, 811.8, 869.8, 927.8, 985.8, 1043.8, 1101.8, 1159.8, 1217.8, 1275.8, 1333.8, 1391.8, 1449.8, 1507.8]
					}
				]
			},
			new()// Ultimate: Mission Complete
			{
				Id = "MissionComplete",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ice,
						Scales = [1694.1, 1848.2, 2002.3, 2156.4, 2310.5, 2464.6, 2618.7, 2772.8, 2926.9, 3081.0, 3235.1, 3389.2, 3543.3, 3697.4, 3851.5, 4005.6]
					}
				]
			}
		],
		Cinema =
		{
			[6] = new BuffInfo
			{
				// TODO: this need more check, i think this buff is a DmgTaken debuff of the enemy instead of a bonus dmg on lycaon.
				// in case of a DmgTaken debuff, need to be limited to only damage coming from lycaon.
				Type = Stack,
				Stacks = 5,
				Modifiers =new StatModifier
				{
					Stat = BonusDmg, Type = StatModifiers.Combat,
					Value = 10
				}
			}
		}
	};
}