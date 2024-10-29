namespace ZZZDmgCalculator.Data.Agents;

using Models.Enum;
using Models.Info;
using static AgentScales;
using static Models.Enum.Agents;
using static Models.Enum.AttackTypes;
using static Models.Enum.Attributes;
using static Models.Enum.Factions;
using static Models.Enum.Skills;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static Models.Info.DodgeTypes;

[InfoData<Agents>(Anby)]
public class AnbyData {
	public readonly static AgentInfo Data = new()
	{
		Id = nameof(Anby),
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
		// TODO: Add core buff for Anby when app support daze calculation
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
						Scales = [31.2, 34.1, 37.0, 39.9, 42.8, 45.7, 48.6, 51.5, 54.4, 57.3, 60.2, 63.1, 66.0, 68.9, 71.8, 74.7]
					},
					new()// 2nd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [33.7, 36.8, 39.9, 43.0, 46.1, 49.2, 52.3, 55.4, 58.5, 61.6, 64.7, 67.8, 70.9, 74.0, 77.1, 80.2]
					},
					new()// 3rd-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [113.6, 124.0, 134.4, 144.8, 155.2, 165.6, 176.0, 186.4, 196.8, 207.2, 217.6, 228.0, 238.4, 248.8, 259.2, 269.6]
					},
					new()// 4th-Hit DMG Multiplier (%)
					{
						Type = Basic,
						DmgType = Physical,
						Scales = [239.1, 260.9, 282.7, 304.5, 326.3, 348.1, 369.9, 391.7, 413.5, 435.3, 457.1, 478.9, 500.7, 522.5, 544.3, 566.1]
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
						Scales = [328.6, 358.5, 388.4, 418.3, 448.2, 478.1, 508.0, 537.9, 567.8, 597.7, 627.6, 657.5, 687.4, 717.3, 747.2, 777.1]
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
						Scales = [56.7, 61.9, 67.1, 72.3, 77.5, 82.7, 87.9, 93.1, 98.3, 103.5, 108.7, 113.9, 119.1, 124.3, 129.5, 134.7]
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
						Scales = [180.2, 196.6, 213, 229.4, 245.8, 262.2, 278.6, 295, 311.4, 327.8, 344.2, 360.6, 377, 393.4, 409.8, 426.2]
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
						Scales = [61.7, 67.4, 73.1, 78.8, 84.5, 90.2, 95.9, 101.6, 107.3, 113, 118.7, 124.4, 130.1, 135.8, 141.5, 147.2]
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
						Scales = [335.2, 365.7, 396.2, 426.7, 457.2, 487.7, 518.2, 548.7, 579.2, 609.7, 640.2, 670.7, 701.2, 731.7, 762.2, 792.7]
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
						Scales = [93.4, 101.9, 110.4, 118.9, 127.4, 135.9, 144.4, 152.9, 161.4, 169.9, 178.4, 186.9, 195.4, 203.9, 212.4, 220.9]
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
						Scales = [583, 636, 689, 742, 795, 848, 901, 954, 1007, 1060, 1113, 1166, 1219, 1272, 1325, 1431]
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
						Scales = [542.4, 591.8, 641.2, 690.6, 740.0, 789.4, 838.8, 888.2, 937.6, 987.0, 1036.4, 1085.8, 1135.2, 1184.6, 1234.0, 1283.4]
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
						Scales = [1512.6, 1649.2, 1785.8, 1922.4, 2059, 2195.6, 2332.2, 2468.8, 2605.4, 2742, 2878.6, 3015.2, 3151.8, 3288.4, 3425, 3561.6]
					}
				]
			}
		],
		Cinema =
		{
			[1] = new StatModifier { Stat = EnergyRegen, Value = 12, Type = CombatPercent},
			[2] = new BuffInfo{
				// anby's cinema 2 only applies to thunderbolt
				AbilityCondition = skill => skill.Id == "Basic.Thunderbolt",
				Modifiers = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 30 }
			},
			[6] = new BuffInfo
			{
				SkillCondition = skill => skill.Type is Basic or Dash,
				Modifiers = new StatModifier { Stat = BonusDmg, Type = Combat, Value = 45 }
			}
		}
	};
}