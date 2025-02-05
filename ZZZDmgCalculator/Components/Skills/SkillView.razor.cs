using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Skills;

using Extensions;
using MessagePipe;
using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

public partial class SkillView {
	[Parameter]
	public SkillInfo Skill { get; set; } = null!;

	[Parameter]
	public int Scale { get; set; }
	

	double GetDmg() {
		if (Skill.Dmg is null) return 0;
		var baseDmg = Skill.Dmg[Scale] / 100 * State.CurrentAgent!.Stats.Total[Skill.Stat];
		var bonusDmg = GetBonusDmg();
		var defDmg = GetDefDmg();
		var resDmg = GetResDmg();
		var takenDmg = GetTakenDmg();
		var stunDmg = GetStunDmg();
		
		return baseDmg * bonusDmg * defDmg * resDmg * takenDmg * stunDmg;
	}
	
	double GetStunDmg() {
		if (!State.CurrentSetup.Enemy.Stunned) return 1;
		
		return State.CurrentSetup.Enemy.Stats.Total[Stats.StunDmg] / 100;
	}

	double GetTakenDmg() {
		var dmgTaken = State.CurrentSetup.Enemy.Stats.Total[Stats.DmgTaken];
		var dmgReduction = State.CurrentSetup.Enemy.Stats.Total[Stats.DmgReduction];
		return 1 + (dmgTaken - dmgReduction) / 100;
	}

	double GetResDmg() {
		var baseRes = State.CurrentSetup.Enemy.Stats.Total[Stats.DmgRes];
		var stat = Skill.DmgType switch
		{
			Attributes.Physical => Stats.PhysicalRes,
			Attributes.Fire => Stats.FireRes,
			Attributes.Ice => Stats.IceRes,
			Attributes.Electric => Stats.ElectricRes,
			Attributes.Ether => Stats.EtherRes,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeRes = State.CurrentSetup.Enemy.Stats.Total[stat];
		return 1 + (baseRes + attributeRes) / 100;
	}
	
	double GetDefDmg() {
		var level = State.CurrentAgent!.Ascension switch
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
		var defTarget = State.CurrentSetup.Enemy.Stats.Total[Stats.Def];
		var agentPen = State.CurrentAgent!.Stats.Total[Stats.Pen];
		var agentPenRatio = State.CurrentAgent!.Stats.Total[Stats.PenRatio] / 100;
		
		var denominator = Math.Max(defTarget * (1 - agentPenRatio) - agentPen, 0) + levelFactor;
		
		return levelFactor / denominator;
	}

	double GetCritDmg() {
		var critDmg = State.CurrentAgent!.Stats.Total[Stats.CritDmg];
		var stat = Skill.DmgType switch
		{
			Attributes.Physical => Stats.PhysicalCritDmg,
			Attributes.Fire => Stats.FireCritDmg,
			Attributes.Ice => Stats.IceCritDmg,
			Attributes.Electric => Stats.ElectricCritDmg,
			Attributes.Ether => Stats.EtherCritDmg,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeCritDmg = State.CurrentAgent!.Stats.Total[stat];
		return 1 + (critDmg + attributeCritDmg) / 100;
	}

	double GetBonusDmg() {
		var baseDmg = State.CurrentAgent!.Stats.Total[Stats.BonusDmg];
		var skillDmg = GetSkillDmg();
		var attributeDmg = GetAttributeDmg();
		return 1 + (baseDmg + skillDmg + attributeDmg) / 100;
	}

	double GetAttributeDmg() {
		var stat = Skill.DmgType switch
		{
			Attributes.Physical => Stats.PhysicalDmg,
			Attributes.Fire => Stats.FireDmg,
			Attributes.Ice => Stats.IceDmg,
			Attributes.Electric => Stats.ElectricDmg,
			Attributes.Ether => Stats.EtherDmg,
			_ => throw new ArgumentOutOfRangeException()
		};
		return State.CurrentAgent!.Stats.Total[stat];
	}

	double GetSkillDmg() {
		var stat = Skill.Type switch
		{
			Skills.Ex => Stats.ExDmg,
			Skills.Dash => Stats.DashDmg,
			Skills.Ultimate => Stats.UltimateDmg,
			Skills.Quick => Stats.QuickDmg,
			Skills.Basic => Stats.BasicDmg,
			Skills.Special => Stats.SpecialDmg,
			Skills.Dodge => Stats.DodgeDmg,
			Skills.Chain => Stats.ChainDmg,
			Skills.Assist => Stats.AssistDmg,
			_ => throw new ArgumentOutOfRangeException()
		};
		return State.CurrentAgent!.Stats.Total[stat];
	}

	static string FormatValue(double value) => $"{value:N0}";
	double GetMean(double dmg, double crit) {
		var baseCrit = State.CurrentAgent!.Stats.Total[Stats.CritRate];
		var stat = Skill.DmgType switch
		{
			Attributes.Physical => Stats.PhysicalCritRate,
			Attributes.Fire => Stats.FireCritRate,
			Attributes.Ice => Stats.IceCritRate,
			Attributes.Electric => Stats.ElectricCritRate,
			Attributes.Ether => Stats.EtherCritRate,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeCrit = State.CurrentAgent!.Stats.Total[stat];
		var critRate = baseCrit + attributeCrit;
		return (crit * critRate + dmg * (100 - critRate)) / 100;
	}
	
	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		// update stats everytime an engine is changed
		Notifier.OnCurrentEngineChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnCurrentDiscChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnBuffChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnEnemyChanged.SubscribeUpdate(this).AddTo(bag);
	}
}