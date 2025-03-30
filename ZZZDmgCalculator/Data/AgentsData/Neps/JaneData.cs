namespace ZZZDmgCalculator.Data.AgentsData.Neps;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static AgentScales;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.BuffTrigger;
using static Models.Enum.DodgeTypes;
using static Models.Enum.Factions;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Agents;
using static ZZZ.ApiModels.Skills;

[InfoData<Agents>(Jane)]
public class JaneData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Jane,
		Icon = "Jane_Doe",
		Attribute = Physical,
		Faction = Neps,
		Specialty = Specialties.Anomaly,
		AttackType = Slash,
		DodgeType = Parry,
		Rank = AgentRank.S,
		AdditionalCondition = SpecialtyAdditionalCondition(Specialties.Anomaly),
		CoreStats =
		[
			new()
			{
				Stat = Mastery, Value = 12
			},
			new()
			{
				Stat = Atk, Value = 25
			}
		],
		BaseStats =
		[
			Templates["Jane.Atk"],
			Templates["Jane.Hp"],
			Templates["Lycaon.Def"],
		],
		FinalStats = [0, 86, 150, 112, 1.2],
		CoreBuff =
		[
			new BuffInfo
			{
				Type = Permanent,
				Scales = [[20, 25, 28, 31, 34, 37, 40]],
				Modifiers =
				[
					new StatModifier
					{
						Stat = AssaultCritRate, Type = Base, Shared = true
					},
					new StatModifier
					{
						Stat = AssaultCritDmg, Type = Base, Shared = true, Value = 50
					}
				]
			},
			new BuffInfo
			{
				Scales = [[0.1, 0.11, 0.12, 0.13, 0.14, 0.15, 0.16]],
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = AssaultCritRate, Type = Combat, Agent = true,
					AgentStat = Proficiency, Shared = true
				},
			}
		],
		AdditionalBuff =
		[
			new BuffInfo
			{
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = BuildUp, Type = Combat, Value = 15
				}
			},
			new BuffInfo
			{
				Modifiers = new StatModifier
				{
					Stat = BuildUp, Type = Combat, Value = 15
				}
			}
		],
		Abilities =
		[
			new()// Basic Attack: Dancing Blades
			{
				Id = "DancingBlades",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [36.1, 39.4, 42.7, 46.0, 49.3, 52.6, 55.9, 59.2, 62.5, 65.8, 69.1, 72.4, 75.7, 79.0, 82.3, 85.6],
						Daze = [15.3, 16, 16.7, 17.4, 18.1, 18.8, 19.5, 20.2, 20.9, 21.6, 22.3, 23.0, 23.7, 24.4, 25.1, 25.8]
					},
					new()// 2nd-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [62.3, 68, 73.7, 79.4, 85.1, 90.8, 96.5, 102.2, 107.9, 113.6, 119.3, 125.0, 130.7, 136.4, 142.1, 147.8],
						Daze = [44.3, 46.4, 48.5, 50.6, 52.7, 54.8, 56.9, 59.0, 61.1, 63.2, 65.3, 67.4, 69.5, 71.6, 73.7, 75.8]
					},
					new()// 3rd-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [83.5, 91.1, 98.7, 106.3, 113.9, 121.5, 129.1, 136.7, 144.3, 151.9, 159.5, 167.1, 174.7, 182.3, 189.9, 197.5],
						Daze = [59.5, 62.3, 65.1, 67.9, 70.7, 73.5, 76.3, 79.1, 81.9, 84.7, 87.5, 90.3, 93.1, 95.9, 98.7, 101.5]
					},
					new()// 4th-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [163.4, 178.3, 193.2, 208.1, 223.0, 237.9, 252.8, 267.7, 282.6, 297.5, 312.4, 327.3, 342.2, 357.1, 372.0, 386.9],
						Daze = [109.7, 114.7, 119.7, 124.7, 129.7, 134.7, 139.7, 144.7, 149.7, 154.7, 159.7, 164.7, 169.7, 174.7, 179.7, 184.7]
					},
					new()// 5th-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [98.8, 107.8, 116.8, 125.8, 134.8, 143.8, 152.8, 161.8, 170.8, 179.8, 188.8, 197.8, 206.8, 215.8, 224.8, 233.8],
						Daze = [68.7, 71.9, 75.1, 78.3, 81.5, 84.7, 87.9, 91.1, 94.3, 97.5, 100.7, 103.9, 107.1, 110.3, 113.5, 116.7]
					},
					new()// 6th-Hit DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [291.3, 317.8, 344.3, 370.8, 397.3, 423.8, 450.3, 476.8, 503.3, 529.8, 556.3, 582.8, 609.3, 635.8, 662.3, 688.8],
						Daze = [200, 209.1, 218.2, 227.3, 236.4, 245.5, 254.6, 263.7, 272.8, 281.9, 291.0, 300.1, 309.2, 318.3, 327.4, 336.5]
					}
				]
			},
			new()// Basic Attack: Salchow Jump
			{
				Id = "SalchowJump",
				Category = Basic,
				Skills =
				[
					new()// Consecutive Attack DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [300.8, 328.2, 355.6, 383.0, 410.4, 437.8, 465.2, 492.6, 520.0, 547.4, 574.8, 602.2, 629.6, 657.0, 684.4, 711.8],
						Daze = [229.2, 239.7, 250.2, 260.7, 271.2, 281.7, 292.2, 302.7, 313.2, 323.7, 334.2, 344.7, 355.2, 365.7, 376.2, 386.7]
					},
					new()// Finishing Move DMG Multiplier
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [161.3, 176, 190.7, 205.4, 220.1, 234.8, 249.5, 264.2, 278.9, 293.6, 308.3, 323.0, 337.7, 352.4, 367.1, 381.8],
						Daze = [122.9, 128.5, 134.1, 139.7, 145.3, 150.9, 156.5, 162.1, 167.7, 173.3, 178.9, 184.5, 190.1, 195.7, 201.3, 206.9]
					}
				]
			},
			new()// Dash Attack: Edge Jump
			{
				Id = "EdgeJump",
				Category = Dodge,
				Skills =
				[
					new()// 1st-Dodge DMG Multiplier
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [71.5, 78, 84.5, 91, 97.5, 104, 110.5, 117, 123.5, 130, 136.5, 143, 149.5, 156, 162.5, 169],
						Daze = [35.8, 37.5, 39.2, 40.9, 42.6, 44.3, 46.0, 47.7, 49.4, 51.1, 52.8, 54.5, 56.2, 57.9, 59.6, 61.3]
					},
					new()// 2nd-Dodge DMG Multiplier
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [71.5, 78, 84.5, 91, 97.5, 104, 110.5, 117, 123.5, 130, 136.5, 143, 149.5, 156, 162.5, 169],
						Daze = [35.8, 37.5, 39.2, 40.9, 42.6, 44.3, 46.0, 47.7, 49.4, 51.1, 52.8, 54.5, 56.2, 57.9, 59.6, 61.3]
					}
				]
			},
			new()// Dash Attack: Phantom Thrust
			{
				Id = "PhantomThrust",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [104.5, 114, 123.5, 133, 142.5, 152, 161.5, 171, 180.5, 190, 199.5, 209, 218.5, 228, 237.5, 247],
						Daze = [52.3, 54.7, 57.1, 59.5, 61.9, 64.3, 66.7, 69.1, 71.5, 73.9, 76.3, 78.7, 81.1, 83.5, 85.9, 88.3]
					}
				]
			},
			new()// Dodge Counter: Swift Shadow
			{
				Id = "SwiftShadow",
				Category = Dodge,
				Skills =
				[
					new()// 1st-Dodge DMG Multiplier
					{
						Type = Dodge,
						DmgType = Physical,
						Dmg = [341.2, 372.3, 403.4, 434.5, 465.6, 496.7, 527.8, 558.9, 590.0, 621.1, 652.2, 683.3, 714.4, 745.5, 776.6, 807.7],
						Daze = [229.2, 239.7, 250.2, 260.7, 271.2, 281.7, 292.2, 302.7, 313.2, 323.7, 334.2, 344.7, 355.2, 365.7, 376.2, 386.7]
					},
					new()// 2nd-Dodge DMG Multiplier
					{
						Type = Dodge,
						DmgType = Physical,
						Dmg = [341.2, 372.3, 403.4, 434.5, 465.6, 496.7, 527.8, 558.9, 590.0, 621.1, 652.2, 683.3, 714.4, 745.5, 776.6, 807.7],
						Daze = [229.2, 239.7, 250.2, 260.7, 271.2, 281.7, 292.2, 302.7, 313.2, 323.7, 334.2, 344.7, 355.2, 365.7, 376.2, 386.7]
					}
				]
			},
			new()// Dodge Counter: Swift Shadow Dance
			{
				Id = "SwiftShadowDance",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Physical,
						Dmg = [387, 422.2, 457.4, 492.6, 527.8, 563, 598.2, 633.4, 668.6, 703.8, 739, 774.2, 809.4, 844.6, 879.8, 915],
						Daze = [247.5, 258.8, 270.1, 281.4, 292.7, 304, 315.3, 326.6, 337.9, 349.2, 360.5, 371.8, 383.1, 394.4, 405.7, 417]
					}
				]
			},
			new()// Quick Assist: Dark Thorn
			{
				Id = "DarkThorn",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Physical,
						Dmg = [119.2, 130.1, 141, 151.9, 162.8, 173.7, 184.6, 195.5, 206.4, 217.3, 228.2, 239.1, 250.0, 260.9, 271.8, 282.7],
						Daze = [119.2, 124.7, 130.2, 135.7, 141.2, 146.7, 152.2, 157.7, 163.2, 168.7, 174.2, 179.7, 185.2, 190.7, 196.2, 201.7]
					}
				]
			},
			new()// Quick Assist: Lutz Jump
			{
				Id = "LutzJump",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Physical,
						Dmg = [137.5, 150, 162.5, 175, 187.5, 200, 212.5, 225, 237.5, 250, 262.5, 275, 287.5, 300, 312.5, 325],
						Daze = [137.5, 143.8, 150.1, 156.4, 162.7, 169.0, 175.3, 181.6, 187.9, 194.2, 200.5, 206.8, 213.1, 219.4, 225.7, 232.0]
					}
				]
			},
			new()// Defensive Assist: Last Defense
			{
				Id = "LastDefense",
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
						Daze = [166.8, 174.4, 182, 189.6, 197.2, 204.8, 212.4, 220.0, 227.6, 235.2, 242.8, 250.4, 258.0, 265.6, 273.2, 280.8]
					}
				]
			},
			new()// Assist Follow-Up: Gale Sweep
			{
				Id = "GaleSweep",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Physical,
						Dmg = [345.5, 377, 408.5, 440, 471.5, 503, 534.5, 566, 597.5, 629, 660.5, 692, 723.5, 755, 786.5, 818],
						Daze = [299, 312.6, 326.2, 339.8, 353.4, 367.0, 380.6, 394.2, 407.8, 421.4, 435.0, 448.6, 462.2, 475.8, 489.4, 503.0]
					}
				]
			},
			new()// Special Attack: Aerial Sweep
			{
				Id = "AerialSweep",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Physical,
						Dmg = [57.8, 63.1, 68.4, 73.7, 79.0, 84.3, 89.6, 94.9, 100.2, 105.5, 110.8, 116.1, 121.4, 126.7, 132.0, 137.3],
						Daze = [57.8, 60.5, 63.2, 65.9, 68.6, 71.3, 74.0, 76.7, 79.4, 82.1, 84.8, 87.5, 90.2, 92.9, 95.6, 98.3]
					}
				]
			},
			new()// EX Special Attack: Aerial Sweep - Clearout
			{
				Id = "AerialSweepClearout",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [574.7, 627, 679.3, 731.6, 783.9, 836.2, 888.5, 940.8, 993.1, 1045.4, 1097.7, 1150.0, 1202.3, 1254.6, 1306.9, 1359.2],
						Daze = [468.1, 489.4, 510.7, 532, 553.3, 574.6, 595.9, 617.2, 638.5, 659.8, 681.1, 702.4, 723.7, 745.0, 766.3, 787.6]
					}
				]
			},
			new()// Chain Attack: Flowers of Sin
			{
				Id = "FlowersofSin",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Physical,
						Dmg = [632.6, 690.2, 747.8, 805.4, 863.0, 920.6, 978.2, 1035.8, 1093.4, 1151, 1208.6, 1266.2, 1323.8, 1381.4, 1439.0, 1496.6],
						Daze = [237.6, 248.4, 259.2, 270, 280.8, 291.6, 302.4, 313.2, 324.0, 334.8, 345.6, 356.4, 367.2, 378.0, 388.8, 399.6]
					}
				]
			},
			new()// Ultimate: Final Curtain
			{
				Id = "FinalCurtain",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Physical,
						Dmg = [1470.6, 1604.3, 1738, 1871.7, 2005.4, 2139.1, 2272.8, 2406.5, 2540.2, 2673.9, 2807.6, 2941.3, 3075.0, 3208.7, 3342.4, 3476.1],
						Daze = [186.5, 195, 203.5, 212, 220.5, 229, 237.5, 246, 254.5, 263, 271.5, 280, 288.5, 297, 305.5, 314]
					}
				]
			},
		],
		Cinemas =
		{
			[1] = new()
			{
				Buffs =
				[
					new BuffInfo
					{
						Modifiers = new StatModifier
						{
							Stat = AssaultBuildUp, Type = Combat, Value = 15
						}
					},// TODO: make this both buffs enable with a passion state switch
					new BuffInfo
					{
						Type = Permanent,
						Depends = 0,
						BuffLimit = 30,
						Modifiers = new StatModifier
						{
							Stat = BonusDmg, Type = Combat, Value = 0.1, Agent = true,
							AgentStat = Proficiency
						}
					}
				]
			},
			[2] = new()
			{
				Buffs =
				[
					new BuffInfo
					{
						SkillCondition = skill => skill.Id.Contains(nameof(Jane)) || (skill.Type is Skills.Anomaly && skill.DmgType is Physical),
						Modifiers = new StatModifier
						{
							Stat = Def, Type = CombatPercent, Value = -15, Enemy = true, Shared = true// todo: change with def ignore
							// todo: check if this mod is working as expected
						}
					},
					new BuffInfo
					{
						Type = Permanent,
						Modifiers = new StatModifier
						{
							Stat = AssaultCritDmg, Type = Combat, Value = 50
						}
					},
				]
			},
			[4] = new StatModifier
			{
				Stat = AnomalyDmg, Type = Combat, Value = 18
			},
			[6] = new()
			{
				Buffs = new BuffInfo
				{
					// todo: enable with passion state switch
					Modifiers =
					[
						new StatModifier
						{
							Stat = CritRate, Type = Combat, Value = 20
						},
						new StatModifier
						{
							Stat = CritDmg, Type = Combat, Value = 40
						}
					]
				},
				Skills = new SkillInfo
				{
					Stat = Proficiency,
					Value = 1600,
					DmgType = Physical,
					Cinema = true
				}
			}
		}
	};
}