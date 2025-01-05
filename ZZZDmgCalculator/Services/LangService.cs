namespace ZZZDmgCalculator.Services;

using System.Resources;
using System.Text;
using ZZZ.ApiModels;

/// <summary>
/// Provides access to the language resources.
/// </summary>
public class LangService {
	readonly ResourceManager _manager = new("ZZZDmgCalculator.Lang.Resources", typeof(LangService).Assembly);

#if DEBUG
	readonly List<string> _warnKeys = [];
	
	public string this[string key]
	{
		get
		{
			var value = _manager.GetString(key);
			if (value is null && !_warnKeys.Contains(key))
			{
				_warnKeys.Add(key);
			}
			return value ?? $"%{key}%";
		}
	}
	
	public string GenMiss() {
		var sb = new StringBuilder();
		foreach (var key in _warnKeys.Where(k=>true))
			sb.AppendLine(
$"""
<data name="{key}" xml:space="preserve">
    <value></value>
</data>
""");
		return sb.ToString();
	}
#else
	public string this[string key] => _manager.GetString(key) ?? $"%{key}%";
#endif
	
	public string this[Enum key]
	{
		get
		{
			// Disc stats use the same localization as the stats except for the percentage stats.
			if(key is AgentStats ds && (ds != AgentStats.AtkPercent && ds != AgentStats.DefPercent && ds != AgentStats.HpPercent))
				return this[$"Stats.{key.ToString().Replace("Anomaly", "")}"];
			return this[$"{key.GetType().Name}.{key}"];
		}
	}
}