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

[InfoData<Agents>(Lycaon)]
public class LycaonData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Lycaon,
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
			Stat = IceRes, Value = 25, Enemy = true, Type = Combat
		},
		AdditionalBuff = new StatModifier
		{
			Stat = StunDmg, Value = 35, Enemy = true, Type = Combat
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
						Dmg = [29.2, 31.9, 34.6, 37.3, 40, 42.7, 45.4, 48.1, 50.8, 53.5, 56.2, 58.9, 61.6, 64.3, 67, 69.7],
						Daze = [14.6, 15.3, 16, 16.7, 17.4, 18.1, 18.8, 19.5, 20.2, 20.9, 21.6, 22.3, 23, 23.7, 24.4, 25.1]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Dmg = [34.9, 38.1, 41.3, 44.5, 47.7, 50.9, 54.1, 57.3, 60.5, 63.7, 66.9, 70.1, 73.3, 76.5, 79.7, 82.9],
						Daze = [30.3, 31.7, 33.1, 34.5, 35.9, 37.3, 38.7, 40.1, 41.5, 42.9, 44.3, 45.7, 47.1, 48.5, 49.9, 51.3]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Dmg = [58.4, 63.8, 69.2, 74.6, 80.0, 85.4, 90.8, 96.2, 101.6, 107.0, 112.4, 117.8, 123.2, 128.6, 134.0, 139.4],
						Daze = [45.6, 47.7, 49.8, 51.9, 54.0, 56.1, 58.2, 60.3, 62.4, 64.5, 66.6, 68.7, 70.8, 72.9, 75.0, 77.1]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Dmg = [152.0, 165.9, 179.8, 193.7, 207.6, 221.5, 235.4, 249.3, 263.2, 277.1, 291.0, 304.9, 318.8, 332.7, 346.6, 360.5],
						Daze = [112.0, 117.1, 122.2, 127.3, 132.4, 137.5, 142.6, 147.7, 152.8, 157.9, 163.0, 168.1, 173.2, 178.3, 183.4, 188.5]
					},
					new()// 5th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical ,
						Dmg = [180.7, 197.2, 213.7, 230.2, 246.7, 263.2, 279.7, 296.2, 312.7, 329.2, 345.7, 362.2, 378.7, 395.2, 411.7, 428.2],
						Daze = [147.7, 154.5, 161.3, 168.1, 174.9, 181.7, 188.5, 195.3, 202.1, 208.9, 215.7, 222.5, 229.3, 236.1, 242.9, 249.7]
					},
					new()// 1st-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [37.1, 40.5, 43.9, 47.3, 50.7, 54.1, 57.5, 60.9, 64.3, 67.7, 71.1, 74.5, 77.9, 81.3, 84.7, 88.1],
						Daze = [12.1, 12.7, 13.3, 13.9, 14.5, 15.1, 15.7, 16.3, 16.9, 17.5, 18.1, 18.7, 19.3, 19.9, 20.5, 21.1]
					},
					new()// 2nd-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [56.4, 61.6, 66.8, 72.0, 77.2, 82.4, 87.6, 92.8, 98.0, 103.2, 108.4, 113.6, 118.8, 124.0, 129.2, 134.4],
						Daze = [32.9, 34.4, 35.9, 37.4, 38.9, 40.4, 41.9, 43.4, 44.9, 46.4, 47.9, 49.4, 50.9, 52.4, 53.9, 55.4]
					},
					new()// 3rd-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [99.5, 108.6, 117.7, 126.8, 135.9, 145.0, 154.1, 163.2, 172.3, 181.4, 190.5, 199.6, 208.7, 217.8, 226.9, 236.0],
						Daze = [53.7, 56.2, 58.7, 61.2, 63.7, 66.2, 68.7, 71.2, 73.7, 76.2, 78.7, 81.2, 83.7, 86.2, 88.7, 91.2]
					},
					new()// 4th-Hit Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [210.9, 230.1, 249.3, 268.5, 287.7, 306.9, 326.1, 345.3, 364.5, 383.7, 402.9, 422.1, 441.3, 460.5, 479.7, 498.9],
						Daze = [107.1, 112.0, 116.9, 121.8, 126.7, 131.6, 136.5, 141.4, 146.3, 151.2, 156.1, 161.0, 165.9, 170.8, 175.7, 180.6]
					},
					new()// 5th-Hit Level-1 Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [277.6, 302.9, 328.2, 353.5, 378.8, 404.1, 429.4, 454.7, 480.0, 505.3, 530.6, 555.9, 581.2, 606.5, 631.8, 657.1],
						Daze = [163.1, 170.6, 178.1, 185.6, 193.1, 200.6, 208.1, 215.6, 223.1, 230.6, 238.1, 245.6, 253.1, 260.6, 268.1, 275.6]
					},
					new()// 5th-Hit Level-2 Charged Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ice,
						Dmg = [355.7, 388.1, 420.5, 452.9, 485.3, 517.7, 550.1, 582.5, 614.9, 647.3, 679.7, 712.1, 744.5, 776.9, 809.3, 841.7],
						Daze = [205.6, 215.0, 224.4, 233.8, 243.2, 252.6, 262.0, 271.4, 280.8, 290.2, 299.6, 309.0, 318.4, 327.8, 337.2, 346.6]
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
						Dmg = [47.3, 51.6, 55.9, 60.2, 64.5, 68.8, 73.1, 77.4, 81.7, 86.0, 90.3, 94.6, 98.9, 103.2, 107.5, 111.8],
						Daze = [23.7, 24.8, 25.9, 27.0, 28.1, 29.2, 30.3, 31.4, 32.5, 33.6, 34.7, 35.8, 36.9, 38.0, 39.1, 40.2]
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
						Dmg = [187, 204, 221, 238, 255, 272, 289, 306, 323, 340, 357, 374, 391, 408, 425, 442],
						Daze = [168.1, 175.8, 183.5, 191.2, 198.9, 206.6, 214.3, 222, 229.7, 237.4, 245.1, 252.8, 260.5, 268.2, 275.9, 283.6]
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
						Dmg = [63.1, 68.9, 74.7, 80.5, 86.3, 92.1, 97.9, 103.7, 109.5, 115.3, 121.1, 126.9, 132.7, 138.5, 144.3, 150.1],
						Daze = [63.1, 66, 68.9, 71.8, 74.7, 77.6, 80.5, 83.4, 86.3, 89.2, 92.1, 95.0, 97.9, 100.8, 103.7, 106.6]
					}
				]
			},
			new()// Defensive Assist: Disrupted Hunt
			{
				Id = "DisruptedHunt",
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
						Dmg = [288.3, 314.6, 340.9, 367.2, 393.5, 419.8, 446.1, 472.4, 498.7, 525.0, 551.3, 577.6, 603.9, 630.2, 656.5, 682.8],
						Daze = [246.8, 258.1, 269.4, 280.7, 292.0, 303.3, 314.6, 325.9, 337.2, 348.5, 359.8, 371.1, 382.4, 393.7, 405.0, 416.3]
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
						Dmg = [77.1, 84.2, 91.3, 98.4, 105.5, 112.6, 119.7, 126.8, 133.9, 141.0, 148.1, 155.2, 162.3, 169.4, 176.5, 183.6],
						Daze = [77.1, 80.7, 84.3, 87.9, 91.5, 95.1, 98.7, 102.3, 105.9, 109.5, 113.1, 116.7, 120.3, 123.9, 127.5, 131.1]
					},
					new()// Charged Attack DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ice,
						Dmg = [133.1, 145.3, 157.5, 169.7, 181.9, 194.1, 206.3, 218.5, 230.7, 242.9, 255.1, 267.3, 279.5, 291.7, 303.9, 316.1],
						Daze = [133.1, 139.3, 145.5, 151.7, 157.9, 164.1, 170.3, 176.5, 182.7, 188.9, 195.1, 201.3, 207.5, 213.7, 219.9, 226.1]
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
						Dmg = [534.3, 583, 631.7, 680.4, 729.1, 777.8, 826.5, 875.2, 923.9, 972.6, 1021.3, 1070.0, 1118.7, 1167.4, 1216.1, 1264.8],
						Daze = [450.4, 471, 491.6, 512.2, 532.8, 553.4, 574.0, 594.6, 615.2, 635.8, 656.4, 677.0, 697.6, 718.2, 738.8, 759.4]
					},
					new()// Charged Attack DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ice,
						Dmg = [789.5, 861.4, 933.3, 1005.2, 1077.1, 1149, 1220.9, 1292.8, 1364.7, 1436.6, 1508.5, 1580.4, 1652.3, 1724.2, 1796.1, 1868.0],
						Daze = [664.4, 694.7, 725.0, 755.3, 785.6, 815.9, 846.2, 876.5, 906.8, 937.1, 967.4, 997.7, 1028.0, 1058.3, 1088.6, 1118.9]
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
						Dmg = [637.8, 695.8, 753.8, 811.8, 869.8, 927.8, 985.8, 1043.8, 1101.8, 1159.8, 1217.8, 1275.8, 1333.8, 1391.8, 1449.8, 1507.8],
						Daze = [218.8, 228.8, 238.8, 248.8, 258.8, 268.8, 278.8, 288.8, 298.8, 308.8, 318.8, 328.8, 338.8, 348.8, 358.8, 368.8]
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
						Dmg = [1694.1, 1848.2, 2002.3, 2156.4, 2310.5, 2464.6, 2618.7, 2772.8, 2926.9, 3081.0, 3235.1, 3389.2, 3543.3, 3697.4, 3851.5, 4005.6],
						Daze = [1096.6, 1146.5, 1196.4, 1246.3, 1296.2, 1346.1, 1396, 1445.9, 1495.8, 1545.7, 1595.6, 1645.5, 1695.4, 1745.3, 1795.2, 1845.1]
					}
				]
			},
		],
		Cinemas =
		{
			// TODO: Cinema 1 buff
			[6] = new BuffInfo
			{
				// TODO: this need more check, i think this buff is a DmgTaken debuff of the enemy instead of a bonus dmg on lycaon.
				// in case of a DmgTaken debuff, need to be limited to only damage coming from lycaon.
				Type = Stack,
				Stacks = 5,
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat,
					Value = 10
				}
			}
		}
	};
}