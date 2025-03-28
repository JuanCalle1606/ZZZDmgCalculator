namespace ZZZDmgCalculator.Data.AgentsData;

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

[InfoData<Agents>(Anton)]
public class AntonData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Anton,
		Icon = "Anton_Ivanov",
		Attribute = Electric,
		Faction = Belobog,
		Specialty = Attack,
		AttackType = Pierce,
		DodgeType = Parry,
		Rank = AgentRank.A,
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
			Templates["Anton.Atk"],
			Templates["Anton.Hp"],
			Templates["Nicole.Def"],
		],
		FinalStats = [0, 95, 90, 86, 1.2],
		CoreBuff = new BuffInfo
		{
			// todo
		},
		AdditionalBuff = new BuffInfo
		{
			// todo
		},
		Abilities =
		[ // TODO: look for physical damage
			new()// Basic Attack: Enthusiastic Drills
			{
				Id = "EnthusiasticDrills",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [67.8, 74, 80.2, 86.4, 92.6, 98.8, 105.0, 111.2, 117.4, 123.6, 129.8, 136, 142.2, 148.4, 154.6, 160.8],
						Daze = [33.9, 35.5, 37.1, 38.7, 40.3, 41.9, 43.5, 45.1, 46.7, 48.3, 49.9, 51.5, 53.1, 54.7, 56.3, 57.9]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [92.3, 100.7, 109.1, 117.5, 125.9, 134.3, 142.7, 151.1, 159.5, 167.9, 176.3, 184.7, 193.1, 201.5, 209.9, 218.3],
						Daze = [75.3, 78.8, 82.3, 85.8, 89.3, 92.8, 96.3, 99.8, 103.3, 106.8, 110.3, 113.8, 117.3, 120.8, 124.3, 127.8]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [109.8, 119.8, 129.8, 139.8, 149.8, 159.8, 169.8, 179.8, 189.8, 199.8, 209.8, 219.8, 229.8, 239.8, 249.8, 259.8],
						Daze = [93.3, 97.6, 101.9, 106.2, 110.5, 114.8, 119.1, 123.4, 127.7, 132.0, 136.3, 140.6, 144.9, 149.2, 153.5, 157.8]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [229.1, 250, 270.9, 291.8, 312.7, 333.6, 354.5, 375.4, 396.3, 417.2, 438.1, 459.0, 479.9, 500.8, 521.7, 542.6],
						Daze = [181.4, 189.7, 198.0, 206.3, 214.6, 222.9, 231.2, 239.5, 247.8, 256.1, 264.4, 272.7, 281.0, 289.3, 297.6, 305.9]
					}
				]
			},
			new()// Basic Attack: Enthusiastic Drills (Burst Mode)
			{
				Id = "EnthusiasticDrillsBurstMode",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [240.9, 262.8, 284.7, 306.6, 328.5, 350.4, 372.3, 394.2, 416.1, 438.0, 459.9, 481.8, 503.7, 525.6, 547.5, 569.4],
						Daze = [166, 173.6, 181.2, 188.8, 196.4, 204.0, 211.6, 219.2, 226.8, 234.4, 242.0, 249.6, 257.2, 264.8, 272.4, 280]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [469.2, 511.9, 554.6, 597.3, 640.0, 682.7, 725.4, 768.1, 810.8, 853.5, 896.2, 938.9, 981.6, 1024.3, 1067.0, 1109.7],
						Daze = [323.3, 338, 352.7, 367.4, 382.1, 396.8, 411.5, 426.2, 440.9, 455.6, 470.3, 485.0, 499.7, 514.4, 529.1, 543.8]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [456.9, 498.5, 540.1, 581.7, 623.3, 664.9, 706.5, 748.1, 789.7, 831.3, 872.9, 914.5, 956.1, 997.7, 1039.3, 1080.9],
						Daze = [314.8, 329.2, 343.6, 358.0, 372.4, 386.8, 401.2, 415.6, 430.0, 444.4, 458.8, 473.2, 487.6, 502.0, 516.4, 530.8]
					}
				]
			},
			new()// Dash Attack: Fire With Fire
			{
				Id = "FireWithFire",
				Category = Dodge,
				Skills =
				[
					new()// Maximum DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Electric,
						Dmg = [68.4, 74.7, 81, 87.3, 93.6, 99.9, 106.2, 112.5, 118.8, 125.1, 131.4, 137.7, 144, 150.3, 156.6, 162.9],
						Daze = [34.2, 35.8, 37.4, 39.0, 40.6, 42.2, 43.8, 45.4, 47.0, 48.6, 50.2, 51.8, 53.4, 55.0, 56.6, 58.2]
					}
				]
			},
			new()// Dodge Counter: Retaliation
			{
				Id = "Retaliation",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Electric,
						Dmg = [271.2, 295.9, 320.6, 345.3, 370.0, 394.7, 419.4, 444.1, 468.8, 493.5, 518.2, 542.9, 567.6, 592.3, 617.0, 641.7],
						Daze = [231.7, 242.3, 252.9, 263.5, 274.1, 284.7, 295.3, 305.9, 316.5, 327.1, 337.7, 348.3, 358.9, 369.5, 380.1, 390.7]
					}
				]
			},
			new()// Dodge Counter: Overload Drill (Burst Mode)
			{
				Id = "OverloadDrillBurstMode",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Electric,
						Dmg = [465.4, 507.8, 550.2, 592.6, 635.0, 677.4, 719.8, 762.2, 804.6, 847.0, 889.4, 931.8, 974.2, 1016.6, 1059.0, 1101.4],
						Daze = [351.8, 367.8, 383.8, 399.8, 415.8, 431.8, 447.8, 463.8, 479.8, 495.8, 511.8, 527.8, 543.8, 559.8, 575.8, 591.8]
					}
				]
			},
			new()// Quick Assist: Shoulder-To-Shoulder
			{
				Id = "ShoulderToShoulder",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Electric,
						Dmg = [263.4, 287.4, 311.4, 335.4, 359.4, 383.4, 407.4, 431.4, 455.4, 479.4, 503.4, 527.4, 551.4, 575.4, 599.4, 623.4],
						Daze = [131.7, 137.7, 143.7, 149.7, 155.7, 161.7, 167.7, 173.7, 179.7, 185.7, 191.7, 197.7, 203.7, 209.7, 215.7, 221.7]
					}
				]
			},
			new()// Quick Assist: Protective Drill (Burst Mode)
			{
				Id = "ProtectiveDrillBurstMode",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Electric,
						Dmg = [365.4, 398.7, 432, 465.3, 498.6, 531.9, 565.2, 598.5, 631.8, 665.1, 698.4, 731.7, 765.0, 798.3, 831.6, 864.9],
						Daze = [251.8, 263.3, 274.8, 286.3, 297.8, 309.3, 320.8, 332.3, 343.8, 355.3, 366.8, 378.3, 389.8, 401.3, 412.8, 424.3]
					}
				]
			},
			new()// Defensive Assist: Iron Wrist
			{
				Id = "IronWrist",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [246.7, 258, 269.3, 280.6, 291.9, 303.2, 314.5, 325.8, 337.1, 348.4, 359.7, 371.0, 382.3, 393.6, 404.9, 416.2]
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
			new()// Assist Follow-Up: Limit Burst
			{
				Id = "LimitBurst",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Electric,
						Dmg = [325.8, 355.5, 385.2, 414.9, 444.6, 474.3, 504.0, 533.7, 563.4, 593.1, 622.8, 652.5, 682.2, 711.9, 741.6, 771.3],
						Daze = [282.7, 295.6, 308.5, 321.4, 334.3, 347.2, 360.1, 373.0, 385.9, 398.8, 411.7, 424.6, 437.5, 450.4, 463.3, 476.2]
					}
				]
			},
			new()// Special Attack: Spin, Bro!
			{
				Id = "SpinBro",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Electric,
						Dmg = [44.2, 48.3, 52.4, 56.5, 60.6, 64.7, 68.8, 72.9, 77.0, 81.1, 85.2, 89.3, 93.4, 97.5, 101.6, 105.7],
						Daze = [44.2, 46.3, 48.4, 50.5, 52.6, 54.7, 56.8, 58.9, 61.0, 63.1, 65.2, 67.3, 69.4, 71.5, 73.6, 75.7]
					}
				]
			},
			new()// Special Attack: Explosive Drill (Burst Mode)
			{
				Id = "ExplosiveDrillBurstMode",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Electric,
						Dmg = [231.4, 252.5, 273.6, 294.7, 315.8, 336.9, 358.0, 379.1, 400.2, 421.3, 442.4, 463.5, 484.6, 505.7, 526.8, 547.9],
						Daze = [118.4, 123.8, 129.2, 134.6, 140.0, 145.4, 150.8, 156.2, 161.6, 167.0, 172.4, 177.8, 183.2, 188.6, 194.0, 199.4]
					}
				]
			},
			new()// EX Special Attack: Smash the Horizon, Bro!
			{
				Id = "SmashtheHorizonBro",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Electric,
						Dmg = [195.1, 212.9, 230.7, 248.5, 266.3, 284.1, 301.9, 319.7, 337.5, 355.3, 373.1, 390.9, 408.7, 426.5, 444.3, 462.1],
						Daze = [195.1, 204, 212.9, 221.8, 230.7, 239.6, 248.5, 257.4, 266.3, 275.2, 284.1, 293.0, 301.9, 310.8, 319.7, 328.6]
					}
				]
			},
			new()// Chain Attack: Go Go Go!
			{
				Id = "GoGoGo",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Electric,
						Dmg = [640.7, 699, 757.3, 815.6, 873.9, 932.2, 990.5, 1048.8, 1107.1, 1165.4, 1223.7, 1282.0, 1340.3, 1398.6, 1456.9, 1515.2],
						Daze = [241.7, 252.7, 263.7, 274.7, 285.7, 296.7, 307.7, 318.7, 329.7, 340.7, 351.7, 362.7, 373.7, 384.7, 395.7, 406.7]
					}
				]
			},
			new()// Ultimate: Go Go Go Go Go!
			{
				Id = "GoGoGoGoGo",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Electric,
						Dmg = [1816.4, 1981.6, 2146.8, 2312, 2477.2, 2642.4, 2807.6, 2972.8, 3138.0, 3303.2, 3468.4, 3633.6, 3798.8, 3964.0, 4129.2, 4294.4],
						Daze = [243.4, 254.5, 265.6, 276.7, 287.8, 298.9, 310.0, 321.1, 332.2, 343.3, 354.4, 365.5, 376.6, 387.7, 398.8, 409.9]
					}
				]
			},
		],
		Cinemas =
		{
			// todo: implement shield calculation of m2
			[4] = new BuffInfo
			{
				Modifiers = new StatModifier
				{
					Stat = CritRate, Type = Combat, Value = 10, Shared = true
				}
			},
			[6] = new BuffInfo
			{
				Type = Stack,
				Stacks = 6,
				AbilityCondition = skill => skill.Id is "EnthusiasticDrillsBurstMode" or "OverloadDrillBurstMode",
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat, Value = 6
				}
			},
		}
	};
}