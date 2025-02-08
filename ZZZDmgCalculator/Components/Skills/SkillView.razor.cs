using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Skills;

using Extensions;
using MessagePipe;
using Models.Enum;
using Models.State;

public partial class SkillView {
	[Parameter]
	public SkillState Skill { get; set; } = null!;
	static string FormatValue(double value) => $"{value:N0}";
	
	double GetMean(double dmg, double crit) {
		var baseCrit = Skill.Stats.Total[Stats.CritRate];
		var stat = Skill.Info.DmgType switch
		{
			Attributes.Physical => Stats.PhysicalCritRate,
			Attributes.Fire => Stats.FireCritRate,
			Attributes.Ice => Stats.IceCritRate,
			Attributes.Electric => Stats.ElectricCritRate,
			Attributes.Ether => Stats.EtherCritRate,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeCrit = Skill.Stats.Total[stat];
		var critRate = baseCrit + attributeCrit;
		return (crit * critRate + dmg * (100 - critRate)) / 100;
	}
	/*EntityState _stats = new();
	
	List<BuffState> _buffs = [];
	List<BuffState> _appliedBuffs = [];

	protected override void OnInitialized() {
		AbilityView.ChildSkills.Add(this);
		_stats.Parent = ParentStats;
		_stats.Update();
	}

	double GetDmg() {
		if (Skill.Dmg is null) return 0;
		var baseDmg = Skill.Dmg[Scale] / 100 * _stats.Total[Skill.Stat];
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
		var agentPen = _stats.Total[Stats.Pen];
		var agentPenRatio = _stats.Total[Stats.PenRatio] / 100;
		
		var denominator = Math.Max(defTarget * (1 - agentPenRatio) - agentPen, 0) + levelFactor;
		
		return levelFactor / denominator;
	}

	double GetCritDmg() {
		var critDmg = _stats.Total[Stats.CritDmg];
		var stat = Skill.DmgType switch
		{
			Attributes.Physical => Stats.PhysicalCritDmg,
			Attributes.Fire => Stats.FireCritDmg,
			Attributes.Ice => Stats.IceCritDmg,
			Attributes.Electric => Stats.ElectricCritDmg,
			Attributes.Ether => Stats.EtherCritDmg,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeCritDmg = _stats.Total[stat];
		return 1 + (critDmg + attributeCritDmg) / 100;
	}

	double GetBonusDmg() {
		var baseDmg = _stats.Total[Stats.BonusDmg];
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
		return _stats.Total[stat];
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
		return _stats.Total[stat];
	}

	static string FormatValue(double value) => $"{value:N0}";
	double GetMean(double dmg, double crit) {
		var baseCrit = _stats.Total[Stats.CritRate];
		var stat = Skill.DmgType switch
		{
			Attributes.Physical => Stats.PhysicalCritRate,
			Attributes.Fire => Stats.FireCritRate,
			Attributes.Ice => Stats.IceCritRate,
			Attributes.Electric => Stats.ElectricCritRate,
			Attributes.Ether => Stats.EtherCritRate,
			_ => throw new ArgumentOutOfRangeException()
		};
		var attributeCrit = _stats.Total[stat];
		var critRate = baseCrit + attributeCrit;
		return (crit * critRate + dmg * (100 - critRate)) / 100;
	}
	
	double GetDaze() {
		if (Skill.Daze is null) return 0;
		var daze = 1 + _stats.Total[Stats.Daze] / 100;
		var impact = _stats.Total[Stats.Impact];
		var multiplier = Skill.Daze[Scale] / 100;
		
		return daze * impact * multiplier;
	}
	
	public void UpdateSkill(List<BuffState> skillBuffs, bool force) {
		_stats.Reset();
		if (force) _buffs.Clear();
		var buffs = skillBuffs;
		if (buffs.SequenceEqual(_buffs)) goto finalize;
		_buffs = buffs;
		if (_buffs.Count == 0)
		{
			_appliedBuffs.Clear();
			goto finalize;
		}
		
		_appliedBuffs = _buffs.Where(b => b.Info.SkillCondition!(Skill)).ToList();
		
		UpdateBuffs(true);
		
		finalize:
		_stats.Update();
	}
	
	public void UpdateBuffs(object? source) {
		if(source is not true)
			_stats.Reset();
		
		AbilityView.ApplyModifiers(_appliedBuffs.Where(b => b is { Available: true, Active: true }), _stats);
		_stats.Update();
		StateHasChanged();
	}*/
	
	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		Notifier.OnCurrentEngineChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnCurrentDiscChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnBuffChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnEnemyChanged.SubscribeUpdate(this).AddTo(bag);
	}
}