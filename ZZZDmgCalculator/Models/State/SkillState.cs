namespace ZZZDmgCalculator.Models.State;

using Enum;
using Info;
using ZZZ.ApiModels;
using static Enum.Stats;

public class SkillState {
	public SkillInfo Info { get; }
	
	public EntityState Stats { get; }
	
	public AgentState Owner { get; }
	
	public int Scale { get; set; }

	public double Dmg { get; private set; }
	
	public double Crit { get; private set; }
	
	public double Daze { get; private set; }

	public bool HasDmg => Info.Dmg is not null;
	
	public bool HasDaze => Info.Daze is not null;
	
	public EnemyState? Target { get; set; }
	
	List<BuffState> _appliedBuffs = [];
 
	public SkillState(SkillInfo info, EntityState parentStats, AgentState owner) {
		Info = info;
		Owner = owner;
		Stats = new()
		{
			Parent = parentStats
		};
		Stats.Update();
		
	}
	
	public void UpdateBuffs(List<BuffState> buffs) {
		_appliedBuffs.Clear();
		
		if (buffs.Count == 0)
		{
			return;
		}
		_appliedBuffs.AddRange(buffs.Where(b => b.Info.SkillCondition!(Info)));
	}
	
	public void CheckBuffs() {
		Stats.Reset();
		AbilityState.ApplyModifiers(_appliedBuffs.Where(b => b is { Available: true, Active: true }), Stats, Owner);
		UpdateValues();
	}

	double GetDmg() {
		if (Info.Dmg is null) return 0;
		var baseDmg = Info.Dmg[Scale] / 100 * Stats.Total[Info.Stat];
		var bonusDmg = GetBonusDmg();
		var defDmg = GetDefDmg();
		var resDmg = GetResDmg();
		var takenDmg = GetTakenDmg();
		var stunDmg = GetStunDmg();
		
		return baseDmg * bonusDmg * defDmg * resDmg * takenDmg * stunDmg;
	}
	
	double GetStunDmg() {
		if(Target is null) return 1;
		
		if (!Target.Stunned) return 1;
		
		return Target.Stats.Total[StunDmg] / 100;
	}

	double GetTakenDmg() {
		if(Target is null) return 1;
		
		var dmgTaken = Target.Stats.Total[DmgTaken];
		var dmgReduction = Target.Stats.Total[DmgReduction];
		return 1 + (dmgTaken - dmgReduction) / 100;
	}

	double GetResDmg() {
		if(Target is null) return 1;
		
		var baseRes = Target.Stats.Total[DmgRes];
		var stat = Info.DmgType switch
		{
			Attributes.Physical => PhysicalRes,
			Attributes.Fire => FireRes,
			Attributes.Ice => IceRes,
			Attributes.Electric => ElectricRes,
			Attributes.Ether => EtherRes,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeRes = Target.Stats.Total[stat];
		return 1 + (baseRes + attributeRes) / 100;
	}
	
	double GetDefDmg() {
		if(Target is null) return 1;
		
		var level =Owner.Ascension switch
		{
			AscensionState.A1_10 => 1,
			AscensionState.A10_10 or AscensionState.A10_20 => 10,
			AscensionState.A20_20 or AscensionState.A20_30=> 20,
			AscensionState.A30_30 or AscensionState.A30_40  => 30,
			AscensionState.A40_40 or AscensionState.A40_50 => 40,
			AscensionState.A50_50 or AscensionState.A50_60 => 50,
			AscensionState.A60_60 => 60,
			_ => throw new ArgumentOutOfRangeException()
		};
		var levelFactor =  Math.Floor(0.1551 * level * level + 3.141 * level + 47.2039);
		var defTarget = Target.Stats.Total[Def];
		var agentPen = Stats.Total[Pen];
		var agentPenRatio = Stats.Total[PenRatio] / 100;
		
		var denominator = Math.Max(defTarget * (1 - agentPenRatio) - agentPen, 0) + levelFactor;
		
		return levelFactor / denominator;
	}

	double GetCritDmg() {
		var critDmg = Stats.Total[CritDmg];
		var stat = Info.DmgType switch
		{
			Attributes.Physical => PhysicalCritDmg,
			Attributes.Fire => FireCritDmg,
			Attributes.Ice => IceCritDmg,
			Attributes.Electric => ElectricCritDmg,
			Attributes.Ether => EtherCritDmg,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeCritDmg = Stats.Total[stat];
		return 1 + (critDmg + attributeCritDmg) / 100;
	}

	double GetBonusDmg() {
		var baseDmg = Stats.Total[BonusDmg];
		var skillDmg = GetSkillDmg();
		var attributeDmg = GetAttributeDmg();
		return 1 + (baseDmg + skillDmg + attributeDmg) / 100;
	}

	double GetAttributeDmg() {
		var stat = Info.DmgType switch
		{
			Attributes.Physical => PhysicalDmg,
			Attributes.Fire => FireDmg,
			Attributes.Ice => IceDmg,
			Attributes.Electric => ElectricDmg,
			Attributes.Ether => EtherDmg,
			_ => throw new ArgumentOutOfRangeException()
		};
		return Stats.Total[stat];
	}

	double GetSkillDmg() {
		var stat = Info.Type switch
		{
			Skills.Ex => ExDmg,
			Skills.Dash => DashDmg,
			Skills.Ultimate => UltimateDmg,
			Skills.Quick => QuickDmg,
			Skills.Basic => BasicDmg,
			Skills.Special => SpecialDmg,
			Skills.Dodge => DodgeDmg,
			Skills.Chain => ChainDmg,
			Skills.Assist => AssistDmg,
			_ => throw new ArgumentOutOfRangeException()
		};
		return Stats.Total[stat];
	}
	
	double GetDaze() {
		if (Info.Daze is null) return 0;
		var daze = 1 + Stats.Total[Enum.Stats.Daze] / 100;
		var impact = Stats.Total[Impact];
		var multiplier = Info.Daze[Scale] / 100;
		
		return daze * impact * multiplier;
	}
	
	public void UpdateValues() {
		Stats.Update();
		Dmg = GetDmg();
		Crit = GetCritDmg();
		Daze = GetDaze();
	}
}