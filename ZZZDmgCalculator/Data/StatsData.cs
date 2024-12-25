namespace ZZZDmgCalculator.Data;

using Models.Enum;
using Models.Info;
using static Models.Enum.Stats;

[InfoData<Stats>]
public class StatsData {
	public readonly static Dictionary<Stats, BaseInfo> Data = new()
	{
		[Atk] = new() { Id = nameof(Atk) },
		[Def] = new() { Id = nameof(Def) },
		[Hp] = new() { Id = nameof(Hp) },
		[CritRate] = new() { Id = nameof(CritRate) },
		[CritDmg] = new() { Id = nameof(CritDmg) },
		[Impact] = new() { Id = nameof(Impact) },
		[Pen] = new() { Id = nameof(Pen) },
		[PenRatio] = new() { Id = nameof(PenRatio) },
		[EnergyRegen] = new() { Id = nameof(EnergyRegen) },
		
		[Proficiency] = new() { Id = nameof(Proficiency) },
		[Mastery] = new() { Id = nameof(Mastery) },

		[ElectricDmg] = new() { Id = nameof(ElectricDmg) },
		[EtherDmg] = new() { Id = nameof(EtherDmg) },
		[FireDmg] = new() { Id = nameof(FireDmg) },
		[IceDmg] = new() { Id = nameof(IceDmg) },
		[PhysicalDmg] = new() { Id = nameof(PhysicalDmg) },
		
		[ShieldPower] = new() { Id = nameof(ShieldPower) },
		[Daze] = new() { Id = nameof(Daze) },
		[BuildUp] = new() { Id = nameof(BuildUp) },
		[BonusDmg] = new() { Id = nameof(BonusDmg) },

		[ElectricCritDmg] = new() { Id = nameof(ElectricCritDmg) },
		[EtherCritDmg] = new() { Id = nameof(EtherCritDmg) },
		[FireCritDmg] = new() { Id = nameof(FireCritDmg) },
		[IceCritDmg] = new() { Id = nameof(IceCritDmg) },
		[PhysicalCritDmg] = new() { Id = nameof(PhysicalCritDmg) },

		[ElectricCritRate] = new() { Id = nameof(ElectricCritRate) },
		[EtherCritRate] = new() { Id = nameof(EtherCritRate) },
		[FireCritRate] = new() { Id = nameof(FireCritRate) },
		[IceCritRate] = new() { Id = nameof(IceCritRate) },
		[PhysicalCritRate] = new() { Id = nameof(PhysicalCritRate) },
		
		[DmgTaken] = new() { Id = nameof(DmgTaken) },
		[DmgReduction] = new() { Id = nameof(DmgReduction) },
		[StunDmg] = new() { Id = nameof(StunDmg) },

		[DmgRes] = new() { Id = nameof(DmgRes) },
		[ElectricRes] = new() { Id = nameof(ElectricRes) },
		[EtherRes] = new() { Id = nameof(EtherRes) },
		[FireRes] = new() { Id = nameof(FireRes) },
		[IceRes] = new() { Id = nameof(IceRes) },
		[PhysicalRes] = new() { Id = nameof(PhysicalRes) },
	};
}