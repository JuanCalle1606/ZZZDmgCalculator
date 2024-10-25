namespace ZZZDmgCalculator.Models.Info;

using Services;
using Util;

public class DiscInfo : BaseInfo {
	public required StatModifier StatBuff { get; set; }

	public SingleList<BuffInfo> Buffs { get; init; } = [];

	public override void PostLoad(LangService lang) {
		for (var i = 0; i < Buffs.Count; i++)
		{
			var buffInfo = Buffs[i];
			buffInfo.Id = $"Buffs.Engines.{Id}.{i}";
			buffInfo.DisplayName = lang[buffInfo.Id];
			buffInfo.Description = lang[$"{buffInfo.Id}.Desc"];
		}
	}
}