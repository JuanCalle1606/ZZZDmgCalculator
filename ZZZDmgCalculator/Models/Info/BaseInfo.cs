namespace ZZZDmgCalculator.Models.Info;

using Services;

public class BaseInfo {

	public string Id { get; set; } = string.Empty;

	public string DisplayName { get; set; } = string.Empty;
	
	public string Icon { get; init; } = string.Empty;

	public string Url { get; set; } = string.Empty;
	
	public InfoService Container { get; set; } = null!;
	
	public virtual void PostLoad(LangService lang) { }
}

public class BaseInfo<T> : BaseInfo where T : struct, System.Enum {
	readonly T _uid;

	public required T Uid
	{
		get => _uid;
		init
		{
			Id = value.ToString();
			_uid = value;
		}
	}
}