namespace ZZZDmgCalculator.Data.AgentsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static AgentScales;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.DodgeTypes;
using static Models.Enum.Factions;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Agents;
using static ZZZ.ApiModels.Skills;

[UrlTemplate("icons/agents/Agent_{Icon}_Icon.webp")]
[InfoData<Agents>(Lucy)]
public class LucyData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Lucy,
		Icon = "Luciana_de_Montefio",
		Attribute = Fire,
		Faction = Calydon,
		Specialty = Support,
		AttackType = Strike,
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
			Templates["Lucy.Atk"],
			Templates["Lucy.Hp"],
			Templates["Lucy.Def"],
		],
		FinalStats = [0, 86, 93, 94, 1.2],
		Abilities =
		[
			new()// Basic Attack: Lady's Bat
			{
				Id = "LadysBat",
				Category = Basic,
				UseCommonNames = true,
				MaxCommonName = 4,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [56.6, 61.8, 67, 72.2, 77.4, 82.6, 87.8, 93.0, 98.2, 103.4, 108.6, 113.8, 119.0, 124.2, 129.4, 134.6],
						Daze = [28.3, 29.6, 30.9, 32.2, 33.5, 34.8, 36.1, 37.4, 38.7, 40.0, 41.3, 42.6, 43.9, 45.2, 46.5, 47.8]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [77.8, 84.9, 92.0, 99.1, 106.2, 113.3, 120.4, 127.5, 134.6, 141.7, 148.8, 155.9, 163.0, 170.1, 177.2, 184.3],
						Daze = [65, 68, 71, 74, 77, 80, 83, 86, 89, 92, 95, 98, 101, 104, 107, 110]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [188.9, 206.1, 223.3, 240.5, 257.7, 274.9, 292.1, 309.3, 326.5, 343.7, 360.9, 378.1, 395.3, 412.5, 429.7, 446.9],
						Daze = [157.4, 164.6, 171.8, 179.0, 186.2, 193.4, 200.6, 207.8, 215.0, 222.2, 229.4, 236.6, 243.8, 251.0, 258.2, 265.4]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Dmg = [272.6, 297.4, 322.2, 347.0, 371.8, 396.6, 421.4, 446.2, 471.0, 495.8, 520.6, 545.4, 570.2, 595, 619.8, 644.6],
						Daze = [208, 217.5, 227, 236.5, 246, 255.5, 265, 274.5, 284, 293.5, 303, 312.5, 322, 331.5, 341, 350.5]
					},
					new()// 3rd-Hit (ALT) DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [211.5, 230.8, 250.1, 269.4, 288.7, 308.0, 327.3, 346.6, 365.9, 385.2, 404.5, 423.8, 443.1, 462.4, 481.7, 501.0],
						Daze = [162.3, 169.7, 177.1, 184.5, 191.9, 199.3, 206.7, 214.1, 221.5, 228.9, 236.3, 243.7, 251.1, 258.5, 265.9, 273.3]
					},
				]
			},
			new()// Guard Boars: To Arms!
			{
				Id = "ToArms",
				Category = Basic,
				Skills =
				[
					new()// Baseball Bat DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [92.5, 101, 109.5, 118, 126.5, 135, 143.5, 152, 160.5, 169, 177.5, 186, 194.5, 203, 211.5, 220],
						Daze = [15.5, 16.3, 17.1, 17.9, 18.7, 19.5, 20.3, 21.1, 21.9, 22.7, 23.5, 24.3, 25.1, 25.9, 26.7, 27.5]
					},
					new()// Boxing Gloves DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [127.5, 139.1, 150.7, 162.3, 173.9, 185.5, 197.1, 208.7, 220.3, 231.9, 243.5, 255.1, 266.7, 278.3, 289.9, 301.5],
						Daze = [21.3, 22.3, 23.3, 24.3, 25.3, 26.3, 27.3, 28.3, 29.3, 30.3, 31.3, 32.3, 33.3, 34.3, 35.3, 36.3]
					},
					new()// Slingshot DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [175, 191, 207, 223, 239, 255, 271, 287, 303, 319, 335, 351, 367, 383, 399, 415],
						Daze = [29.2, 30.6, 32.0, 33.4, 34.8, 36.2, 37.6, 39.0, 40.4, 41.8, 43.2, 44.6, 46.0, 47.4, 48.8, 50.2]
					}
				]
			},
			new()// Guard Boars: Spinning Swing!
			{
				Id = "SpinningSwing",
				Category = Basic,
				Skills =
				[
					new()// Spinning Swing DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [250, 272.8, 295.6, 318.4, 341.2, 364.0, 386.8, 409.6, 432.4, 455.2, 478.0, 500.8, 523.6, 546.4, 569.2, 592],
						Daze = [20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35]
					}
				]
			},
			new()// Dash Attack: Fearless Boar!
			{
				Id = "FearlessBoar",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [78.4, 85.6, 92.8, 100.0, 107.2, 114.4, 121.6, 128.8, 136, 143.2, 150.4, 157.6, 164.8, 172.0, 179.2, 186.4],
						Daze = [39.2, 41, 42.8, 44.6, 46.4, 48.2, 50.0, 51.8, 53.6, 55.4, 57.2, 59.0, 60.8, 62.6, 64.4, 66.2]
					}
				]
			},
			new()// Dodge Counter: Returning Tusk!
			{
				Id = "ReturningTusk",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Fire,
						Dmg = [308, 336, 364, 392, 420, 448, 476, 504, 532, 560, 588, 616, 644, 672, 700, 728],
						Daze = [260, 271.9, 283.8, 295.7, 307.6, 319.5, 331.4, 343.3, 355.2, 367.1, 379.0, 390.9, 402.8, 414.7, 426.6, 438.5]
					}
				]
			},
			new()// Quick Assist: Hit By Pitch!
			{
				Id = "HitByPitch",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Fire,
						Dmg = [160, 174.6, 189.2, 203.8, 218.4, 233.0, 247.6, 262.2, 276.8, 291.4, 306.0, 320.6, 335.2, 349.8, 364.4, 379.0],
						Daze = [160, 167.3, 174.6, 181.9, 189.2, 196.5, 203.8, 211.1, 218.4, 225.7, 233.0, 240.3, 247.6, 254.9, 262.2, 269.5]
					}
				]
			},
			new()// Defensive Assist: Safe on Base!
			{
				Id = "SafeonBase",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [207.7, 217.2, 226.7, 236.2, 245.7, 255.2, 264.7, 274.2, 283.7, 293.2, 302.7, 312.2, 321.7, 331.2, 340.7, 350.2]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [229.4, 239.9, 250.4, 260.9, 271.4, 281.9, 292.4, 302.9, 313.4, 323.9, 334.4, 344.9, 355.4, 365.9, 376.4, 386.9]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [69.4, 72.6, 75.8, 79.0, 82.2, 85.4, 88.6, 91.8, 95.0, 98.2, 101.4, 104.6, 107.8, 111.0, 114.2, 117.4]
					}
				]
			},
			new()// Assist Follow-Up: Scored a Run!
			{
				Id = "ScoredaRun",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Fire,
						Dmg = [349.1, 380.9, 412.7, 444.5, 476.3, 508.1, 539.9, 571.7, 603.5, 635.3, 667.1, 698.9, 730.7, 762.5, 794.3, 826.1],
						Daze = [304.3, 318.2, 332.1, 346.0, 359.9, 373.8, 387.7, 401.6, 415.5, 429.4, 443.3, 457.2, 471.1, 485.0, 498.9, 512.8]
					}
				]
			},
			new()// Special Attack: Solid Hit!
			{
				Id = "SolidHit",
				Category = Special,
				Skills =
				[
					new()// Line Drive DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Fire,
						Dmg = [61.7, 67.4, 73.1, 78.8, 84.5, 90.2, 95.9, 101.6, 107.3, 113.0, 118.7, 124.4, 130.1, 135.8, 141.5, 147.2],
						Daze = [61.7, 64.6, 67.5, 70.4, 73.3, 76.2, 79.1, 82.0, 84.9, 87.8, 90.7, 93.6, 96.5, 99.4, 102.3, 105.2]
					},
					new()// Fly Ball DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Fire,
						Dmg = [69.2, 75.5, 81.8, 88.1, 94.4, 100.7, 107.0, 113.3, 119.6, 125.9, 132.2, 138.5, 144.8, 151.1, 157.4, 163.7],
						Daze = [69.2, 72.4, 75.6, 78.8, 82.0, 85.2, 88.4, 91.6, 94.8, 98.0, 101.2, 104.4, 107.6, 110.8, 114.0, 117.2]
					}
				]
			},
			new()// EX Special Attack: Home Run!
			{
				Id = "HomeRun",
				Category = Special,
				Skills =
				[
					new()// Line Drive DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [508.4, 554.7, 601.0, 647.3, 693.6, 739.9, 786.2, 832.5, 878.8, 925.1, 971.4, 1017.7, 1064.0, 1110.3, 1156.6, 1202.9],
						Daze = [364.6, 381.2, 397.8, 414.4, 431.0, 447.6, 464.2, 480.8, 497.4, 514.0, 530.6, 547.2, 563.8, 580.4, 597.0, 613.6]
					},
					new()// Fly Ball DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [536.4, 585.2, 634.0, 682.8, 731.6, 780.4, 829.2, 878.0, 926.8, 975.6, 1024.4, 1073.2, 1122.0, 1170.8, 1219.6, 1268.4],
						Daze = [389.6, 407.4, 425.2, 443.0, 460.8, 478.6, 496.4, 514.2, 532, 549.8, 567.6, 585.4, 603.2, 621.0, 638.8, 656.6]
					}
				]
			},
			new()// Cheer On!
			{
				Id = "CheerOn",
				Category = Special,
				Buffs = new BuffInfo
				{
					BuffLimit = 600,
					Scales = [Templates["Lucy.b1"], Templates["Lucy.b2"]],
					Modifiers =
					[
						new() { Stat = Atk, Type = BasePercent, Shared = true, Agent = true },
						new() { Stat = Atk, Type = CombatFlat, Shared = true }
					]
				}
			},
			new()// Chain Attack: Grand Slam!
			{
				Id = "GrandSlam",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%*3)
					{
						Type = Chain,
						DmgType = Fire,
						Dmg = [164.1, 179.0, 194.0, 208.9, 223.8, 238.8, 253.7, 268.6, 283.5, 298.5, 313.4, 328.3, 343.3, 358.2, 373.1, 388.1],
						Daze = [31.1, 32.5, 34.0, 35.4, 36.8, 38.2, 39.7, 41.1, 42.5, 44.0, 45.4, 46.8, 48.3, 49.7, 51.1, 52.5]
					}
				]
			},
			new()// Ultimate: Walk-Off Home Run!
			{
				Id = "WalkOffHomeRun",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%*3)
					{
						Type = Ultimate,
						DmgType = Fire,
						Dmg = [572.8, 624.9, 677, 729.1, 781.2, 833.3, 885.4, 937.5, 989.6, 1041.7, 1093.8, 1145.9, 1198.0, 1250.1, 1302.2, 1354.3],
						Daze = [94.5, 98.8, 103.1, 107.4, 111.7, 116.0, 120.3, 124.6, 128.9, 133.2, 137.5, 141.8, 146.1, 150.4, 154.7, 159.0]
					}
				]
			},
		],
		Cinemas =
		{
			[4] = new StatModifier { Stat = CritDmg, Value = 10, Type = Combat },
			[6] = new SkillInfo { DmgType = Fire, Value = 300 } // TODO: implement skills from Cinemas
		}
	};
}