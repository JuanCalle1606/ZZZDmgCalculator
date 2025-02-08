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
		var critRate = Math.Min(baseCrit + attributeCrit, 100);
		return (crit * critRate + dmg * (100 - critRate)) / 100;
	}
	
	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		Notifier.OnCurrentEngineChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnCurrentDiscChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnBuffChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnEnemyChanged.SubscribeUpdate(this).AddTo(bag);
	}
}