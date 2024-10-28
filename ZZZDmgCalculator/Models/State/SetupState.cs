namespace ZZZDmgCalculator.Models.State;

using System.Text.Json.Serialization;
using Abstractions;
using Enum;
using Json;

[JsonConverter(typeof(SetupSerializer))]
public class SetupState : IBuffContainer {
	public string DisplayName { get; set; } = "";

	public AgentState?[] Agents { get; set; } = new AgentState?[3];

	public EnemyState Enemy { get; set; } = new EnemyState();

	public BuffSource Source => BuffSource.Shared;

	public IEnumerable<IBuffContainer> Children => Agents.Where(a => a is not null).Cast<IBuffContainer>();

	public List<BuffState> Buffs { get; } = [];

	public IEnumerable<BuffState> AllBuffs => Children.SelectMany(c => c.SelfBuffs).Where(b => b.Shared);

	public AgentState? this[int currentAgentIndex]
	{
		get => Agents[currentAgentIndex]!;
		set
		{
			if(Agents[currentAgentIndex] is {} current)
				current.SharedContainer = null;
			Agents[currentAgentIndex] = value; 
			if(value != null)
				value.SharedContainer = this;
		}
	}
}