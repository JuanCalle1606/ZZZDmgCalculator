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

[InfoData<Agents>(Nekomata)]
public class NekomataData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Nekomata,
		Icon = "Nekomiya_Mana",
		Attribute = Physical,
		Faction = Hares,
		Specialty = Attack,
		AttackType = Slash,
		DodgeType = Parry,
		Rank = AgentRank.S,
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
			Templates["Nekomata.Atk"],
			Templates["Nekomata.Hp"],
			Templates["Nekomata.Def"],
		],
		FinalStats = [0, 92, 96, 97, 1.2],
		CoreBuff = new BuffInfo
		{
			Scales = [[30, 35, 40, 45, 50, 55, 60]],
			Modifiers = new StatModifier
			{
				Stat = BonusDmg, Type = Combat
			}
		},
		AdditionalBuff = new BuffInfo
		{
			Type = Stack,
			Stacks = 2,
			Modifiers = new StatModifier { Stat = ExDmg, Type = Combat, Value = 35 }
		},
		Abilities =
		[
			new()// Basic Attack: Kitty Slash
			{
				Id = "KittySlash",
				Category = Basic,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [55.2, 60.3, 65.4, 70.5, 75.6, 80.7, 85.8, 90.9, 96.0, 101.1, 106.2, 111.3, 116.4, 121.5, 126.6, 131.7],
						Daze = [18, 27, 36, 45, 54, 63, 72, 81, 90, 99, 108, 117, 126, 135, 144, 153]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [62.6, 68.3, 74.0, 79.7, 85.4, 91.1, 96.8, 102.5, 108.2, 113.9, 119.6, 125.3, 131.0, 136.7, 142.4, 148.1],
						Daze = [37.1, 38.8, 40.5, 42.2, 43.9, 45.6, 47.3, 49.0, 50.7, 52.4, 54.1, 55.8, 57.5, 59.2, 60.9, 62.6]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [72.7, 79.4, 86.1, 92.8, 99.5, 106.2, 112.9, 119.6, 126.3, 133.0, 139.7, 146.4, 153.1, 159.8, 166.5, 173.2],
						Daze = [46.7, 48.9, 51.1, 53.3, 55.5, 57.7, 59.9, 62.1, 64.3, 66.5, 68.7, 70.9, 73.1, 75.3, 77.5, 79.7]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [170.2, 185.7, 201.2, 216.7, 232.2, 247.7, 263.2, 278.7, 294.2, 309.7, 325.2, 340.7, 356.2, 371.7, 387.2, 402.7],
						Daze = [103.7, 108.5, 113.3, 118.1, 122.9, 127.7, 132.5, 137.3, 142.1, 146.9, 151.7, 156.5, 161.3, 166.1, 170.9, 175.7]
					},
					new()// 5th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [123.6, 134.9, 146.2, 157.5, 168.8, 180.1, 191.4, 202.7, 214.0, 225.3, 236.6, 247.9, 259.2, 270.5, 281.8, 293.1],
						Daze = [58.9, 61.6, 64.3, 67.0, 69.7, 72.4, 75.1, 77.8, 80.5, 83.2, 85.9, 88.6, 91.3, 94.0, 96.7, 99.4]
					}
				]
			},
			new()// Basic Attack: Crimson Blade
			{
				Id = "CrimsonBlade",
				Category = Basic,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Dmg = [71.8, 78.4, 85.0, 91.6, 98.2, 104.8, 111.4, 118.0, 124.6, 131.2, 137.8, 144.4, 151.0, 157.6, 164.2, 170.8],
						Daze = [58.9, 61.6, 64.3, 67.0, 69.7, 72.4, 75.1, 77.8, 80.5, 83.2, 85.9, 88.6, 91.3, 94.0, 96.7, 99.4]
					}
				]
			},
			new()// Dash Attack: Over Here!
			{
				Id = "OverHere",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Physical,
						Dmg = [35.1, 38.3, 41.5, 44.7, 47.9, 51.1, 54.3, 57.5, 60.7, 63.9, 67.1, 70.3, 73.5, 76.7, 79.9, 83.1],
						Daze = [17.6, 18.4, 19.2, 20.0, 20.8, 21.6, 22.4, 23.2, 24.0, 24.8, 25.6, 26.4, 27.2, 28.0, 28.8, 29.6]
					}
				]
			},
			new()// Dodge Counter: Phantom Claws
			{
				Id = "PhantomClaws",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Physical,
						Dmg = [227.9, 248.7, 269.5, 290.3, 311.1, 331.9, 352.7, 373.5, 394.3, 415.1, 435.9, 456.7, 477.5, 498.3, 519.1, 539.9],
						Daze = [199.5, 208.6, 217.7, 226.8, 235.9, 245, 254.1, 263.2, 272.3, 281.4, 290.5, 299.6, 308.7, 317.8, 326.9, 336]
					}
				]
			},
			new()// Quick Assist: Cat's Paw
			{
				Id = "CatsPaw",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Physical,
						Dmg = [94.5, 103.1, 111.7, 120.3, 128.9, 137.5, 146.1, 154.7, 163.3, 171.9, 180.5, 189.1, 197.7, 206.3, 214.9, 223.5],
						Daze = [94.5, 98.8, 103.1, 107.4, 111.7, 116, 120.3, 124.6, 128.9, 133.2, 137.5, 141.8, 146.1, 150.4, 154.7, 159]
					}
				]
			},
			new()// Defensive Assist: Desperate Defense
			{
				Id = "DesperateDefense",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [259, 270.8, 282.6, 294.4, 306.2, 318, 329.8, 341.6, 353.4, 365.2, 377, 388.8, 400.6, 412.4, 424.2, 436]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [327.3, 342.2, 357.1, 372, 386.9, 401.8, 416.7, 431.6, 446.5, 461.4, 476.3, 491.2, 506.1, 521, 535.9, 550.8]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [159.3, 166.6, 173.9, 181.2, 188.5, 195.8, 203.1, 210.4, 217.7, 225, 232.3, 239.6, 246.9, 254.2, 261.5, 268.8]
					}
				]
			},
			new()// Assist Follow-Up: Shadow Strike
			{
				Id = "ShadowStrike",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Physical,
						Dmg = [300.4, 327.8, 355.2, 382.6, 410, 437.4, 464.8, 492.2, 519.6, 547, 574.4, 601.8, 629.2, 656.6, 684, 711.4],
						Daze = [258.1, 269.9, 281.7, 293.5, 305.3, 317.1, 328.9, 340.7, 352.5, 364.3, 376.1, 387.9, 399.7, 411.5, 423.3, 435.1]
					}
				]
			},
			new()// Special Attack: Surprise Attack
			{
				Id = "SurpriseAttack",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Special,
						DmgType = Physical,
						Dmg = [47.3, 51.6, 55.9, 60.2, 64.5, 68.8, 73.1, 77.4, 81.7, 86, 90.3, 94.6, 98.9, 103.2, 107.5, 111.8],
						Daze = [47.3, 49.5, 51.7, 53.9, 56.1, 58.3, 60.5, 62.7, 64.9, 67.1, 69.3, 71.5, 73.7, 75.9, 78.1, 80.3]
					}
				]
			},
			new()// EX Special Attack: Super Surprise Attack!
			{
				Id = "SuperSurpriseAttack",
				Category = Special,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Physical,
						Dmg = [539.7, 588.8, 637.9, 687.0, 736.1, 785.2, 834.3, 883.4, 932.5, 981.6, 1030.7, 1079.8, 1128.9, 1178.0, 1227.1, 1276.2],
						Daze = [455.4, 476.1, 496.8, 517.5, 538.2, 558.9, 579.6, 600.3, 621.0, 641.7, 662.4, 683.1, 703.8, 724.5, 745.2, 765.9]
					}
				]
			},
			new()// Chain Attack: Claw Swipe
			{
				Id = "ClawSwipe",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Physical,
						Dmg = [536.2, 585.0, 633.8, 682.6, 731.4, 780.2, 829.0, 877.8, 926.6, 975.4, 1024.2, 1073.0, 1121.8, 1170.6, 1219.4, 1268.2],
						Daze = [159.2, 166.5, 173.8, 181.1, 188.4, 195.7, 203.0, 210.3, 217.6, 224.9, 232.2, 239.5, 246.8, 254.1, 261.4, 268.7]
					}
				]
			},
			new()// Ultimate: Claw Smash
			{
				Id = "ClawSmash",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Physical,
						Dmg = [1571.1, 1714.0, 1856.9, 1999.8, 2142.7, 2285.6, 2428.5, 2571.4, 2714.3, 2857.2, 3000.1, 3143.0, 3285.9, 3428.8, 3571.7, 3714.6],
						Daze = [118.1, 123.5, 128.9, 134.3, 139.7, 145.1, 150.5, 155.9, 161.3, 166.7, 172.1, 177.5, 182.9, 188.3, 193.7, 199.1]
					}
				]
			}
		],
		Cinemas =
		{
			[1] = new BuffInfo
			{
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = PhysicalRes, Type = Combat, Value = 16
				}
			},
			[2] = new BuffInfo
			{
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = EnergyRegen, Type = CombatPercent, Value = 25
				}
			},
			[4] = new BuffInfo
			{
				Type = Stack,
				Stacks = 2,
				Modifiers = new StatModifier
				{
					Stat = CritRate, Type = Combat, Value = 7
				}
			},
			[6] = new BuffInfo
			{
				Type = Stack,
				Stacks = 3,
				Modifiers = new StatModifier
				{
					Stat = CritDmg, Type = Combat, Value = 18
				}
			},
		}
	};
}