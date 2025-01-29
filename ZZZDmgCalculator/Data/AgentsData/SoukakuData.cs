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
			new()
			{
				Category = Basic,
				Skills =
				[
					new()
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [66.2, 72.3, 78.4, 84.5, 90.6, 96.7, 102.8, 108.9, 115, 121.1, 127.2, 133.3, 139.4, 145.5, 151.6, 157.7]
					},
					new()
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [216.3, 236.2, 256.1, 276, 295.9, 315.8, 335.7, 355.6, 375.5, 395.4, 415.3, 435.2, 455.1, 475, 494.9, 514.8]
					},
					new()
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [293.1, 319.8, 346.5, 373.2, 399.9, 426.6, 453.3, 480, 506.7, 533.4, 560.1, 586.8, 613.5, 640.2, 666.9, 693.6]
					},
				]
			},
			new()
			{
				Category = Basic,
				Skills =
				[
					new()
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [76.6, 83.6, 90.6, 97.6, 104.6, 111.6, 118.6, 125.6, 132.6, 139.6, 146.6, 153.6, 160.6, 167.6, 174.6, 181.6]
					},
					new()
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [228.5, 249.3, 270.1, 290.9, 311.7, 332.5, 353.3, 374.1, 394.9, 415.7, 436.5, 457.3, 478.1, 498.9, 519.7, 540.5]
					},
					new()
					{
						Type = Basic,
						DmgType = Ice,
						Scales = [511.4, 557.9, 604.4, 650.9, 697.4, 743.9, 790.4, 836.9, 883.4, 929.9, 976.4, 1022.9, 1069.4, 1115.9, 1162.4, 1208.9]
					},
				]
			},
			new()
			{
				Category = Dodge,
				Skills =
				[
					new()
					{
						Type = Dash,
						DmgType = Physical,
						Scales = [76.7, 83.7, 90.7, 97.7, 104.7, 111.7, 118.7, 125.7, 132.7, 139.7, 146.7, 153.7, 160.7, 167.7, 174.7, 181.7]
					}
				]
			},
			new()
			{
				Category = Dodge,
				Skills =
				[
					new()
					{
						Type = Dash,
						DmgType = Ice,
						Scales = [131.5, 143.5, 155.5, 167.5, 179.5, 191.5, 203.5, 215.5, 227.5, 239.5, 251.5, 263.5, 275.5, 287.5, 299.5, 311.5]
					}
				]
			},
			new()
			{
				Category = Dodge,
				Skills =
				[
					new()
					{
						Type = Dodge,
						DmgType = Ice,
						Scales = [247.3, 269.8, 292.3, 314.8, 337.3, 359.8, 382.3, 404.8, 427.3, 449.8, 472.3, 494.8, 517.3, 539.8, 562.3, 584.8]
					}
				]
			},
			new()
			{
				Category = Assist,
				Skills =
				[
					new()
					{
						Type = Assist,
						DmgType = Ice,
						Scales = [113.4, 123.8, 134.2, 144.6, 155, 165.4, 175.8, 186.2, 196.6, 207, 217.4, 227.8, 238.2, 248.6, 259, 269.4]
					}
				]
			},
			new()
			{
				Category = Assist,
				Skills =
				[
					new()
					{
						Type = Assist,
						DmgType = Ice,
						Scales = [264, 288, 312, 336, 360, 384, 408, 432, 456, 480, 504, 528, 552, 576, 600, 624]
					}
				]
			},
			new()
			{
				Category = Special,
				Skills =
				[
					new()
					{
						Type = Special,
						DmgType = Ice,
						Scales = [28.4, 31, 33.6, 36.2, 38.8, 41.4, 44, 46.6, 49.2, 51.8, 54.4, 57, 59.6, 62.2, 64.8, 67.4]
					},
					new()
					{
						Type = Special,
						DmgType = Ice,
						Scales = [100.1, 109.2, 118.3, 127.4, 136.5, 145.6, 154.7, 163.8, 172.9, 182, 191.1, 200.2, 209.3, 218.4, 227.5, 236.6]
					}
				]
			},
			new()
			{
				Category = Special,
				Skills =
				[
					new()
					{
						Type = Ex,
						DmgType = Ice,
						Scales = [131.2, 151.1, 171, 190.9, 210.8, 230.7, 250.6, 270.5, 290.4, 310.3, 330.2, 350.1, 370, 389.9, 409.8, 429.7]
					},
					new()
					{
						Type = Ex,
						DmgType = Ice,
						Scales = [102.1, 111.4, 120.7, 130, 139.3, 148.6, 157.9, 167.2, 176.5, 185.8, 195.1, 204.4, 213.7, 223, 232.3, 241.6]
					}
				]
			},
			new()
			{
				Category = Special,
				Skills =
				[
					new()
					{
						Type = Ex,
						DmgType = Ice,
						Scales = [250.1, 272.9, 295.7, 318.5, 341.3, 364.1, 386.9, 409.7, 432.5, 455.3, 478.1, 500.9, 523.7, 546.5, 569.3, 592.1]
					},
					new()
					{
						Type = Ex,
						DmgType = Ice,
						Scales = [140.1, 152.9, 165.7, 178.5, 191.3, 204.1, 216.9, 229.7, 242.5, 255.3, 268.1, 280.9, 293.7, 306.5, 319.3, 332.1]
					},
					new()
					{
						Type = Ex,
						DmgType = Ice,
						Scales = [245, 267.3, 289.6, 311.9, 334.2, 356.5, 378.8, 401.1, 423.4, 445.7, 468, 490.3, 512.6, 534.9, 557.2, 579.5]
					}
				]
			},
			new()
			{
				Category = Ultimate,
				Skills =
				[
					new()
					{
						Type = Chain,
						DmgType = Ice,
						Scales = [748.8, 816.5, 884.2, 951.9, 1019.6, 1087.3, 1155, 1222.7, 1290.4, 1358.1, 1425.8, 1493.5, 1561.2, 1628.9, 1696.6, 1764.3]
					}
				]
			},
			new()
			{
				Category = Ultimate,
				Skills =
				[
					new()
					{
						Type = Ultimate,
						DmgType = Ice,
						Scales = [1989.8, 2170.7, 2351.6, 2532.5, 2713.4, 2894.3, 3075.2, 3256.1, 3437, 3617.9, 3798.8, 3979.7, 4160.6, 4341.5, 4522.4, 4703.3]
					}
				]
			}
		],
		Cinemas =
		{	
			[4] = new StatModifier { Stat = IceRes, Value = 10, Enemy = true},	
			[6] = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 45 } // TODO: change to only enchanced attack
		}
	};
}