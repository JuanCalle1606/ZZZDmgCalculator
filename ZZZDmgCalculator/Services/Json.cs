namespace ZZZDmgCalculator.Services;

using System.Text.Json;

public static class Json {
	readonly static JsonSerializerOptions Options = new() { WriteIndented = true };
	
	public static string ToJson<T>(this T obj) => JsonSerializer.Serialize(obj, Options);
}