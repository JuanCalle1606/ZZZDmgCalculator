namespace ZZZDmgCalculator.Components.Main;

using Extensions;
using MessagePipe;
using Microsoft.AspNetCore.Components;
using Models.Enum;
using Models.State;

public partial class AgentStatsTable {
	const int Cols = 4;
	const string CeroColor = "rz-color-base-600";
	const string BonusColor = "rz-color-bonus";

	[Parameter]
	public EntityState EntityStats { get; set; } = null!;

	string[] _categories = ["Basic", "Bonus", "Unique", "Anomaly", "Resistances"];
	bool[] _categoriesState = [true, true, true, true, true];
	Stats[] _allStats = Enum.GetValues<Stats>();
	IEnumerable<Stats> GetStats(string category) {
		return category switch
		{
			"Basic" => _allStats.Where(s => s is >= Stats.Atk and <= Stats.Mastery),
			"Bonus" => _allStats.Where(s => s is >= Stats.ElectricDmg and <= Stats.PhysicalCritRate),
			"Unique" => _allStats.Where(s => s is >= Stats.ShieldPower and <= Stats.BonusDmg),
			"Anomaly" => _allStats.Where(s => s is >= Stats.BuildUp and <= Stats.DisorderDmg),
			"Resistances" => _allStats.Where(s => s is >= Stats.DmgRes and <= Stats.PhysicalRes),
			_ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
		};
	}
	
	bool SkipCategory(string category) => GetStats(category).All(c => EntityStats.Total[c] == 0);
	void ToggleCategory(int index) => _categoriesState[index] = !_categoriesState[index];
	string GetCatStyle(int index) => _categoriesState[index] ? "" : "display: none;";
	string GetCombatClass(double value) => "rz-cell-data " + (value == 0 ? CeroColor : BonusColor);
	string GetStatClass(double value) => "rz-cell-data " + (value == 0 ? CeroColor : "");

	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		// update stats everytime an engine is changed
		Notifier.OnCurrentEngineChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnCurrentDiscChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnBuffChanged.SubscribeUpdate(this).AddTo(bag);
	}
}