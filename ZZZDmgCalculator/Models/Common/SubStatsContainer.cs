namespace ZZZDmgCalculator.Models.Common;

using System.Collections;
using Abstractions;
using Info;
using State;

public class SubStatsContainer : IModifierContainer, IEnumerable<DiscStatInfo> {
	const int MaxSubStats = 4;
	readonly List<DiscStatInfo> _subStats = new(MaxSubStats);
	readonly List<int> _subStatRolls = new(MaxSubStats);
	readonly DiscState _disc;

	public IList<StatModifier> Modifiers { get; } = new List<StatModifier>(MaxSubStats);

	public SubStatRolls Rolls { get; }

	public SubStatsContainer(DiscState disc) {
		Rolls = new(this);
		_disc = disc;
	}

	public DiscStatInfo? this[int index] => index < _subStats.Count ? _subStats[index] : null;

	public int Count => _subStats.Count;
	
	public bool Contains(DiscStatInfo stat) => _subStats.Contains(stat);

	public void Add(DiscStatInfo stat, int initialRoll = 0) {
		if (_subStats.Count >= MaxSubStats || _subStats.Contains(stat))
		{
			return;
		}
		_subStatRolls.Add(initialRoll);
		_subStats.Add(stat);
		Modifiers.Add(stat.Buff.WithValue(stat.SubScales![(int)_disc.Rank] * (initialRoll + 1)));
	}
	
	public void Update() {
		for (var i = 0; i < _subStats.Count; i++)
		{
			Modifiers[i].Value = _subStats[i].SubScales![(int)_disc.Rank] * (_subStatRolls[i] + 1);
		}
	}

	public class SubStatRolls(SubStatsContainer parent) {
		public int this[int index]
		{
			get => parent._subStatRolls[index];
			set
			{
				parent._subStatRolls[index] = Math.Clamp(value, 0, 5);
				parent.Modifiers[index].Value = parent._subStats[index].SubScales![(int)parent._disc.Rank] * (parent._subStatRolls[index] + 1);
			}
		}
	}
	
	public void Replace(DiscStatInfo stat, DiscStatInfo newStat) {
		var index = _subStats.IndexOf(stat);
		if (index < 0)
		{
			return;
		}
		_subStats[index] = newStat;
		Modifiers[index] = newStat.Buff.WithValue(newStat.SubScales![(int)_disc.Rank] * (_subStatRolls[index] + 1));
	}
	
	public IEnumerator<DiscStatInfo> GetEnumerator() => _subStats.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_subStats).GetEnumerator();
}