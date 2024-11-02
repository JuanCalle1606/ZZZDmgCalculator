namespace ZZZDmgCalculator.Models.State;

using System.Text.Json.Serialization;
using Abstractions;
using Enum;
using Info;
using Json;

[JsonConverter(typeof(EngineSerializer))]
public class EngineState : IModifierContainer, IBuffContainer, IBuffDependencyChecker {

	AscensionState _ascension = AscensionState.A0_10;
	int _refinement = 1;

	bool _weaponEnabled = true;

	public AscensionState Ascension
	{
		get => _ascension;
		set
		{
			_ascension = value;
			Update();
		}
	}

	public int Refinement
	{
		get => _refinement;
		set
		{
			_refinement = Math.Clamp(value, 1, 5);
			Update(true);
		}
	}

	public StatModifier MainStat { get; }

	public StatModifier SubStat { get; }

	public IList<StatModifier> Modifiers { get; }
	
	public BuffSource Source => BuffSource.Engine;

	public List<BuffState> Buffs { get; }
	
	public EngineInfo Info { get; }

	public bool Disabled => !_weaponEnabled;

	public EngineState(EngineInfo engineInfo) {
		Info = engineInfo;
		MainStat = Info.MainStat.WithValue(Info.MainStats[0]);
		SubStat = Info.SubStat.WithValue(Info.SubStats[0]);
		Modifiers = new List<StatModifier> { MainStat, SubStat };
		
		Buffs = Info.Passives.Select(x => new BuffState(x)
		{
			SourceInfo = Info,
			DependencyChecker = this
		}).ToList();
	}
	
	public void CheckDependencies(bool available = true) {
	
		_weaponEnabled = available;
		foreach (var buff in Buffs)
		{
			CheckBuffDependencies(buff);
		}
	}

	void Update(bool refinement = false) {
		if (refinement)
		{
			foreach (var buff in Buffs)
			{
				buff.Scale = _refinement - 1;
			}
		}
		else
		{
			// the ascension has changed, we need to update the stats.
			MainStat.Value = Info.MainStats[(int)_ascension];
			SubStat.Value = Info.SubStats[(int)_ascension];
		}
	}

	public void CheckBuffDependencies(BuffState buff) {
		buff.Available = _weaponEnabled;
		if (!buff.HasDependencies || !_weaponEnabled) return;
		var depends = buff.Info.Depends!.Value;
		var dependency = Buffs[depends];
		buff.Dependency = dependency;
		var requiredStacks = buff.Info.RequiredStacks ?? dependency.MaxStacks;
			
		if(!dependency.Available || !dependency.Active || (dependency.Info.Type == BuffTrigger.Stack && dependency.Stacks < requiredStacks))
		{
			buff.Available = false;
		}
	}
	
	public void UpdateOwner(AgentState agentState) {
		foreach (var buff in Buffs)
		{
			buff.Owner = agentState;
		}
	}
}