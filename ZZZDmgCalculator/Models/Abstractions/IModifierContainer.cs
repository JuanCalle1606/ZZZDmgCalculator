namespace ZZZDmgCalculator.Models.Abstractions;

using Info;

public interface IModifierContainer {
	
	private readonly static IEnumerable<IModifierContainer> NoChildren = new List<IModifierContainer>().AsReadOnly();
	
	public IList<StatModifier> Modifiers { get; }

	public IEnumerable<IModifierContainer> Children => NoChildren;
	
	public IEnumerable<StatModifier> AllModifiers => Modifiers.Concat(Children.SelectMany(child => child.AllModifiers));
}