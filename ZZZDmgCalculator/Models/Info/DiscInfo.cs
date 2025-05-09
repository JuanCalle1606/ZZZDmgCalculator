namespace ZZZDmgCalculator.Models.Info;

using Services;
using Extensions;
using ZZZ.ApiModels;

public class DiscInfo : BaseInfo<Discs> {
	public required StatModifier StatBuff { get; set; }

	public SingleList<BuffInfo> Buffs { get; init; } = [];

	public override void PostLoad(LangService lang) {
		for (var i = 0; i < Buffs.Count; i++)
		{
			var buffInfo = Buffs[i];
			buffInfo.Id = $"Buffs.Discs.{Id}.{i}";
			buffInfo.DisplayName = lang["Buffs.Discs.Fullset"];
			buffInfo.Description = lang[buffInfo.Id];
		}
	}
}