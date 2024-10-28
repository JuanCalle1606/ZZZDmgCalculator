namespace ZZZDmgCalculator.Services;

using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Models.Info;
using Util;

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

	public string this[Enum key] => this[$"{key.GetType().Name}.{key}"];
	
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

	public string this[Enum key] => this[$"{key.GetType().Name}.{key}"];
#endif
}