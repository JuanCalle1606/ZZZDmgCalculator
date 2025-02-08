namespace ZZZDmgCalculator.Models.State;

using Abstractions;
using Enum;
using Info;

public class AbilityState : IBuffContainer {
	public AbilityInfo Info { get; }
	
	public AgentState Owner { get; set; }

	public SkillState[] Skills { get; }
	
	public BuffSource Source => BuffSource.Agent;

	public List<BuffState> Buffs { get; }

	public EntityState Stats { get; }

	readonly List<BuffState> _buffs = [];

	readonly List<BuffState> _appliedBuffs = [];

	public AbilityState(AbilityInfo info, AgentState owner) {
		Info = info;
		Owner = owner;
		Stats = new()
		{
			Parent = owner.Stats
		};

		Skills = Info.Skills.Select(s => new SkillState(s, Stats, owner)).ToArray();
		
		Buffs = Info.Buffs.Select(b => new BuffState(b)
		{
			Owner = owner,
			SourceInfo = owner.Info,
			DependencyChecker = owner
		}).ToList();
	}

	/// <summary>
	/// Check if the buffs have changed and update the stats accordingly.
	/// </summary>
	public void UpdateBuffs() {
		UpdateBuffsCore();
		CheckBuffs();
	}
	
	void UpdateBuffsCore() {
		var buffs = Owner.ListConditionalBuffs();
		if (buffs.SequenceEqual(_buffs))
		{
			return;
		}
		_buffs.Clear();
		_buffs.AddRange(buffs);
		_appliedBuffs.Clear();
		if (_buffs.Count == 0)
		{
			return;
		}
		
		var abilityMeet = _buffs.Where(b => b.Info.SkillCondition is null && b.Info.AbilityCondition!(Info));
		var allSkillsMeet = _buffs.Where(b => b.Info.AbilityCondition is null && Info.Skills.All(s => b.Info.SkillCondition!(s)));
		
		_appliedBuffs.AddRange(abilityMeet.Concat(allSkillsMeet).Distinct());
		
		var missingSkills = _buffs.Where(b => b.Info.SkillCondition is not null).Except(_appliedBuffs).ToList();

		foreach (var skill in Skills)
		{
			skill.UpdateBuffs(missingSkills);
		}
	}
	
	/// <summary>
	/// Apply the modifiers from the active buffs.
	/// </summary>
	public void CheckBuffs() {
		Stats.Reset();
		ApplyModifiers(_appliedBuffs.Where(b => b is { Available: true, Active: true }), Stats, Owner);
		Stats.Update();
		foreach (var skill in Skills)
		{
			skill.CheckBuffs();
		}
	}

	public static void ApplyModifiers(IEnumerable<BuffState> allBuffs, EntityState stats, AgentState owner) {
		var mods = allBuffs.SelectMany(b => {
				if (b.Shared && b.Owner != owner)
					return b.Modifiers.Where(m => m.Shared);
				if (b.Info.Pass && b.AppliedTo != owner)
					return [];
				return b.Modifiers;
			})
			.Where(m => m is { Enemy: false, Agent: false });
		foreach (var mod in mods)
		{
			stats.ApplyModifier(mod);
		}
	}
	
}