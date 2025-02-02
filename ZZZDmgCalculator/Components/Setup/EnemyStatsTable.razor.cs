namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.Enum;
using Models.State;

public partial class EnemyStatsTable {
	const int Cols = 4;
	const string CeroColor = "rz-color-base-600";
	const string BonusColor = "rz-color-bonus";

	[Parameter]
	public EntityState EntityStats { get; set; } = null!;

	string GetCombatClass(double value) => "rz-cell-data " + (value == 0 ? CeroColor : BonusColor);
	string GetStatClass(double value) => "rz-cell-data " + (value == 0 ? CeroColor : "");


	double InvertResistance(double d, Stats stat) {
		if(d == 0) {
			return 0;
		}
		if (stat is Stats.PhysicalRes or Stats.ElectricRes or Stats.IceRes or Stats.FireRes or Stats.EtherRes or Stats.DmgRes) {
			return -d;
		}
		return d;
	}
}