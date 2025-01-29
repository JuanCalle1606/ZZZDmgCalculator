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

[InfoData<Agents>(Anby)]
public class AnbyData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Anby,
		Icon = "Anby_Demara",
		Attribute = Electric,
		Faction = Hares,
		Specialty = Stun,
		AttackType = Slash,
		DodgeType = Parry,
		Rank = AgentRank.A,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = Impact,
				Value = 6
			},
			new()
			{
				Stat = Atk,
				Value = 25
			}
		],
		BaseStats =
		[
			Templates["Lucy.Atk"],
			Templates["Anby.Hp"],
			Templates["Lucy.Def"],
		],
		FinalStats = [0, 118, 83, 94, 1.2],
		CoreBuff = new BuffInfo
		{
			Scales = [[32, 37.3, 42.6, 48, 53.3, 58.6, 64]],
			Modifiers = new StatModifier
			{
				Stat = Daze, Type = Combat
			}
		},
		Abilities =
		[
			new()// Basic Attack: Turbo Volt
			{
				Id = "TurboVolt",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [31.2, 34.1, 37.0, 39.9, 42.8, 45.7, 48.6, 51.5, 54.4, 57.3, 60.2, 63.1, 66.0, 68.9, 71.8, 74.7],
						Daze = [15.6, 16.4, 17.2, 18.0, 18.8, 19.6, 20.4, 21.2, 22.0, 22.8, 23.6, 24.4, 25.2, 26.0, 26.8, 27.6]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [33.7, 36.8, 39.9, 43.0, 46.1, 49.2, 52.3, 55.4, 58.5, 61.6, 64.7, 67.8, 70.9, 74.0, 77.1, 80.2],
						Daze = [28.7, 30.1, 31.5, 32.9, 34.3, 35.7, 37.1, 38.5, 39.9, 41.3, 42.7, 44.1, 45.5, 46.9, 48.3, 49.7]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [113.6, 124.0, 134.4, 144.8, 155.2, 165.6, 176.0, 186.4, 196.8, 207.2, 217.6, 228.0, 238.4, 248.8, 259.2, 269.6],
						Daze = [89.6, 93.7, 97.8, 101.9, 106.0, 110.1, 114.2, 118.3, 122.4, 126.5, 130.6, 134.7, 138.8, 142.9, 147.0, 151.1]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [239.1, 260.9, 282.7, 304.5, 326.3, 348.1, 369.9, 391.7, 413.5, 435.3, 457.1, 478.9, 500.7, 522.5, 544.3, 566.1],
						Daze = [187.5, 196.1, 204.7, 213.3, 221.9, 230.5, 239.1, 247.7, 256.3, 264.9, 273.5, 282.1, 290.7, 299.3, 307.9, 316.5]
					}
				]
			},
			new()// Basic Attack: Thunderbolt
			{
				Id = "Thunderbolt",
				Category = Basic,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [328.6, 358.5, 388.4, 418.3, 448.2, 478.1, 508.0, 537.9, 567.8, 597.7, 627.6, 657.5, 687.4, 717.3, 747.2, 777.1],
						Daze = [142.4, 207.4, 272.4, 337.4, 402.4, 467.4, 532.4, 597.4, 662.4, 727.4, 792.4, 857.4, 922.4, 987.4, 1052.4, 1117.4]
					}
				]
			},
			new()// Dash Attack: Taser Blast
			{
				Id = "TaserBlast",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [56.7, 61.9, 67.1, 72.3, 77.5, 82.7, 87.9, 93.1, 98.3, 103.5, 108.7, 113.9, 119.1, 124.3, 129.5, 134.7],
						Daze = [28.4, 29.7, 31.0, 32.3, 33.6, 34.9, 36.2, 37.5, 38.8, 40.1, 41.4, 42.7, 44.0, 45.3, 46.6, 47.9]
					}
				]
			},
			new()// Dodge Counter: Thunderclap
			{
				Id = "Thunderclap",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Electric,
						Dmg = [180.2, 196.6, 213, 229.4, 245.8, 262.2, 278.6, 295, 311.4, 327.8, 344.2, 360.6, 377, 393.4, 409.8, 426.2],
						Daze = [161.7, 169.1, 176.5, 183.9, 191.3, 198.7, 206.1, 213.5, 220.9, 228.3, 235.7, 243.1, 250.5, 257.9, 265.3, 272.7]
					}
				]
			},
			new()// Quick Assist: Thunderfall
			{
				Id = "Thunderfall",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Electric,
						Dmg = [61.7, 67.4, 73.1, 78.8, 84.5, 90.2, 95.9, 101.6, 107.3, 113, 118.7, 124.4, 130.1, 135.8, 141.5, 147.2],
						Daze = [61.7, 64.6, 67.5, 70.4, 73.3, 76.2, 79.1, 82, 84.9, 87.8, 90.7, 93.6, 96.5, 99.4, 102.3, 105.2]
					}
				]
			},
			new()// Defensive Assist: Flash
			{
				Id = "Flash",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [246.7, 258.0, 269.3, 280.6, 291.9, 303.2, 314.5, 325.8, 337.1, 348.4, 359.7, 371.0, 382.3, 393.6, 404.9, 416.2]
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
			new()// Assist Follow-Up: Lightning Whirl
			{
				Id = "LightningWhirl",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Electric,
						Dmg = [335.2, 365.7, 396.2, 426.7, 457.2, 487.7, 518.2, 548.7, 579.2, 609.7, 640.2, 670.7, 701.2, 731.7, 762.2, 792.7],
						Daze = [291.4, 304.7, 318, 331.3, 344.6, 357.9, 371.2, 384.5, 397.8, 411.1, 424.4, 437.7, 451, 464.3, 477.6, 490.9]
					}
				]
			},
			new()// Special Attack: Fork Lightning
			{
				Id = "ForkLightning",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Electric,
						Dmg = [93.4, 101.9, 110.4, 118.9, 127.4, 135.9, 144.4, 152.9, 161.4, 169.9, 178.4, 186.9, 195.4, 203.9, 212.4, 220.9],
						Daze = [93.4, 97.7, 102, 106.3, 110.6, 114.9, 119.2, 123.5, 127.8, 132.1, 136.4, 140.7, 145, 149.3, 153.6, 157.9]
					}
				]
			},
			new()// EX Special Attack: Lightning Bolt
			{
				Id = "LightningBolt",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Electric,
						Dmg = [583, 636, 689, 742, 795, 848, 901, 954, 1007, 1060, 1113, 1166, 1219, 1272, 1325, 1431],
						Daze = [481.8, 503.7, 525.6, 547.5, 569.4, 591.3, 613.2, 635.1, 657, 678.9, 700.8, 722.7, 744.6, 766.5, 788.4, 810.3]
					}
				]
			},
			new()// Chain Attack: Electro Engine
			{
				Id = "ElectroEngine",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Electric,
						Dmg = [542.4, 591.8, 641.2, 690.6, 740.0, 789.4, 838.8, 888.2, 937.6, 987.0, 1036.4, 1085.8, 1135.2, 1184.6, 1234.0, 1283.4],
						Daze = [143.4, 150.0, 156.6, 163.2, 169.8, 176.4, 183.0, 189.6, 196.2, 202.8, 209.4, 216.0, 222.6, 229.2, 235.8, 242.4]
					}
				]
			},
			new()// Ultimate: Overdrive Engine
			{
				Id = "OverdriveEngine",
				Category = Chain,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Electric,
						Dmg = [1512.6, 1649.2, 1785.8, 1922.4, 2059, 2195.6, 2332.2, 2468.8, 2605.4, 2742, 2878.6, 3015.2, 3151.8, 3288.4, 3425, 3561.6],
						Daze = [991.6, 1036.7, 1081.8, 1126.9, 1172, 1217.1, 1262.2, 1307.3, 1352.4, 1397.5, 1442.6, 1487.7, 1532.8, 1577.9, 1623, 1668.1]
					}
				]
			}
		],
		Cinemas =
		{
			[1] = new StatModifier { Stat = EnergyRegen, Value = 12, Type = CombatPercent },
			[2] = new()
			{
				Buffs =
				[
					new BuffInfo
					{
						Type = BuffTrigger.Switch,
						// anby's cinema 2 only applies to thunderbolt
						AbilityCondition = skill => skill.Id == "Basic.Thunderbolt",
						Modifiers = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 30 }
					},
					new BuffInfo
					{
						Type = BuffTrigger.Switch,
						SkillCondition = info => info.Type is Ex,
						Modifiers = new StatModifier { Stat = Daze, Type = Combat, Value = 10 }
					}
				]
			},
			[6] = new BuffInfo
			{
				Modifiers =
				[
					new() { Stat = BasicDmg, Type = Combat, Value = 45 },
					new() { Stat = DashDmg, Type = Combat, Value = 45 }
				]
			}
		}
	};
}