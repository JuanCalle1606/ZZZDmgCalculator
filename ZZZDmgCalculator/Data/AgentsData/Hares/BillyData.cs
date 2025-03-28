namespace ZZZDmgCalculator.Data.AgentsData.Hares;

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

[InfoData<Agents>(Billy)]
public class BillyData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Billy,
		Icon = "Billy_Kid",
		Attribute = Physical,
		Faction = Hares,
		Specialty = Attack,
		AttackType = Pierce,
		DodgeType = Evasion,
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
			Templates["Billy.Atk"],
			Templates["Billy.Hp"],
			Templates["Lycaon.Def"],
		],
		FinalStats = [0, 91, 91, 92, 1.2],
		CoreBuff = new BuffInfo
		{
			Scales = [[25, 29.1, 33.3, 37.5, 41.6, 45.8, 50]],
			Modifiers = new StatModifier
			{
				Stat = BonusDmg, Type = Combat
			}
		},
		AdditionalBuff = new BuffInfo
		{
			Type = Stack,
			Stacks = 2,
			Modifiers = new StatModifier { Stat = UltimateDmg, Type = Combat, Value = 50 }
		},
		Abilities =
		[
			new()// Basic Attack: Full Firepower
			{
				Id = "FullFirepower",
				Category = Basic,
				Skills =
				[
					new()// Standing Fire DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [68, 74.2, 80.4, 86.6, 92.8, 99, 105.2, 111.4, 117.6, 123.8, 130, 136.2, 142.4, 148.6, 154.8, 161],
						Daze = [54.4, 56.9, 59.4, 61.9, 64.4, 66.9, 69.4, 71.9, 74.4, 76.9, 79.4, 81.9, 84.4, 86.9, 89.4, 91.9]
					},
					new()// Standing Bullet DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [7.6, 8.3, 9, 9.7, 10.4, 11.1, 11.8, 12.5, 13.2, 13.9, 14.6, 15.3, 16, 16.7, 17.4, 18.1],
						Daze = [54.4, 56.9, 59.4, 61.9, 64.4, 66.9, 69.4, 71.9, 74.4, 76.9, 79.4, 81.9, 84.4, 86.9, 89.4, 91.9]
					},
					new()// Crouching Fire DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [61.8, 67.5, 73.2, 78.9, 84.6, 90.3, 96, 101.7, 107.4, 113.1, 118.8, 124.5, 130.2, 135.9, 141.6, 147.3],
						Daze = [54.7, 57.2, 59.7, 62.2, 64.7, 67.2, 69.7, 72.2, 74.7, 77.2, 79.7, 82.2, 84.7, 87.2, 89.7, 92.2]
					},
					new()// Crouching Bullet DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [12.7, 13.9, 15.1, 16.3, 17.5, 18.7, 19.9, 21.1, 22.3, 23.5, 24.7, 25.9, 27.1, 28.3, 29.5, 30.7],
						Daze = [8.9, 9.4, 9.9, 10.4, 10.9, 11.4, 11.9, 12.4, 12.9, 13.4, 13.9, 14.4, 14.9, 15.4, 15.9, 16.4]
					},
					new()// Rolling Shot DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [61.8, 67.5, 73.2, 78.9, 84.6, 90.3, 96, 101.7, 107.4, 113.1, 118.8, 124.5, 130.2, 135.9, 141.6, 147.3],
						Daze = [54.7, 57.2, 59.7, 62.2, 64.7, 67.2, 69.7, 72.2, 74.7, 77.2, 79.7, 82.2, 84.7, 87.2, 89.7, 92.2]
					},
					new()// Finishing Shot DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [49.5, 54, 58.5, 63, 67.5, 72, 76.5, 81, 85.5, 90, 94.5, 99, 103.5, 108, 112.5, 117],
						Daze = [55.2, 57.8, 60.4, 63, 65.6, 68.2, 70.8, 73.4, 76, 78.6, 81.2, 83.8, 86.4, 89, 91.6, 94.2]
					}
				]
			},
			new()// Dash Attack: Starlight Sanction
			{
				Id = "StarlightSanction",
				Category = Dodge,
				Skills =
				[
					new()// 360-degree Shot DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [63.0, 68.8, 74.6, 80.4, 86.2, 92.0, 97.8, 103.6, 109.4, 115.2, 121.0, 126.8, 132.6, 138.4, 144.2, 150.0],
						Daze = [63.0, 65.9, 68.8, 71.7, 74.6, 77.5, 80.4, 83.3, 86.2, 89.1, 92.0, 94.9, 97.8, 100.7, 103.6, 106.5]
					},
					new()// Standing Shot DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [39.0, 42.8, 46.6, 50.4, 54.2, 58.0, 61.8, 65.6, 69.4, 73.2, 77.0, 80.8, 84.6, 88.4, 92.2, 96.0],
						Daze = [19.5, 20.4, 21.3, 22.2, 23.1, 24.0, 24.9, 25.8, 26.7, 27.6, 28.5, 29.4, 30.3, 31.2, 32.1, 33.0]
					}
				]
			},
			new()// Dodge Counter: Fair Fight
			{
				Id = "FairFight",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Physical,
						Dmg = [221.4, 241.6, 261.8, 282, 302.2, 322.4, 342.6, 362.8, 383, 403.2, 423.4, 443.6, 463.8, 484, 504.2, 524.4],
						Daze = [193.4, 202.2, 211, 219.8, 228.6, 237.4, 246.2, 255, 263.8, 272.6, 281.4, 290.2, 299, 307.8, 316.6, 325.4]
					}
				]
			},
			new()// Quick Assist: Power of Teamwork
			{
				Id = "PowerofTeamwork",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Physical,
						Dmg = [93.4, 101.9, 110.4, 118.9, 127.4, 135.9, 144.4, 152.9, 161.4, 169.9, 178.4, 186.9, 195.4, 203.9, 212.4, 220.9],
						Daze = [93.4, 97.7, 102.0, 106.3, 110.6, 114.9, 119.2, 123.5, 127.8, 132.1, 136.4, 140.7, 145.0, 149.3, 153.6, 157.9]
					}
				]
			},
			new()// Assist Follow-Up: Fatal Shot
			{
				Id = "FatalShot",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Physical,
						Dmg = [388.8, 424.2, 459.6, 495, 530.4, 565.8, 601.2, 636.6, 672, 707.4, 742.8, 778.2, 813.6, 849, 884.4, 919.8],
						Daze = [341.2, 356.8, 372.4, 388, 403.6, 419.2, 434.8, 450.4, 466, 481.6, 497.2, 512.8, 528.4, 544, 559.6, 575.2]
					}
				]
			},
			new()// Special Attack: Stand Still
			{
				Id = "StandStill",
				Category = Special,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [24.2, 26.4, 28.6, 30.8, 33.0, 35.2, 37.4, 39.6, 41.8, 44.0, 46.2, 48.4, 50.6, 52.8, 55.0, 57.2],
						Daze = [24.2, 25.3, 26.4, 27.5, 28.6, 29.7, 30.8, 31.9, 33.0, 34.1, 35.2, 36.3, 37.4, 38.5, 39.6, 40.7]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [51.7, 56.4, 61.1, 65.8, 70.5, 75.2, 79.9, 84.6, 89.3, 94.0, 98.7, 103.4, 108.1, 112.8, 117.5, 122.2],
						Daze = [51.7, 54.1, 56.5, 58.9, 61.3, 63.7, 66.1, 68.5, 70.9, 73.3, 75.7, 78.1, 80.5, 82.9, 85.3, 87.7]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [50.1, 54.7, 59.3, 63.9, 68.5, 73.1, 77.7, 82.3, 86.9, 91.5, 96.1, 100.7, 105.3, 109.9, 114.5, 119.1],
						Daze = [50.1, 52.4, 54.7, 57.0, 59.3, 61.6, 63.9, 66.2, 68.5, 70.8, 73.1, 75.4, 77.7, 80.0, 82.3, 84.6]
					}
				]
			},
			new()// EX Special Attack: Clearance Time
			{
				Id = "ClearanceTime",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [543.8, 593.3, 642.8, 692.3, 741.8, 791.3, 840.8, 890.3, 939.8, 989.3, 1038.8, 1088.3, 1137.8, 1187.3, 1236.8, 1286.3],
						Daze = [439.5, 459.5, 479.5, 499.5, 519.5, 539.5, 559.5, 579.5, 599.5, 619.5, 639.5, 659.5, 679.5, 699.5, 719.5, 739.5]
					}
				]
			},
			new()// Chain Attack: Starlight Mirage
			{
				Id = "StarlightMirage",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Physical,
						Dmg = [735.2, 802.1, 869, 935.9, 1002.8, 1069.7, 1136.6, 1203.5, 1270.4, 1337.3, 1404.2, 1471.1, 1538, 1604.9, 1671.8, 1738.7],
						Daze = [196.6, 205.6, 214.6, 223.6, 232.6, 241.6, 250.6, 259.6, 268.6, 277.6, 286.6, 295.6, 304.6, 313.6, 322.6, 331.6]
					}
				]
			},
			new()// Ultimate: Starlight, Shine Bright
			{
				Id = "StarlightShineBright",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Physical,
						Dmg = [1597.7, 1743, 1888.3, 2033.6, 2178.9, 2324.2, 2469.5, 2614.8, 2760.1, 2905.4, 3050.7, 3196, 3341.3, 3486.6, 3631.9, 3777.2],
						Daze = [190.6, 199.3, 208, 216.7, 225.4, 234.1, 242.8, 251.5, 260.2, 268.9, 277.6, 286.3, 295, 303.7, 312.4, 321.1]
					}
				]
			}
		],
		Cinemas =
		{
			[2] = new BuffInfo
			{
				Type = Permanent,
				SkillCondition = skill => skill.Type is Dodge || (skill.Type is Basic && skill.Index is 4),
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat, Value = 25
				}
			},
			[4] = new BuffInfo
			{
				Type = Stack,
				SkillCondition = skill => skill.Type is Ex,
				Stacks = 4,
				Modifiers = new StatModifier
				{
					Stat = CritRate, Type = Combat, Value = 8
				}
			},
			[6] = new BuffInfo
			{
				Type = Stack,
				Stacks = 5,
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat, Value = 6
				}
			},
		}
	};
}