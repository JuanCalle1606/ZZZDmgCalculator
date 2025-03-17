namespace ZZZDmgCalculator.Models.Info;

using System.Text.Json.Serialization;
using Enum;
using Services;
using Extensions;
using ZZZ.ApiModels;
using static Enum.Anomalies;
using static Enum.Attributes;
using static ZZZ.ApiModels.Skills;

public class AgentInfo : BaseInfo<Agents> {

	public required Attributes Attribute { get; set; }

	public required Factions Faction { get; set; }

	public required Specialties Specialty { get; set; }

	public required AttackTypes AttackType { get; set; }

	public required DodgeTypes DodgeType { get; set; }

	public required AgentRank Rank { get; set; }

	[JsonIgnore]
	public required Func<AgentInfo, AgentInfo, bool> AdditionalCondition { get; set; }

	public required StatModifier[] CoreStats { get; set; }

	/**
	 * 0: Atk
	 * 1: Hp
	 * 2: Def
	 */
	public required double[][] BaseStats { get; set; } = [];

	/**
	 * 0: Pen Ratio
	 * 1: Impact
	 * 2: Proficiency
	 * 3: Mastery
	 * 4: Energy
	 */
	public required double[] FinalStats { get; set; }

	public SingleList<BuffInfo> CoreBuff { get; set; } = [];

	public SingleList<BuffInfo> AdditionalBuff { get; set; } = [];

	public List<AbilityInfo> Abilities { get; set; } = [];

	public Dictionary<int, AbilityInfo> Cinemas { get; set; } = [];

	public IReadOnlyList<Attributes> DmgTypes { get; private set; } = null!;

	public override void PostLoad(LangService lang) {
		DmgTypes = Abilities.SelectMany(a => a.Skills).Select(a => a.DmgType).Distinct().ToList().AsReadOnly();

		for (var i = 0; i < CoreBuff.Count; i++)
		{
			var buffInfo = CoreBuff[i];
			buffInfo.Id = $"Buffs.Agents.{Id}.Core.{i}";
			buffInfo.DisplayName = lang[$"Buffs.Agents.{Id}.Core"];
			buffInfo.Description = lang[buffInfo.Id];
		}

		for (var i = 0; i < AdditionalBuff.Count; i++)
		{
			var buffInfo = AdditionalBuff[i];
			buffInfo.Id = $"Buffs.Agents.{Id}.Additional.{i}";
			buffInfo.DisplayName = lang[$"Buffs.Agents.{Id}.Additional"];
			buffInfo.Description = lang[buffInfo.Id];
		}

		foreach (var (index, value) in Cinemas)
		{
			for (var i = 0; i < value.Buffs.Count; i++)
			{
				var buffInfo = value.Buffs[i];
				buffInfo.Id = $"Buffs.Agents.{Id}.Cinema{index}.{i}";
				buffInfo.DisplayName = lang[$"Buffs.Agents.{Id}.Cinema{index}"];
				buffInfo.Description = lang[buffInfo.Id];
			}
		}

		AssignAbilities(lang);

		AddAnomalyAbilities(lang);
	}

	void AddAnomalyAbilities(LangService lang) {
		switch (Attribute)
		{
			case Physical:
				Abilities.Add(new()
				{
					Id = nameof(Assault),// TODO: need more checks after adding physical agents
					DisplayName = lang[Assault],
					Category = Anomaly,
					Skills = new SkillInfo
					{
						Id = nameof(Assault),
						DmgType = Physical,
						Type = Anomaly,
						Dmg = [Container[Assault].DmgMultiplier]
					}
				});
				break;
			case Fire:
				Abilities.Add(new()
				{
					Id = nameof(Burn),// checked
					DisplayName = lang[Burn],
					Category = Anomaly,
					Skills =
					[
						new SkillInfo
						{
							Id = nameof(Burn),
							DisplayName = lang["Total"],
							DmgType = Fire,
							Type = Anomaly,
							Dmg = [Container[Burn].DmgMultiplier]
						},
						new SkillInfo
						{
							Id = nameof(Burn) + ".Tick",
							DisplayName = lang["Tick"],
							DmgType = Fire,
							Type = Anomaly,
							Dmg = [Container[BurnTick].DmgMultiplier]
						}
					]
				});
				break;
			case Ice:
				Abilities.Add(new()
				{
					Id = nameof(Shatter),// checked
					DisplayName = lang[Shatter],
					Category = Anomaly,
					Skills = new SkillInfo
					{
						Id = nameof(Shatter),
						DmgType = Ice,
						Type = Anomaly,
						Dmg = [Container[Shatter].DmgMultiplier]
					}
				});
				break;
			case Electric:
				Abilities.Add(new()
				{
					Id = nameof(Shock),// checked
					DisplayName = lang[Shock],
					Category = Anomaly,
					Skills =
					[
						new SkillInfo
						{
							Id = nameof(Shock),
							DisplayName = lang["Total"],
							DmgType = Electric,
							Type = Anomaly,
							Dmg = [Container[Shock].DmgMultiplier]
						},
						new SkillInfo
						{
							Id = nameof(Shock) + ".Tick",
							DisplayName = lang["Tick"],
							DmgType = Electric,
							Type = Anomaly,
							Dmg = [Container[ShockTick].DmgMultiplier]
						}
					]
				});
				break;
			case Ether:
				Abilities.Add(new()
				{
					Id = nameof(Corruption),// todo: need more checks, incorrect numbers with nicole
					DisplayName = lang[Corruption],
					Category = Anomaly,
					Skills =
					[
						new SkillInfo
						{
							Id = nameof(Corruption),
							DisplayName = lang["Total"],
							DmgType = Ether,
							Type = Anomaly,
							Dmg = [Container[Corruption].DmgMultiplier]
						},
						new SkillInfo
						{
							Id = nameof(Corruption) + ".Tick",
							DisplayName = lang["Tick"],
							DmgType = Ether,
							Type = Anomaly,
							Dmg = [Container[CorruptionTick].DmgMultiplier]
						}
					]
				});
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		// Add disorder skill
		Abilities.Add(new()
		{
			Id = nameof(Disorder),
			DisplayName = lang[Disorder],
			Category = Anomaly,
			Skills = GetDisorderSkills(lang)
		});
	}
	
	SingleList<SkillInfo> GetDisorderSkills(LangService lang) {
		var dev = new SingleList<SkillInfo>();
		var anomalyInfo = Container[Attribute switch
		{
			Physical => Assault,
			Fire => Burn,
			Ice => Shatter,
			Electric => Shock,
			Ether => Corruption,
			_ => throw new ArgumentOutOfRangeException()
		}];
		
		for (var i = 0; i < 10; i++)
		{
			dev.Add(new()
			{
				Id = nameof(Disorder) + i,
				DisplayName = lang[$"Skills.Abilities.Common.Disorder.{i}"],
				DmgType = Attribute,
				Type = Disorder,
				Dmg = [450 + (9-i) * anomalyInfo.DisorderFactor * anomalyInfo.DisorderMultiplier]
			});
		}
		return dev;
	}
	
	void AssignAbilities(LangService lang) {
		foreach (var ability in Abilities)
		{
			var id = "Abilities.Agents." + Id + "." + ability.Id;
			ability.DisplayName = lang[id];
			//ability.Description = lang[ability.Id + ".Desc"];

			for (var i = 0; i < ability.Buffs.Count; i++)
			{
				var buffInfo = ability.Buffs[i];
				buffInfo.Id = $"Buffs.Abilities.{Id}.{ability.Id}.{i}";
				buffInfo.DisplayName = lang[id];
				buffInfo.Description = lang[buffInfo.Id];
			}
			if (ability.Skills.Count > 1)
			{
				for (var i = 0; i < ability.Skills.Count; i++)
				{
					var skillInfo = ability.Skills[i];
					skillInfo.Index = i;
					skillInfo.Id = $"Skills.Abilities.{Id}.{ability.Id}.{i}";
					skillInfo.Ability = ability.Id;
					if (ability.UseCommonNames && i < ability.MaxCommonName)
					{
						skillInfo.DisplayName = lang[$"Skills.Abilities.Common.Combo.{i}"];
					}
					else if (skillInfo.Dmg is null && skillInfo.Daze is not null)
					{
						// all parries have the same name
						skillInfo.DisplayName = lang[$"Skills.Abilities.Common.Parry.{i}"];
					}
					else
					{
						skillInfo.DisplayName = lang[skillInfo.Id];
					}
				}
			}
			else if (ability.Skills.Count == 1)
			{
				ability.Skills[0].Index = 0;
				ability.Skills[0].Id = $"Skills.Abilities.{Id}.{ability.Id}.0";
				ability.Skills[0].Ability = ability.Id;
			}
		}
	}
}