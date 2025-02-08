namespace ZZZDmgCalculator.Models.State;

using System.Text.Json.Serialization;
using Abstractions;
using Enum;
using Json;
using ZZZ.ApiModels;

[JsonConverter(typeof(SetupSerializer))]
public class SetupState : IBuffContainer {
	public string DisplayName { get; set; } = "";

	public AgentState?[] Agents { get; } = new AgentState?[3];

	public EnemyState Enemy { get; }

	public BuffSource Source => BuffSource.Shared;

	public IEnumerable<IBuffContainer> Children => Agents.Where(a => a is not null).Cast<IBuffContainer>();

	public List<BuffState> Buffs { get; } = [];

	public IEnumerable<BuffState> AllBuffs => Children.SelectMany(c => c.SelfBuffs).Where(b => b.Shared || b.Info.Pass || b.Enemy);

	public SetupState() {
		Enemy = new(this);
	}

	public AgentState? this[int currentAgentIndex]
	{
		get => Agents[currentAgentIndex]!;
		set
		{
			if (Agents[currentAgentIndex] is {} current)
			{
				foreach (var buff in AllBuffs.Where(b => b.AppliedTo == current))
				{
					buff.AppliedTo = null;
				}
				current.SharedContainer = null;
			}
			Agents[currentAgentIndex] = value;
			if (value != null)
			{
				value.SharedContainer = this;
				foreach (var skill in value.Abilities.SelectMany(a=>a.Value).SelectMany(a=>a.Skills))
				{
					skill.Target = Enemy;
					skill.UpdateValues();
				}
			}

			foreach (var agent in Agents.Where(a => a is not null))
			{
				agent!.SetAdditionalStatus(
				Agents.Any(a => a is not null && a != agent && agent.Info.AdditionalCondition(agent.Info, a.Info))
				);
			}
		}
	}
}