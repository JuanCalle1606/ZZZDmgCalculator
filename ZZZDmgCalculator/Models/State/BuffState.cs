namespace ZZZDmgCalculator.Models.State;

using Abstractions;
using Enum;
using Info;

public class BuffState : IModifierContainer {
	int _stacks;

	int _scale;

	/**
	 * Get if this buff is available to be used.
	 *
	 * If the buff is not available, it will be hidden.
	 */
	public bool Available { get; set; } = true;

	public bool Enabled { get; set; }

	public int Stacks
	{
		get => _stacks;
		set
		{
			_stacks = Math.Clamp(value, 0, Info.Stacks);
			Update();
		}
	}

	/**
	 * The scale of the buff, this is used to calculate the value of the buff.
	 */
	public int Scale
	{
		get => _scale;
		set
		{
			_scale = value;
			Update();
		}
	}

	public int MaxStacks => Info.Stacks;

	public int ValueMultiplier => Info.Type switch { BuffTrigger.Stack => _stacks, _ => 1 };

	public bool Active => Info.Type switch { BuffTrigger.Stack => Stacks > 0, BuffTrigger.Switch => Enabled, _ => true };

	public bool IsScaling => Info.Scales is not null;

	public bool Shared => Info.Modifiers.Any(m => m.Shared);

	public bool HasDependencies => Info.Depends is not null;

	public BuffInfo Info { get; }

	public BaseInfo? SourceInfo { get; set; }

	public IList<StatModifier> Modifiers { get; }

	public double[]? ValuePerStack { get; private set; }

	public BuffState? Dependency { get; set; }

	public IBuffDependencyChecker? DependencyChecker { get; set; }

	public AgentState Owner { get; set; } = null!;

	public BuffState(BuffInfo info) {
		Info = info;

		Modifiers = Info.Modifiers.Select(i => i.WithValue(i.Value)).ToList();
		Update();
	}

	public void Update() {
		ValuePerStack ??= new double[Modifiers.Count];
		foreach (var ((current, source), index) in Modifiers.Where(m => m.NotDummy).Zip(Info.Modifiers).Select((d, i) => (d, i)))
		{
			double value;
			if (Info.Scales is not null && source.Value == 0)
			{
				// When buff have multiple modifiers but only 1 scale all modifiers use that scale
				var scaleIndex = Info.Scales.Length > 1 ? index : 0;
				// If the buff is scaling, we need to get the correct value from the scale.
				var scales = Info.Scales[scaleIndex]!;
				value = scales[Scale];
			}
			else
			{
				value = source.Value;
			}
			ValuePerStack[index] = value;
			current.Value = value * ValueMultiplier;
		}
	}
}