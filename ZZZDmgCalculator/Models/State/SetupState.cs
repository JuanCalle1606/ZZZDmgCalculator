namespace ZZZDmgCalculator.Models.State;

using System.Text.Json.Serialization;
using Json;

[JsonConverter(typeof(SetupSerializer))]
public class SetupState {
	public string DisplayName { get; set; } = "";
	
	public AgentState?[ ] Agents { get; set; } = new AgentState?[3];
	
	public EnemyState Enemy { get; set; } = new EnemyState();
}