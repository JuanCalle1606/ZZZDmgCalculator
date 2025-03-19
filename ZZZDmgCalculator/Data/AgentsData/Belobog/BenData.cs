namespace ZZZDmgCalculator.Data.AgentsData.Belobog;

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

[InfoData<Agents>(Ben)]
public class BenData {
	public readonly static AgentInfo Data = new()
	{
		Uid = Ben,
		Icon = "Ben_Bigger",
		Attribute = Fire,
		Faction = Belobog,
		Specialty = Defense,
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
			Templates["Ben.Atk"],
			Templates["Ben.Hp"],
			Templates["Ben.Def"],
		],
		FinalStats = [0, 95, 90, 86, 1.2],
		CoreBuff = new BuffInfo
		{
			// todo: calculate shield
		},
		AdditionalBuff = new BuffInfo
		{
			Modifiers = new StatModifier
			{
				Stat = CritRate,
				Type = Combat,
				Value = 16,
				Shared = true// todo: allow choosing between enabling/disabling for each agent
			}
		},
		Abilities =
		[// TODO: look for physical damage
			new()// Basic Attack: Debt Reconciliation
			{
				Id = "DebtReconciliation",
				Category = Basic,
				UseCommonNames = true,
				Skills =
				[
					new()// 1st-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Dmg = [65.9, 71.9, 77.9, 83.9, 89.9, 95.9, 101.9, 107.9, 113.9, 119.9, 125.9, 131.9, 137.9, 143.9, 149.9, 155.9],
						Daze = [47.1, 49.3, 51.5, 53.7, 55.9, 58.1, 60.3, 62.5, 64.7, 66.9, 69.1, 71.3, 73.5, 75.7, 77.9, 80.1]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Dmg = [189, 206.2, 223.4, 240.6, 257.8, 275, 292.2, 309.4, 326.6, 343.8, 361, 378.2, 395.4, 412.6, 429.8, 447],
						Daze = [156.9, 164.1, 171.3, 178.5, 185.7, 192.9, 200.1, 207.3, 214.5, 221.7, 228.9, 236.1, 243.3, 250.5, 257.7, 264.9]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Fire,
						Dmg = [348.3, 380, 411.7, 443.4, 475.1, 506.8, 538.5, 570.2, 601.9, 633.6, 665.3, 697, 728.7, 760.4, 792.1, 823.8],
						Daze = [260.1, 272, 283.9, 295.8, 307.7, 319.6, 331.5, 343.4, 355.3, 367.2, 379.1, 391, 402.9, 414.8, 426.7, 438.6]
					}
				]
			},
			new()// Dash Attack: Incoming Expense
			{
				Id = "IncomingExpense",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dash,
						DmgType = Fire,
						Dmg = [138.4, 151, 163.6, 176.2, 188.8, 201.4, 214, 226.6, 239.2, 251.8, 264.4, 277, 289.6, 302.2, 314.8, 327.4],
						Daze = [69.2, 72.4, 75.6, 78.8, 82, 85.2, 88.4, 91.6, 94.8, 98, 101.2, 104.4, 107.6, 110.8, 114, 117.2]
					}
				]
			},
			new()// Dodge Counter: Accounts Settled
			{
				Id = "AccountsSettled",
				Category = Dodge,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Dodge,
						DmgType = Fire,
						Dmg = [225.7, 246.3, 266.9, 287.5, 308.1, 328.7, 349.3, 369.9, 390.5, 411.1, 431.7, 452.3, 472.9, 493.5, 514.1, 534.7],
						Daze = [196.7, 205.7, 214.7, 223.7, 232.7, 241.7, 250.7, 259.7, 268.7, 277.7, 286.7, 295.7, 304.7, 313.7, 322.7, 331.7]
					}
				]
			},
			new()// Quick Assist: Joint Account
			{
				Id = "JointAccount",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Quick,
						DmgType = Fire,
						Dmg = [96.7, 105.5, 114.3, 123.1, 131.9, 140.7, 149.5, 158.3, 167.1, 175.9, 184.7, 193.5, 202.3, 211.1, 219.9, 228.7],
						Daze = [96.7, 101.1, 105.5, 109.9, 114.3, 118.7, 123.1, 127.5, 131.9, 136.3, 140.7, 145.1, 149.5, 153.9, 158.3, 162.7]
					}
				]
			},
			new()// Defensive Assist: Risk Allocation
			{
				Id = "RiskAllocation",
				Category = Assist,
				Skills =
				[
					new()// Light Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [225.1, 235.4, 245.7, 256.0, 266.3, 276.6, 286.9, 297.2, 307.5, 317.8, 328.1, 338.4, 348.7, 359.0, 369.3, 379.6]
					},
					new()// Heavy Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [268.4, 280.6, 292.8, 305.0, 317.2, 329.4, 341.6, 353.8, 366.0, 378.2, 390.4, 402.6, 414.8, 427.0, 439.2, 451.4]
					},
					new()// Chain Defensive Daze Multiplier (%)
					{
						Type = Assist,
						Daze = [108.4, 113.4, 118.4, 123.4, 128.4, 133.4, 138.4, 143.4, 148.4, 153.4, 158.4, 163.4, 168.4, 173.4, 178.4, 183.4]
					}
				]
			},
			new()// Assist Follow-Up: Don't Break Contract
			{
				Id = "DontBreakContract",
				Category = Assist,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Assist,
						DmgType = Fire,
						Dmg = [325.9, 355.6, 385.3, 415.0, 444.7, 474.4, 504.1, 533.8, 563.5, 593.2, 622.9, 652.6, 682.3, 712.0, 741.7, 771.4],
						Daze = [282.8, 295.7, 308.6, 321.5, 334.4, 347.3, 360.2, 373.1, 386.0, 398.9, 411.8, 424.7, 437.6, 450.5, 463.4, 476.3]
					}
				]
			},
			new()// Special Attack: Fiscal Fist
			{
				Id = "FiscalFist",
				Category = Special,
				Skills =
				[
					new()// Active Attack DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [41.7, 45.5, 49.3, 53.1, 56.9, 60.7, 64.5, 68.3, 72.1, 75.9, 79.7, 83.5, 87.3, 91.1, 94.9, 98.7],
						Daze = [41.7, 43.6, 45.5, 47.4, 49.3, 51.2, 53.1, 55.0, 56.9, 58.8, 60.7, 62.6, 64.5, 66.4, 68.3, 70.2]
					},
					new()// Block Counter DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [233.4, 254.7, 276.0, 297.3, 318.6, 339.9, 361.2, 382.5, 403.8, 425.1, 446.4, 467.7, 489.0, 510.3, 531.6, 552.9],
						Daze = [223.4, 233.6, 243.8, 254.0, 264.2, 274.4, 284.6, 294.8, 305.0, 315.2, 325.4, 335.6, 345.8, 356.0, 366.2, 376.4]
					}
				]
			},
			new()// EX Special Attack: Cashflow Counter
			{
				Id = "CashflowCounter",
				Category = Special,
				Skills =
				[
					new()// Active Attack DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [438.5, 478.4, 518.3, 558.2, 598.1, 638, 677.9, 717.8, 757.7, 797.6, 837.5, 877.4, 917.3, 957.2, 997.1, 1037],
						Daze = [247.1, 258.4, 269.7, 281, 292.3, 303.6, 314.9, 326.2, 337.5, 348.8, 360.1, 371.4, 382.7, 394, 405.3, 416.6]
					},
					new()// Follow-Up Attack DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [438.5, 478.4, 518.3, 558.2, 598.1, 638, 677.9, 717.8, 757.7, 797.6, 837.5, 877.4, 917.3, 957.2, 997.1, 1037],
						Daze = [247.1, 258.4, 269.7, 281, 292.3, 303.6, 314.9, 326.2, 337.5, 348.8, 360.1, 371.4, 382.7, 394, 405.3, 416.6]
					},
					new()// Block Counter DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [500.5, 546, 591.5, 637, 682.5, 728, 773.5, 819, 864.5, 910, 955.5, 1001, 1046.5, 1092, 1137.5, 1183],
						Daze = [367.6, 384.4, 401.2, 418, 434.8, 451.6, 468.4, 485.2, 502, 518.8, 535.6, 552.4, 569.2, 586, 602.8, 619.6]
					},
					new()// Block Follow-Up DMG Multiplier (%)
					{
						Type = Ex,
						DmgType = Fire,
						Dmg = [551.2, 601.4, 651.6, 701.8, 752, 802.2, 852.4, 902.6, 952.8, 1003, 1053.2, 1103.4, 1153.6, 1203.8, 1254, 1304.2],
						Daze = [367.6, 384.4, 401.2, 418, 434.8, 451.6, 468.4, 485.2, 502, 518.8, 535.6, 552.4, 569.2, 586, 602.8, 619.6]
					}
				]
			},
			new()// Chain Attack: Signed and Sealed
			{
				Id = "SignedandSealed",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Chain,
						DmgType = Fire,
						Dmg = [627.3, 684.4, 741.5, 798.6, 855.7, 912.8, 969.9, 1027, 1084.1, 1141.2, 1198.3, 1255.4, 1312.5, 1369.6, 1426.7, 1483.8],
						Daze = [328.3, 343.3, 358.3, 373.3, 388.3, 403.3, 418.3, 433.3, 448.3, 463.3, 478.3, 493.3, 508.3, 523.3, 538.3, 553.3]
					}
				]
			},
			new()// Ultimate: Complete Payback
			{
				Id = "CompletePayback",
				Category = Ultimate,
				Skills =
				[
					new()// DMG Multiplier (%)
					{
						Type = Ultimate,
						DmgType = Fire,
						Dmg = [1643, 1792.4, 1941.8, 2091.2, 2240.6, 2390, 2539.4, 2688.8, 2838.2, 2987.6, 3137, 3286.4, 3435.8, 3585.2, 3734.6, 3884],
						Daze = [110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185]
					}
				]
			},
		],
		Cinemas =
		{
			[2] = new SkillInfo()
			{
				DmgType = Fire,// todo: check if this is correct
				Stat = Def, Value = 300
			},
			[4] = new BuffInfo
			{
				SkillCondition = skill => (skill.Type is Ex && skill.Index is 2) || (skill.Type is Special && skill.Index is 1),
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat, Value = 30
				}
			},
			[6] = new BuffInfo
			{
				SkillCondition = skill => skill.Type is Basic or Dash or Dodge,
				Modifiers = new StatModifier
				{
					Stat = Daze, Type = Combat, Value = 20
				}
			},
		}
	};
}