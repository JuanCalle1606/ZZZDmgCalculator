namespace ZZZDmgCalculator.Models.State;

using Abstractions;
using Enum;
using Info;
using Enum=System.Enum;

public class DiscSetState(DiscInfo info, bool fullSet = false) : IModifierContainer {
	public DiscInfo Info { get; } = info;

	public Discs Disc { get; } = Enum.Parse<Discs>(info.Id);

	/**
	 * When this set has 4 pieces this instance will also provide buffs, otherwise it will only provide the stats.
	 */
	public bool FullSet { get; set; } = fullSet;
	
	public IList<StatModifier> Modifiers { get; } = [info.StatBuff.WithValue(info.StatBuff.Value)];
}