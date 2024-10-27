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
	
	public IEnumerable<BuffState> AllBuffs => Buffs.Concat(Children.SelectMany(child => child.AllBuffs));

}