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
	ElectricDmg = 25, //b
	EtherDmg,
	FireDmg,
	IceDmg,
	PhysicalDmg, //e
	
	// Unique buffs	stats
	ShieldPower = 35, //b
	Daze,
	BuildUp,
	BonusDmg, //e
	
	// special anomaly stats, this stats are hidden by default unless theis value is not 0, these are increased by specific agents or skills.
	// for example jane core skill add physical anomaly crit rate and crit dmg.
	ElectricCritDmg = 50, //b
	ElectricCritRate,
	EtherCritDmg,
	EtherCritRate,
	FireCritDmg,
	FireCritRate,
	IceCritDmg,
	IceCritRate,
	PhysicalCritDmg,
	PhysicalCritRate, //e
	
	// special stats, these are also hidden by default, but they are increased by specific agents or skills.
	// also these stats can be modified for enemies.
	DmgTaken = 75,
	DmgReduction,
	StunDmg,
	DmgRes,
	ElectricRes,
	EtherRes,
	FireRes,
	IceRes,
	PhysicalRes,
}