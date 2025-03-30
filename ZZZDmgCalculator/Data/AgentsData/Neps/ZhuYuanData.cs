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

[InfoData<Agents>(ZhuYuan)]
public class ZhuYuanData {
	public readonly static AgentInfo Data = new()
	{
		Uid = ZhuYuan,
		Icon = "Zhu_Yuan",
		Attribute = Ether,
		Faction = Neps,
		Specialty = Attack,
		AttackType = Pierce,
		DodgeType = Evasion,
		Rank = AgentRank.S,
		AdditionalCondition = SpecialtyAdditionalCondition(Support),
		CoreStats =
		[
			new()
			{
				Stat = CritDmg, Value = 9.6
			},
			new()
			{
				Stat = Atk, Value = 25
			}
		],
		BaseStats =
		[
			Templates["ZhuYuan.Atk"],
			Templates["Grace.Hp"],
			Templates["Rina.Def"],
		],
		FinalStats = [0, 90, 92, 93, 1.2],
		CoreBuff =
		[
			new BuffInfo
			{
				Type = Permanent,
				Scales = [[20, 23.3, 26.6, 30, 33.3, 36.6, 40]],
				SkillCondition = skill => skill is { Ability: "PleaseDoNotResist", Index: 3 or 4 or 5 },
				Modifiers = new StatModifier { Stat = BasicDmg, Type = Combat }
			},
			new BuffInfo
			{
				// todo: enable when enemy is stunned
				Scales = [[20, 23.3, 26.6, 30, 33.3, 36.6, 40]],
				SkillCondition = skill => skill is { Ability: "PleaseDoNotResist", Index: 3 or 4 or 5 },
				Modifiers = new StatModifier { Stat = BasicDmg, Type = Combat }
			}
		],
		AdditionalBuff = new BuffInfo
		{
			Modifiers = new StatModifier
			{
				Stat = CritRate, Value = 30, Type = Combat
			}
		},
		Abilities =
		[// todo: look for physical damage

			new()// Basic Attack: Don't Move!
			{
				Id = "DontMove",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [43.1, 47.1, 51.1, 55.1, 59.1, 63.1, 67.1, 71.1, 75.1, 79.1, 83.1, 87.1, 91.1, 95.1, 99.1, 103.1],
						Daze = [21.6, 22.6, 23.6, 24.6, 25.6, 26.6, 27.6, 28.6, 29.6, 30.6, 31.6, 32.6, 33.6, 34.6, 35.6, 36.6]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [126.4, 137.9, 149.4, 160.9, 172.4, 183.9, 195.4, 206.9, 218.4, 229.9, 241.4, 252.9, 264.4, 275.9, 287.4, 298.9],
						Daze = [97.3, 101.8, 106.3, 110.8, 115.3, 119.8, 124.3, 128.8, 133.3, 137.8, 142.3, 146.8, 151.3, 155.8, 160.3, 164.8]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [137.3, 149.8, 162.3, 174.8, 187.3, 199.8, 212.3, 224.8, 237.3, 249.8, 262.3, 274.8, 287.3, 299.8, 312.3, 324.8],
						Daze = [94.7, 99.1, 103.5, 107.9, 112.3, 116.7, 121.1, 125.5, 129.9, 134.3, 138.7, 143.1, 147.5, 151.9, 156.3, 160.7]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [151, 164.8, 178.6, 192.4, 206.2, 220, 233.8, 247.6, 261.4, 275.2, 289, 302.8, 316.6, 330.4, 344.2, 358.0],
						Daze = [124.3, 130, 135.7, 141.4, 147.1, 152.8, 158.5, 164.2, 169.9, 175.6, 181.3, 187, 192.7, 198.4, 204.1, 209.8]
					},
					new()// 5th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [162.2, 177, 191.8, 206.6, 221.4, 236.2, 251, 265.8, 280.6, 295.4, 310.2, 325, 339.8, 354.6, 369.4, 384.2],
						Daze = [139.2, 145.6, 152, 158.4, 164.8, 171.2, 177.6, 184, 190.4, 196.8, 203.2, 209.6, 216, 222.4, 228.8, 235.2]
					}
				]
			},
			new()// Basic Attack: Please Do Not Resist
			{
				Id = "PleaseDoNotResist",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (Physical) (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [53.7, 58.6, 63.5, 68.4, 73.3, 78.2, 83.1, 88, 92.9, 97.8, 102.7, 107.6, 112.5, 117.4, 122.3, 127.2],
						Daze = [59.6, 62.4, 65.2, 68, 70.8, 73.6, 76.4, 79.2, 82, 84.8, 87.6, 90.4, 93.2, 96, 98.8, 101.6]
					},
					new()// 2nd-Hit DMG Multiplier (Physical) (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [53.7, 58.6, 63.5, 68.4, 73.3, 78.2, 83.1, 88, 92.9, 97.8, 102.7, 107.6, 112.5, 117.4, 122.3, 127.2],
						Daze = [59.6, 62.4, 65.2, 68, 70.8, 73.6, 76.4, 79.2, 82, 84.8, 87.6, 90.4, 93.2, 96, 98.8, 101.6]
					},
					new()// 3rd-Hit DMG Multiplier (Physical) (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [160.9, 175.6, 190.3, 205, 219.7, 234.4, 249.1, 263.8, 278.5, 293.2, 307.9, 322.6, 337.3, 352, 366.7, 381.4],
						Daze = [178.7, 186.9, 195.1, 203.3, 211.5, 219.7, 227.9, 236.1, 244.3, 252.5, 260.7, 268.9, 277.1, 285.3, 293.5, 301.7]
					},
					new()// 1st-Hit DMG Multiplier (Ether) (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [135.9, 148.3, 160.7, 173.1, 185.5, 197.9, 210.3, 222.7, 235.1, 247.5, 259.9, 272.3, 284.7, 297.1, 309.5, 321.9],
						Daze = [59.6, 62.4, 65.2, 68, 70.8, 73.6, 76.4, 79.2, 82, 84.8, 87.6, 90.4, 93.2, 96, 98.8, 101.6]
					},
					new()// 2nd-Hit DMG Multiplier (Ether) (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [135.9, 148.3, 160.7, 173.1, 185.5, 197.9, 210.3, 222.7, 235.1, 247.5, 259.9, 272.3, 284.7, 297.1, 309.5, 321.9],
						Daze = [59.6, 62.4, 65.2, 68, 70.8, 73.6, 76.4, 79.2, 82, 84.8, 87.6, 90.4, 93.2, 96, 98.8, 101.6]
					},
					new()// 3rd-Hit DMG Multiplier (Ether) (%)
					{
						Type = Basic,
						DmgType = Ether,
						Dmg = [407.7, 444.8, 481.9, 519, 556.1, 593.2, 630.3, 667.4, 704.5, 741.6, 778.7, 815.8, 852.9, 890, 927.1, 964.2],
						Daze = [178.7, 186.9, 195.1, 203.3, 211.5, 219.7, 227.9, 236.1, 244.3, 252.5, 260.7, 268.9, 277.1, 285.3, 293.5, 301.7]
					}
				]
			},
			new()// Dash Attack: Firepower Offensive
			{
				Id = "FirepowerOffensive",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Ether,
						Dmg = [55.1, 60.2, 65.3, 70.4, 75.5, 80.6, 85.7, 90.8, 95.9, 101, 106.1, 111.2, 116.3, 121.4, 126.5, 131.6],
						Daze = [27.6, 28.9, 30.2, 31.5, 32.8, 34.1, 35.4, 36.7, 38, 39.3, 40.6, 41.9, 43.2, 44.5, 45.8, 47.1]
					}
				]
			},
			new()// Dash Attack: Overwhelming Firepower
			{
				Id = "OverwhelmingFirepower",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (Physical) (%)
					{
						Type = Dash,
						DmgType = Ether,
						Dmg = [53.7, 58.6, 63.5, 68.4, 73.3, 78.2, 83.1, 88, 92.9, 97.8, 102.7, 107.6, 112.5, 117.4, 122.3, 127.2],
						Daze = [59.6, 62.4, 65.2, 68, 70.8, 73.6, 76.4, 79.2, 82, 84.8, 87.6, 90.4, 93.2, 96, 98.8, 101.6]
					},
					new()// DMG Multiplier (Ether) (%)
					{
						Type = Dash,
						DmgType = Ether,
						Dmg = [135.9, 148.3, 160.7, 173.1, 185.5, 197.9, 210.3, 222.7, 235.1, 247.5, 259.9, 272.3, 284.7, 297.1, 309.5, 321.9],
						Daze = [59.6, 62.4, 65.2, 68, 70.8, 73.6, 76.4, 79.2, 82, 84.8, 87.6, 90.4, 93.2, 96, 98.8, 101.6]
					}
				]
			},
			new()// Dodge Counter: Fire Blast
			{
				Id = "FireBlast",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Ether,
						Dmg = [176.8, 192.9, 209, 225.1, 241.2, 257.3, 273.4, 289.5, 305.6, 321.7, 337.8, 353.9, 370, 386.1, 402.2, 418.3],
						Daze = [161.4, 168.8, 176.2, 183.6, 191, 198.4, 205.8, 213.2, 220.6, 228, 235.4, 242.8, 250.2, 257.6, 265, 272.4]
					}
				]
			},
			new()// Quick Assist: Covering Shot
			{
				Id = "CoveringShot",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Ether,
						Dmg = [51.4, 56.1, 60.8, 65.5, 70.2, 74.9, 79.6, 84.3, 89, 93.7, 98.4, 103.1, 107.8, 112.5, 117.2, 121.9],
						Daze = [51.4, 53.8, 56.2, 58.6, 61, 63.4, 65.8, 68.2, 70.6, 73, 75.4, 77.8, 80.2, 82.6, 85, 87.4]
					}
				]
			},
			new()// Assist Follow-Up: Defensive Counter
			{
				Id = "DefensiveCounter",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Ether,
						Dmg = [355.8, 388.2, 420.6, 453, 485.4, 517.8, 550.2, 582.6, 615, 647.4, 679.8, 712.2, 744.6, 777, 809.4, 841.8],
						Daze = [308.6, 322.7, 336.8, 350.9, 365, 379.1, 393.2, 407.3, 421.4, 435.5, 449.6, 463.7, 477.8, 491.9, 506, 520.1]
					}
				]
			},
			new()// Special Attack: Buckshot Blast
			{
				Id = "BuckshotBlast",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Ether,
						Dmg = [18.4, 20.1, 21.8, 23.5, 25.2, 26.9, 28.6, 30.3, 32, 33.7, 35.4, 37.1, 38.8, 40.5, 42.2, 43.9],
						Daze = [18.4, 19.3, 20.2, 21.1, 22, 22.9, 23.8, 24.7, 25.6, 26.5, 27.4, 28.3, 29.2, 30.1, 31, 31.9]
					}
				]
			},
			new()// EX Special Attack: Full Barrage
			{
				Id = "FullBarrage",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Ether,
						Dmg = [587.4, 640.8, 694.2, 747.6, 801, 854.4, 907.8, 961.2, 1014.6, 1068, 1121.4, 1174.8, 1228.2, 1281.6, 1335, 1388.4],
						Daze = [480, 501.9, 523.8, 545.7, 567.6, 589.5, 611.4, 633.3, 655.2, 677.1, 699, 720.9, 742.8, 764.7, 786.6, 808.5]
					}
				]
			},
			new()// Chain Attack: Eradication Mode
			{
				Id = "EradicationMode",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Ether,
						Dmg = [587.5, 641, 694.5, 748, 801.5, 855, 908.5, 962, 1015.5, 1069, 1122.5, 1176, 1229.5, 1283, 1336.5, 1390.0],
						Daze = [148.6, 155.4, 162.2, 169, 175.8, 182.6, 189.4, 196.2, 203, 209.8, 216.6, 223.4, 230.2, 237, 243.8, 250.6]
					}
				]
			},
			new()// Ultimate: Max Eradication Mode
			{
				Id = "MaxEradicationMode",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Ether,
						Dmg = [1977.6, 2157.4, 2337.2, 2517, 2696.8, 2876.6, 3056.4, 3236.2, 3416, 3595.8, 3775.6, 3955.4, 4135.2, 4315, 4494.8, 4674.6],
						Daze = [125.1, 131.3, 137.6, 143.9, 150.1, 156.4, 162.7, 169, 175.2, 181.5, 187.8, 194, 200.3, 206.6, 212.88, 219.1]
					}
				]
			},
		],
		Cinemas =
		{
			[2] = new BuffInfo
			{
				Type = Stack,
				Stacks = 5,
				SkillCondition = skill => skill.Ability is "PleaseDoNotResist" or "OverwhelmingFirepower",
				Modifiers =
				[
					new() { Stat = EtherDmg, Value = 10, Type = Combat },
				]
			},
			[4] = new BuffInfo
			{
				Type = Permanent,
				SkillCondition = skill => skill.Ability is "PleaseDoNotResist" or "OverwhelmingFirepower",
				Modifiers =
				[
					new() { Stat = EtherRes, Value = 25, Type = Combat },
				]
			},
			[6] = new SkillInfo
			{
				Value = 220,
				DmgType = Ether,
				Hits = 4,
				Cinema = true
			}
		}
	};
}