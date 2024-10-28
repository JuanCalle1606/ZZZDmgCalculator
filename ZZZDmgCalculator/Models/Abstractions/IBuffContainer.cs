namespace ZZZDmgCalculator.Models.Abstractions;

using Enum;
using State;

public interface IBuffContainer {
	private readonly static IEnumerable<IBuffContainer> NoChildren = new List<IBuffContainer>().AsReadOnly();
	
	public BuffSource Source { get; }
	
	public IEnumerable<IBuffContainer> Children => NoChildren;
	
	/**
	 * This is a list of all the buffs this source can provide despite being enabled or not.
	 *
	 * For example an engine expose here its passives even if the agent is not of the same specialty.
	 */
	public List<BuffState> Buffs { get; }

	public IBuffContainer? SharedContainer => null;

	public IEnumerable<BuffState> SelfBuffs => Buffs.Concat(Children.SelectMany(child => child.AllBuffs));
	
	public IEnumerable<BuffState> AllBuffs => SelfBuffs
		// Concatenate the shared buffs if any
		.Concat(SharedContainer?.AllBuffs ?? [])
		// If this container is shared, we don't want to include the shared buffs twice
		.Distinct()
		// If there still multiples buff with the same id, we keep only one
		.GroupBy(buff => buff.Info.Id)
		.Select(group => group.FirstOrDefault(b=>b is { Available: true, Active: true }) ?? group.First());

}