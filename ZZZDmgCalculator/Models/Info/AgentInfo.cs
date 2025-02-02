namespace ZZZDmgCalculator.Models.Info;

using System.Text.Json.Serialization;
using Enum;
using Services;
using Extensions;
using ZZZ.ApiModels;

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

	public override void PostLoad(LangService lang) {
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
			
			for (var i = 0; i < ability.Skills.Count; i++)
			{
				var buffInfo = ability.Skills[i];
				buffInfo.Id = $"Skills.Abilities.{Id}.{ability.Id}.{i}";
				buffInfo.DisplayName = lang[buffInfo.Id]; 
			}
		}
	}
}