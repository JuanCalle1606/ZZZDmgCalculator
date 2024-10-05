namespace ZZZDmgCalculator.Models.Info;

using Enum;
using Services;
using Util;

public class EngineInfo : BaseInfo {
	public required Specialties Type { get; set; }

	public required ItemRank Rank { get; set; }

	public required StatModifier MainStat { get; set; }

	internal double[] MainStats { get; set; } = null!;
	
	public required StatModifier SubStat { get; set; }

	internal double[] SubStats { get; set; } = null!;

	public SingleList<BuffInfo> Passives { get; set; } = [];
	
	public SkillInfo? Skill { get; set; }

	public override void PostLoad(LangService lang) {
		for (var i = 0; i < Passives.Count; i++)
		{
			var buffInfo = Passives[i];
			buffInfo.Id = $"Buffs.Engines.{Id}.{i}";
			buffInfo.DisplayName = lang[buffInfo.Id];
			buffInfo.Description = lang[$"{buffInfo.Id}.Desc"];
		}
		if (Skill == null) return;
		Skill.DisplayName = lang[$"Skills.Engines.{Id}"];
		Skill.Description = lang[$"Skills.Engines.{Id}.Desc"];
	}
}