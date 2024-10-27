namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.Info;
using Models.State;
using Util;

public partial class BuffView {
	[Parameter]
	public BuffState Buff { get; set; } = null!;

	public string Url => 
		Buff.SourceInfo is DiscInfo info ? $"icons/discs/Setup_Disc_{info.Id.ToUnderscore()}.png" : Buff.SourceInfo?.Url ?? string.Empty;
}