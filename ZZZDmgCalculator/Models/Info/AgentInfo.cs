namespace ZZZDmgCalculator.Models.Info;

using System.Text.Json.Serialization;
using Enum;
using Util;

public class AgentInfo : BaseInfo {

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

	public BuffInfo? AdditionalBuff { get; set; }

	public List<AbilityInfo> Abilities { get; set; } = [];

	public Dictionary<int, AbilityInfo> Cinema { get; set; } = new();
}