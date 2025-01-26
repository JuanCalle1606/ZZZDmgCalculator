namespace ZZZDmgCalculator.Models.Enum;

/// <summary>
/// Define source of a dmg instance.
/// </summary>
public enum DmgSource {
	/// <summary>
	/// Dmg comes from any attack, including normal attacks, skills, and ultimates.
	/// </summary>
	Attack,
	/// <summary>
	/// Damage comes from an anomaly.
	/// </summary>
	Anomaly,
	/// <summary>
	/// Damage is from disorder
	/// </summary>
	Disorder,
}