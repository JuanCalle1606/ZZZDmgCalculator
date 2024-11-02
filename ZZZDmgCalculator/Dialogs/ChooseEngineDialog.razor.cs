namespace ZZZDmgCalculator.Dialogs;

using Models.Enum;
using Models.Info;
using Util;
using ZZZ.ApiModels;


public partial class ChooseEngineDialog {
	string _searchFilter = string.Empty;
	readonly List<Specialties> _specialtiesFilter = [];
	readonly List<ItemRank> _rankFilter = [];
	EngineInfo[] _engines = null!;

	protected override void OnInitialized() {
		base.OnInitialized();
		_engines = Enum.GetValues<Engines>().Select(e => Info[e]).ToArray();
	}

	bool ApplyFilters(EngineInfo e) {
		return e.DisplayName.Contains(_searchFilter, StringComparison.CurrentCultureIgnoreCase) &&
		       _specialtiesFilter.HasFilter(e.Type) && _rankFilter.HasFilter(e.Rank);
	}
}