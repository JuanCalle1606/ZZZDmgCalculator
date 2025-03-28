namespace ZZZDmgCalculator.Dialogs;

using Extensions;
using Models.Enum;
using Models.Info;

public partial class ChooseAgentDialog {
	string _searchFilter = string.Empty;
	readonly List<Attributes> _attributesFilter = [];
	readonly List<Specialties> _specialtiesFilter = [];
	readonly List<AgentRank> _rankFilter = [];

	AgentInfo[] _agents = null!;

	protected override void OnInitialized() {
		base.OnInitialized();
		_agents = Info.AvailableAgents.Select(i => Info[i]).ToArray();
	}

	bool ApplyFilters(AgentInfo i) => i.DisplayName.Contains(_searchFilter, StringComparison.CurrentCultureIgnoreCase) && 
	                                  _attributesFilter.HasFilter(i.Attribute) &&
	                                  _specialtiesFilter.HasFilter(i.Specialty)
	                                  && _rankFilter.HasFilter(i.Rank) && 
	                                  State.CurrentSetup.Agents.All(a => a?.Info.Id != i.Id);
}