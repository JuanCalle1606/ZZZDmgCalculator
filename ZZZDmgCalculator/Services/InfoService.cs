namespace ZZZDmgCalculator.Services;

using System.Reflection;
using Data;
using Extensions;
using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

/// <summary>
/// Load and manages info about the models.
/// </summary>
public class InfoService(LangService lang) {

	Dictionary<Factions, BaseInfo> _factions = null!;
	public BaseInfo this[Factions item] => _factions[item];

	Dictionary<Specialties, BaseInfo> _specialties = null!;
	public BaseInfo this[Specialties item] => _specialties[item];

	Dictionary<Skills, BaseInfo> _skills = null!;
	public BaseInfo this[Skills item] => _skills[item];

	Dictionary<CoreSkills, BaseInfo> _coreSkills = null!;
	public BaseInfo this[CoreSkills item] => _coreSkills[item];

	Dictionary<Attributes, BaseInfo> _attributes = null!;
	public BaseInfo this[Attributes item] => _attributes[item];

	Dictionary<Discs, DiscInfo> _discs = null!;
	public DiscInfo this[Discs item] => _discs[item];

	Dictionary<Engines, EngineInfo> _engines = null!;
	public EngineInfo this[Engines item] => _engines[item];

	Dictionary<Stats, BaseInfo> _stats = null!;
	public BaseInfo this[Stats item] => _stats[item];
	
	Dictionary<AgentStats, DiscStatInfo> _discStats = null!;
	public DiscStatInfo this[AgentStats item] => _discStats[item];

	Dictionary<Agents, AgentInfo> _agents = null!;
	public AgentInfo this[Agents item] => _agents[item];
	
	Dictionary<Anomalies, AnomalyInfo> _anomalies = null!;
	public AnomalyInfo this[Anomalies item] => _anomalies[item];

	public void LoadAll() {
		var types = PreLoad();
		_factions = LoadData<Factions, BaseInfo>(types);
		_specialties = LoadData<Specialties, BaseInfo>(types);
		_skills = LoadData<Skills, BaseInfo>(types);
		_coreSkills = LoadData<CoreSkills, BaseInfo>(types);
		_attributes = LoadData<Attributes, BaseInfo>(types);
		_stats = LoadData<Stats, BaseInfo>(types);
		_anomalies = LoadData<Anomalies, AnomalyInfo>(types);
		
		_discStats = LoadData<AgentStats, DiscStatInfo>(types);
		_discs = LoadData<Discs, DiscInfo>(types);
		_engines = LoadData<Engines, EngineInfo>(types);
		_agents = LoadData<Agents, AgentInfo>(types);
	}

	static List<Type> PreLoad() =>
		typeof(InfoService).Assembly.GetTypes().Where(t => t.GetCustomAttribute<InfoDataAttribute>() is not null).ToList();

	Dictionary<T, TInfo> LoadData<T, TInfo>(IEnumerable<Type> types) where TInfo : BaseInfo where T : struct, Enum {
		var dataProviders = types.Where(t => t.GetCustomAttribute<InfoDataAttribute<T>>() is not null).ToList();
		var ret = new Dictionary<T, TInfo>();
		if (dataProviders.FirstOrDefault(t => t.GetCustomAttribute<InfoDataAttribute<T>>()!.Field is null) is {} allProvider)
		{
			// get the Data field
			ret = (Dictionary<T, TInfo>)allProvider.GetField("Data")!.GetValue(null)!;
		}
		else
		{
			foreach (var provider in dataProviders)
			{
				var attr = provider.GetCustomAttribute<InfoDataAttribute<T>>();
				var key = attr!.Field!.Value;
				var val = provider.GetField("Data")!.GetValue(null)!;
				ret.Add(key, (TInfo)val);
			}
		}

		var urlTemplate = dataProviders.Select(t => t.GetCustomAttribute<UrlTemplateAttribute>()).FirstOrDefault(t => t is not null)?.Template ?? string.Empty;

		foreach (var (key, x) in ret)
		{
			x.Container = this;
			x.DisplayName = lang[key];
			if (string.IsNullOrEmpty(x.Url))
			{
				x.Url = urlTemplate
					.Replace("{Icon}", x.Icon)
					.Replace("{Id}", x.Id)
					.Replace("{Id_}", x.Id.ToUnderscore());
			}
			//call post load
			x.PostLoad(lang);
		}

		return ret;
	}
	
	public IEnumerable<Agents> AvailableAgents => _agents.Keys;
	
	public IEnumerable<DiscStatInfo> AllDiscStatInfos => _discStats.Values;
	
	public IEnumerable<AnomalyInfo> AllAnomalyInfos => _anomalies.Values;

	public string AgentRankIcon(AgentRank infoRank) => infoRank switch
	{
		AgentRank.A => "icons/ranks/Icon_AgentRank_A.webp",
		AgentRank.S => "icons/ranks/Icon_AgentRank_S.webp",
		_ => throw new ArgumentOutOfRangeException(nameof(infoRank), infoRank, null)
	};
	
	public string ItemRankIcon(ItemRank infoRank) => infoRank switch
	{
		ItemRank.B => "icons/ranks/Item_Rank_B.webp",
		ItemRank.A => "icons/ranks/Item_Rank_A.webp",
		ItemRank.S => "icons/ranks/Item_Rank_S.webp",
		_ => throw new ArgumentOutOfRangeException(nameof(infoRank), infoRank, null)
	};
	
	public BaseInfo GetVar<T>(T value) where T : struct, Enum {
		if (typeof(T) == typeof(Attributes))
			return this[(Attributes)(object)value];
		if (typeof(T) == typeof(Factions))
			return this[(Factions)(object)value];
		if (typeof(T) == typeof(Specialties))
			return this[(Specialties)(object)value];

		throw new NotSupportedException();
	}
}