namespace ZZZDmgCalculator.Models.State;

using Abstractions;
using Common;
using Enum;
using Info;
using Enum=System.Enum;

/**
 * Represents the state of a disc.
 * This class is used to calculate the stats of a disc.
 * Only tha main stats and sub stats are stored here, the buffs from sets are stored in <see cref="DiscSetState"/>.
 */
public class DiscState : IModifierContainer {

	DiscStatInfo _mainStat = null!;
	StatModifier _mainStatModifier = null!;
	ItemRank _rank = ItemRank.S;
	int _level = 0;

	public Discs Disc { get; }

	public DiscInfo Info { get; }

	/// <summary>
	/// From 0 to 15.
	/// </summary>
	public int Level
	{
		get => _level;
		set
		{
			_level = Math.Clamp(value, 0, MaxLevel);
			_mainStatModifier.Value = _mainStat.MainScales![(int)_rank][_level];
		}
	}

	public ItemRank Rank
	{
		get => _rank;
		set
		{
			_rank = value;
			// Clamp level to the new rank, this is needed because the level cap changes with the rank.
			// this set also updates the main stat modifier.
			Level = _level;
			SubStats.Update();
		}
	}

	public Stats MainStat => _mainStat.Buff.Stat;

	public IList<StatModifier> Modifiers { get; }

	public SubStatsContainer SubStats { get; }

	public int MaxLevel => _rank switch
	{
		ItemRank.B => 9,
		ItemRank.A => 12,
		ItemRank.S => 15,
		_ => throw new ArgumentOutOfRangeException(nameof(_rank))
	};

	public DiscStatInfo MainStatInfo
	{
		get => _mainStat;
		set
		{
			Modifiers.Remove(_mainStatModifier);
			_mainStat = value;
			// Update the main stat modifier with the new value.
			_mainStatModifier = _mainStat.Buff.WithValue(_mainStat.MainScales![(int)_rank][_level]);
			Modifiers.Add(_mainStatModifier);
		}
	}
	
	public IEnumerable<IModifierContainer> Children { get; }

	public DiscState(DiscInfo info, DiscStatInfo mainStat) {
		Modifiers = new List<StatModifier>();
		Info = info;
		Disc = Enum.Parse<Discs>(info.Id);

		MainStatInfo = mainStat;
		SubStats = new(this);
		Children = [SubStats];
	}
}