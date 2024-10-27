namespace ZZZDmgCalculator.Models.State;

using System.Text.Json.Serialization;
using Abstractions;
using Enum;
using Info;
using Json;

[JsonConverter(typeof(EngineSerializer))]
public class EngineState : IModifierContainer, IBuffContainer {

	AscensionState _ascension = AscensionState.A0_10;
	int _refinement = 1;

	readonly EngineInfo _info;

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
	
	public EngineState(EngineInfo engineInfo) {
		_info = engineInfo;
		MainStat = _info.MainStat.WithValue(_info.MainStats[0]);
		SubStat = _info.SubStat.WithValue(_info.SubStats[0]);
		Modifiers = new List<StatModifier> { MainStat, SubStat };
		
		Buffs = _info.Passives.Select(x => new BuffState(x)
		{
			SourceInfo = _info
		}).ToList();
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
			MainStat.Value = _info.MainStats[(int)_ascension];
			SubStat.Value = _info.SubStats[(int)_ascension];
		}
	}

	public EngineInfo Info => _info;
}