namespace ZZZDmgCalculator.Util;

using Models.Enum;

public static class Dicts {
	readonly static Stats[] Stats = Enum.GetValues<Stats>();
	
	public static void Reset(this Dictionary<Stats, double> dict) {
		foreach (var item in Stats)
		{
			dict[item] = 0;
		}
	}
}