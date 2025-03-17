namespace ZZZDmgCalculator.Models.Info;

using Enum;

public class AnomalyInfo : BaseInfo<Anomalies> {
	public required double DmgMultiplier { get; set; }
	
	public Attributes Attribute { get; set; }
	
	public bool AgentScale { get; set; }

	public double DisorderMultiplier { get; set; }
	
	public int DisorderFactor { get; set; } = 1;
	
	public bool MeetAttribute(Attributes attribute) => !AgentScale && Attribute == attribute;
}