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

[InfoData<Agents>(Soukaku)]
public class SoukakuData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Soukaku,
		Icon = "Soukaku",
		Attribute = Ice,
		Faction = Section6,
		Specialty = Support,
		AttackType = Slash,
		DodgeType = Parry,
		Rank = AgentRank.A,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = EnergyRegen,
				Value = 0.12
			},
			new()
			{
				Stat = Atk,
				Value = 25
			}
		],
		BaseStats =
		[
			Templates["Soukaku.Atk"],
			Templates["Lucy.Hp"],
			Templates["Soukaku.Def"],
		],
		FinalStats = [0, 86, 96, 93, 1.2],
		CoreBuff =
		[
			new()
			{
				Scales = [[10, 12.5, 15, 17, 18, 19, 20]],
				Pass = true,
				Modifiers = new StatModifier() { Stat = Atk, Type = BasePercent, Agent = true },
				BuffLimit = 500
			},
			new()// when Fly the Flag is active
			{
				Scales = [[10, 12.5, 15, 17, 18, 19, 20]],
				Pass = true,
				Depends = 0,
				Modifiers = new StatModifier() { Stat = Atk, Type = BasePercent, Agent = true },
				BuffLimit = 500
			},
		],
		AdditionalBuff = new StatModifier
		{
			Stat = IceDmg, Type = Combat, Shared = true, Value = 20
		},
		Abilities =
		[
			new()// Basic Attack: Making Rice Cakes
			{
				Id = "MakingRiceCakes",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [66.2, 72.3, 78.4, 84.5, 90.6, 96.7, 102.8, 108.9, 115, 121.1, 127.2, 133.3, 139.4, 145.5, 151.6, 157.7],
						Daze = [33.1, 34.7, 36.3, 37.9, 39.5, 41.1, 42.7, 44.3, 45.9, 47.5, 49.1, 50.7, 52.3, 53.9, 55.5, 57.1]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [216.3, 236.2, 256.1, 276, 295.9, 315.8, 335.7, 355.6, 375.5, 395.4, 415.3, 435.2, 455.1, 475, 494.9, 514.8],
						Daze = [188, 196.6, 205.2, 213.8, 222.4, 231, 239.6, 248.2, 256.8, 265.4, 274, 282.6, 291.2, 299.8, 308.4, 317]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [293.1, 319.8, 346.5, 373.2, 399.9, 426.6, 453.3, 480, 506.7, 533.4, 560.1, 586.8, 613.5, 640.2, 666.9, 693.6],
						Daze = [221.7, 231.8, 241.9, 252, 262.1, 272.2, 282.3, 292.4, 302.5, 312.6, 322.7, 332.8, 342.9, 353, 363.1, 373.2]
					}
				]
			},
			new()// Basic Attack: Making Rice Cakes (Frosted Banner)
			{
				Id = "MakingRiceCakesFrostedBanner",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [76.6, 83.6, 90.6, 97.6, 104.6, 111.6, 118.6, 125.6, 132.6, 139.6, 146.6, 153.6, 160.6, 167.6, 174.6, 181.6],
						Daze = [46.6, 48.8, 51, 53.2, 55.4, 57.6, 59.8, 62, 64.2, 66.4, 68.6, 70.8, 73, 75.2, 77.4, 79.6]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [228.5, 249.3, 270.1, 290.9, 311.7, 332.5, 353.3, 374.1, 394.9, 415.7, 436.5, 457.3, 478.1, 498.9, 519.7, 540.5],
						Daze = [127.5, 133.3, 139.1, 144.9, 150.7, 156.5, 162.3, 168.1, 173.9, 179.7, 185.5, 191.3, 197.1, 202.9, 208.7, 214.5]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [511.4, 557.9, 604.4, 650.9, 697.4, 743.9, 790.4, 836.9, 883.4, 929.9, 976.4, 1022.9, 1069.4, 1115.9, 1162.4, 1208.9],
						Daze = [263.3, 275.3, 287.3, 299.3, 311.3, 323.3, 335.3, 347.3, 359.3, 371.3, 383.3, 395.3, 407.3, 419.3, 431.3, 443.3]
					}
				]
			},
			new()// Dash Attack: 50/50
			{
				Id = "50_50",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [76.7, 83.7, 90.7, 97.7, 104.7, 111.7, 118.7, 125.7, 132.7, 139.7, 146.7, 153.7, 160.7, 167.7, 174.7, 181.7],
						Daze = [38.4, 40.2, 42, 43.8, 45.6, 47.4, 49.2, 51, 52.8, 54.6, 56.4, 58.2, 60, 61.8, 63.6, 65.4]
					}
				]
			},
			new()// Dash Attack: 50/50 (Frosted Banner)
			{
				Id = "50_50FrostedBanner",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Ice,
						Dmg = [131.5, 143.5, 155.5, 167.5, 179.5, 191.5, 203.5, 215.5, 227.5, 239.5, 251.5, 263.5, 275.5, 287.5, 299.5, 311.5],
						Daze = [80.1, 83.8, 87.5, 91.2, 94.9, 98.6, 102.3, 106, 109.7, 113.4, 117.1, 120.8, 124.5, 128.2, 131.9, 135.6]
					}
				]
			},
			new()// Dodge Counter: Away From My Snacks
			{
				Id = "AwayFromMySnacks",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Ice,
						Dmg = [247.3, 269.8, 292.3, 314.8, 337.3, 359.8, 382.3, 404.8, 427.3, 449.8, 472.3, 494.8, 517.3, 539.8, 562.3, 584.8],
						Daze = [213.4, 223.1, 232.8, 242.5, 252.2, 261.9, 271.6, 281.3, 291, 300.7, 310.4, 320.1, 329.8, 339.5, 349.2, 358.9]
					}
				]
			},
			new()// Quick Assist: A Set for Two
			{
				Id = "ASetforTwo",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Ice,
						Dmg = [113.4, 123.8, 134.2, 144.6, 155, 165.4, 175.8, 186.2, 196.6, 207, 217.4, 227.8, 238.2, 248.6, 259, 269.4],
						Daze = [113.4, 117.6, 121.8, 126, 130.2, 134.4, 138.6, 142.8, 147, 151.2, 155.4, 159.6, 163.8, 168, 172.2, 176.4]
					}
				]
			},
			new()// Defensive Assist: Guarding Tactics
			{
				Id = "GuardingTactics",
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
			new()// Assist Follow-Up: Sweeping Strike
			{
				Id = "SweepingStrike",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Ice,
						Dmg = [264, 288, 312, 336, 360, 384, 408, 432, 456, 480, 504, 528, 552, 576, 600, 624],
						Daze = [231.3, 241.9, 252.5, 263.1, 273.7, 284.3, 294.9, 305.5, 316.1, 326.7, 337.3, 347.9, 358.5, 369.1, 379.7, 390.3]
					}
				]
			},
			new()// Special Attack: Cooling Bento
			{
				Id = "CoolingBento",
				Category = Special,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Dmg = [28.4, 31, 33.6, 36.2, 38.8, 41.4, 44, 46.6, 49.2, 51.8, 54.4, 57, 59.6, 62.2, 64.8, 67.4],
						Daze = [28.4, 29.7, 31, 32.3, 33.6, 34.9, 36.2, 37.5, 38.8, 40.1, 41.4, 42.7, 44, 45.3, 46.6, 47.9]
					},
					new()// Finishing Move DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Dmg = [100.1, 109.2, 118.3, 127.4, 136.5, 145.6, 154.7, 163.8, 172.9, 182, 191.1, 200.2, 209.3, 218.4, 227.5, 236.6],
						Daze = [100.1, 104.7, 109.3, 113.9, 118.5, 123.1, 127.7, 132.3, 136.9, 141.5, 146.1, 150.7, 155.3, 159.9, 164.5, 169.1]
					}
				]
			},
			new()// EX Special Attack: Fanning Mosquitoes
			{
				Id = "FanningMosquitoes",
				Category = Special,
				Skills =
				[
					new()// Chain Attack DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ice,
						Dmg = [131.2, 151.1, 171, 190.9, 210.8, 230.7, 250.6, 270.5, 290.4, 310.3, 330.2, 350.1, 370, 389.9, 409.8, 429.7],
						Daze = [112.9, 118, 123.1, 128.2, 133.3, 138.4, 143.5, 148.6, 153.7, 158.8, 163.9, 169, 174.1, 179.2, 184.3, 189.4]
					},
					new()// Wind Current DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ice,
						Dmg = [102.1, 111.4, 120.7, 130, 139.3, 148.6, 157.9, 167.2, 176.5, 185.8, 195.1, 204.4, 213.7, 223, 232.3, 241.6],
						Daze = [87.9, 90.9, 93.9, 96.9, 99.9, 102.9, 105.9, 108.9, 111.9, 114.9, 117.9, 120.9, 123.9, 126.9, 129.9, 132.9]
					}
				]
			},
			new()// Special Attack: Rally!
			{
				Id = "Rally",
				Category = Special,
				Skills =
				[
					new()// Fly the Flag DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Dmg = [250.1, 272.9, 295.7, 318.5, 341.3, 364.1, 386.9, 409.7, 432.5, 455.3, 478.1, 500.9, 523.7, 546.5, 569.3, 592.1],
						Daze = [275.1, 287.7, 300.3, 312.9, 325.5, 338.1, 350.7, 363.3, 375.9, 388.5, 401.1, 413.7, 426.3, 438.9, 451.5, 464.1]
					},
					new()// Quick Fly the Flag DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Dmg = [140.1, 152.9, 165.7, 178.5, 191.3, 204.1, 216.9, 229.7, 242.5, 255.3, 268.1, 280.9, 293.7, 306.5, 319.3, 332.1],
						Daze = [140.1, 146.5, 152.9, 159.3, 165.7, 172.1, 178.5, 184.9, 191.3, 197.7, 204.1, 210.5, 216.9, 223.3, 229.7, 236.1]
					},
					new()// Lowering the Flag DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Dmg = [245, 267.3, 289.6, 311.9, 334.2, 356.5, 378.8, 401.1, 423.4, 445.7, 468, 490.3, 512.6, 534.9, 557.2, 579.5],
						Daze = [245, 256.2, 267.4, 278.6, 289.8, 301, 312.2, 323.4, 334.6, 345.8, 357, 368.2, 379.4, 390.6, 401.8, 413]
					}
				]
			},
			new()// Chain Attack: Pudding Slash
			{
				Id = "PuddingSlash",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ice,
						Dmg = [748.8, 816.5, 884.2, 951.9, 1019.6, 1087.3, 1155, 1222.7, 1290.4, 1358.1, 1425.8, 1493.5, 1561.2, 1628.9, 1696.6, 1764.3],
						Daze = [346.8, 362.6, 378.4, 394.2, 410, 425.8, 441.6, 457.4, 473.2, 489, 504.8, 520.6, 536.4, 552.2, 568, 583.8]
					}
				]
			},
			new()// Ultimate: Jumbo Pudding Slash
			{
				Id = "JumboPuddingSlash",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ice,
						Dmg = [1989.8, 2170.7, 2351.6, 2532.5, 2713.4, 2894.3, 3075.2, 3256.1, 3437, 3617.9, 3798.8, 3979.7, 4160.6, 4341.5, 4522.4, 4703.3],
						Daze = [376.8, 394, 411.2, 428.4, 445.6, 462.8, 480, 497.2, 514.4, 531.6, 548.8, 566, 583.2, 600.4, 617.6, 634.8]
					}
				]
			}
		],
		Cinemas =
		{
			[4] = new StatModifier { Stat = IceRes, Value = 10, Enemy = true, Type = Combat },
			[6] = new BuffInfo
			{
				AbilityCondition = skill=> skill.Id is "MakingRiceCakesFrostedBanner" or "50_50FrostedBanner",
				Modifiers =  new StatModifier { Stat = BonusDmg, Type = Combat, Value = 45 }
			}
		}
	};
}