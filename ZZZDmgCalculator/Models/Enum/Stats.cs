namespace ZZZDmgCalculator.Models.Enum;

/// <summary>
/// Stats enum, contains all the stats that can be modified by engines, skills, discs, etc.
/// </summary>

public enum Stats {
	// Base stats
	Atk, //b
	Hp,
	Def,
	Impact,
	CritRate,
	CritDmg,
	PenRatio,
	Pen,
	EnergyRegen,
	Proficiency,
	Mastery, //e
	
	// Bonus damage stats
	ElectricDmg, //b
	EtherDmg,
	FireDmg,
	IceDmg,
	PhysicalDmg,
	ElectricCritDmg,
	ElectricCritRate,
	EtherCritDmg,
	EtherCritRate,
	FireCritDmg,
	FireCritRate,
	IceCritDmg,
	IceCritRate,
	PhysicalCritDmg,
	PhysicalCritRate, //e
	
	// Unique buffs	stats
	ShieldPower, //b
	Daze,
	BasicDmg,
	SpecialDmg,
	DodgeDmg,
	UltimateDmg,
	AssistDmg,
	ExDmg,
	DashDmg,
	ChainDmg,
	QuickDmg,
	BonusDmg, //e
	
	// special anomaly stats, these are increased by specific agents or skills.
	// for example jane core skill add physical anomaly crit rate and crit dmg.
	BuildUp, //b
	AssaultBuildUp,
	FreezeBuildUp,
	CorruptionBuildUp,
	BurnBuildUp,
	ShockBuildUp,
	FrostburnBuildUp,
	AssaultDmg,
	FreezeDmg,
	CorruptionDmg,
	BurnDmg,
	ShockDmg,
	FrostburnDmg,
	// Crit stats on anomaly is only applied by jane, maybe add stats for other anomalies later.
	AssaultCritRate,
	AssaultCritDmg,
	AnomalyDmg, // Bonus dmg to any anomaly
	DisorderDmg, //e
	
	// enemy resistance stats
	DmgRes, //b
	BuildUpRes,
	AssaultBuildUpRes,
	FreezeBuildUpRes,
	CorruptionBuildUpRes,
	BurnBuildUpRes,
	ShockBuildUpRes,
	FrostburnBuildUpRes,
	ElectricRes,
	EtherRes,
	FireRes,
	IceRes,
	PhysicalRes, //e
	
	// special stats, these are also hidden by default, but they are increased by specific agents or skills.
	// also these stats can be modified for enemies.
	DmgTaken,
	DmgReduction,
	StunDmg,
}