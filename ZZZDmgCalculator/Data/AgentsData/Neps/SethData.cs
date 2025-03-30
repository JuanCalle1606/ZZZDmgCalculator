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

[InfoData<Agents>(Seth)]
public class SethData
{
	public readonly static AgentInfo Data = new()
	{
		Uid = Seth,
		Icon = "Seth_Lowell",
		Attribute = Electric,
		Faction = Neps,
		Specialty = Defense,
		AttackType = Slash,
		DodgeType = Parry,
		Rank = AgentRank.A,
		AdditionalCondition = BasicAdditionalCondition,
		CoreStats =
		[
			new()
			{
				Stat = EnergyRegen, Value = 0.12
			},
			new()
			{
				Stat = Atk, Value = 25
			}
		],
		BaseStats =
		[
			Templates["Seth.Atk"],
			Templates["Seth.Hp"],
			Templates["Seth.Def"],
		],
		FinalStats = [0, 94, 90, 86, 1.2],
		CoreBuff = new BuffInfo
		{
			// todo: shield buff
		},
		AdditionalBuff =
		[
			// todo
		],
		Abilities =
		[// todo: look for physical damage
			new() // Basic Attack: Lightning Strike
			{
				Id = "LightningStrike",
				Category = Basic,
				Skills =
				[
					new() // 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [36.2, 39.5, 42.8, 46.1, 49.4, 52.7, 56.0, 59.3, 62.6, 65.9, 69.2, 72.5, 75.8, 79.1, 82.4, 85.7],
						Daze = [18.1, 19, 19.9, 20.8, 21.7, 22.6, 23.5, 24.4, 25.3, 26.2, 27.1, 28.0, 28.9, 29.8, 30.7, 31.6]
					},
					new() // 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [56.5, 61.7, 66.9, 72.1, 77.3, 82.5, 87.7, 92.9, 98.1, 103.3, 108.5, 113.7, 118.9, 124.1, 129.3, 134.5],
						Daze = [45.1, 47.2, 49.3, 51.4, 53.5, 55.6, 57.7, 59.8, 61.9, 64.0, 66.1, 68.2, 70.3, 72.4, 74.5, 76.6]
					},
					new() // 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [193.3, 210.9, 228.5, 246.1, 263.7, 281.3, 298.9, 316.5, 334.1, 351.7, 369.3, 386.9, 404.5, 422.1, 439.7, 457.3],
						Daze = [151.3, 158.2, 165.1, 172.0, 178.9, 185.8, 192.7, 199.6, 206.5, 213.4, 220.3, 227.2, 234.1, 241.0, 247.9, 254.8]
					},
					new() // 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [97.4, 106.3, 115.2, 124.1, 133.0, 141.9, 150.8, 159.7, 168.6, 177.5, 186.4, 195.3, 204.2, 213.1, 222.0, 230.9],
						Daze = [80.5, 84.2, 87.9, 91.6, 95.3, 99.0, 102.7, 106.4, 110.1, 113.8, 117.5, 121.2, 124.9, 128.6, 132.3, 136]
					}
				]
			},
			new() // Basic Attack: Lightning Strike - Electrified
			{
				Id = "LightningStrikeElectrified",
				Category = Basic,
				Skills =
				[
					new() // Consecutive Attack DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [382.8, 417.6, 452.4, 487.2, 522, 556.8, 591.6, 626.4, 661.2, 696.0, 730.8, 765.6, 800.4, 835.2, 870.0, 904.8],
						Daze = [161.7, 169.1, 176.5, 183.9, 191.3, 198.7, 206.1, 213.5, 220.9, 228.3, 235.7, 243.1, 250.5, 257.9, 265.3, 272.7]
					},
					new() // Finishing Move DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Electric,
						Dmg = [424.2, 462.8, 501.4, 540, 578.6, 617.2, 655.8, 694.4, 733.0, 771.6, 810.2, 848.8, 887.4, 926.0, 964.6, 1003.2],
						Daze = [145.5, 152.2, 158.9, 165.6, 172.3, 179.0, 185.7, 192.4, 199.1, 205.8, 212.5, 219.2, 225.9, 232.6, 239.3, 246.0]
					}
				]
			},
			new() // Dash Attack: Thunder Assault
			{
				Id = "ThunderAssault",
				Category = Dodge,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Electric,
						Dmg = [110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260],
						Daze = [55, 57.5, 60, 62.5, 65, 67.5, 70, 72.5, 75, 77.5, 80, 82.5, 85, 87.5, 90, 92.5]
					}
				]
			},
			new() // Dodge Counter: Retreat to Advance
			{
				Id = "RetreattoAdvance",
				Category = Dodge,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Electric,
						Dmg = [230, 251, 272, 293, 314, 335, 356, 377, 398, 419, 440, 461, 482, 503, 524, 545],
						Daze = [200, 209.1, 218.2, 227.3, 236.4, 245.5, 254.6, 263.7, 272.8, 281.9, 291.0, 300.1, 309.2, 318.3, 327.4, 336.5]
					}
				]
			},
			new() // Defensive Assist: Thundershield
			{
				Id = "Thundershield",
				Category = Assist,
				Skills =
				[
					new() // Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [246.7, 258, 269.3, 280.6, 291.9, 303.2, 314.5, 325.8, 337.1, 348.4, 359.7, 371.0, 382.3, 393.6, 404.9, 416.2]
					},
					new() // Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [311.7, 325.9, 340.1, 354.3, 368.5, 382.7, 396.9, 411.1, 425.3, 439.5, 453.7, 467.9, 482.1, 496.3, 510.5, 524.7]
					},
					new() // Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [151.7, 158.6, 165.5, 172.4, 179.3, 186.2, 193.1, 200.0, 206.9, 213.8, 220.7, 227.6, 234.5, 241.4, 248.3, 255.2]
					}
				]
			},
			new() // Quick Assist: Armed Support
			{
				Id = "ArmedSupport",
				Category = Assist,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Electric,
						Dmg = [100, 109.1, 118.2, 127.3, 136.4, 145.5, 154.6, 163.7, 172.8, 181.9, 191.0, 200.1, 209.2, 218.3, 227.4, 236.5],
						Daze = [100, 104.6, 109.2, 113.8, 118.4, 123.0, 127.6, 132.2, 136.8, 141.4, 146.0, 150.6, 155.2, 159.8, 164.4, 169.0]
					}
				]
			},
			new() // Assist Follow-Up: Public Security Ruling
			{
				Id = "PublicSecurityRuling",
				Category = Assist,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Electric,
						Dmg = [428.5, 467.5, 506.5, 545.5, 584.5, 623.5, 662.5, 701.5, 740.5, 779.5, 818.5, 857.5, 896.5, 935.5, 974.5, 1013.5],
						Daze = [378, 395.2, 412.4, 429.6, 446.8, 464.0, 481.2, 498.4, 515.6, 532.8, 550, 567.2, 584.4, 601.6, 618.8, 636.0]
					}
				]
			},
			new() // Special Attack: Thunder Shield Rush
			{
				Id = "ThunderShieldRush",
				Category = Special,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Electric,
						Dmg = [69.2, 75.5, 81.8, 88.1, 94.4, 100.7, 107.0, 113.3, 119.6, 125.9, 132.2, 138.5, 144.8, 151.1, 157.4, 163.7],
						Daze = [69.2, 72.4, 75.6, 78.8, 82.0, 85.2, 88.4, 91.6, 94.8, 98.0, 101.2, 104.4, 107.6, 110.8, 114.0, 117.2]
					}
				]
			},
			new() // EX Special Attack: Thunder Shield Rush - High Voltage
			{
				Id = "ThunderShieldRushHighVoltage",
				Category = Special,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Electric,
						Dmg = [646, 704.8, 763.6, 822.4, 881.2, 940.0, 998.8, 1057.6, 1116.4, 1175.2, 1234.0, 1292.8, 1351.6, 1410.4, 1469.2, 1528.0],
						Daze =
						[
							999.8, 1090.7, 1181.6, 1272.5, 1363.4, 1454.3, 1545.2, 1636.1, 1727.0, 1817.9, 1908.8, 1999.7, 2090.6, 2181.5, 2272.4,
							2363.3
						]
					},
					new() // DMG Multiplier (Charged) (%)
					{
						Type = Ex,
						DmgType = Electric,
						Dmg =
						[
							999.8, 1090.7, 1181.6, 1272.5, 1363.4, 1454.3, 1545.2, 1636.1, 1727.0, 1817.9, 1908.8, 1999.7, 2090.6, 2181.5, 2272.4,
							2363.3
						],
						Daze = []
					}
				]
			},
			new() // Chain Attack: Final Judgement
			{
				Id = "FinalJudgement",
				Category = Ultimate,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Electric,
						Dmg =
						[
							704.1, 768.2, 832.3, 896.4, 960.5, 1, 024.6, 1, 088.7, 1, 152.8, 1, 216.9, 1, 281.0, 1, 345.1, 1, 409.2, 1, 473.3, 1,
							537.4, 1, 601.5, 1, 665.6
						],
						Daze = [305.1, 319, 332.9, 346.8, 360.7, 374.6, 388.5, 402.4, 416.3, 430.2, 444.1, 458.0, 471.9, 485.8, 499.7, 513.6]
					}
				]
			},
			new() // Ultimate: Justice Prevails
			{
				Id = "JusticePrevails",
				Category = Ultimate,
				Skills =
				[
					new() // DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Electric,
						Dmg =
						[
							2, 024.3, 2, 208.4, 2, 392.5, 2, 576.6, 2, 760.7, 2, 944.8, 3, 128.9, 3, 313, 3, 497.1, 3, 681.2, 3, 865.3, 4, 049.4, 4,
							233.5, 4, 417.6, 4, 601.7, 4, 785.8
						],
						Daze = [403.3, 421.7, 440.1, 458.5, 476.9, 495.3, 513.7, 532.1, 550.5, 568.9, 587.3, 605.7, 624.1, 642.5, 660.9, 679.3]
					}
				]
			},
		],
		Cinemas =
		{
			// todos
		}
	};
}