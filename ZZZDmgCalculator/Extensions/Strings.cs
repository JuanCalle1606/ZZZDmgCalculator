namespace ZZZDmgCalculator.Extensions;

using System.Text;

public static class Strings {
	
	public static string ToUnderscore(this string str) {
		var sb = new StringBuilder();
		for (var i = 0; i < str.Length; i++) {
			if (char.IsUpper(str[i]) && i > 0) {
				sb.Append('_');
			}
			sb.Append(str[i]);
		}
		return sb.ToString();
	}
}