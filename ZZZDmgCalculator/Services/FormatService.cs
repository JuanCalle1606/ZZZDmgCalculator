namespace ZZZDmgCalculator.Services;

using Microsoft.AspNetCore.Components;
using Models.Enum;
using Models.Info;
using Models.State;
using SmartFormat;
using Util;

public class FormatService(InfoService info) {


	public MarkupString BuffDescription(string infoDescription, BuffState buff) {
		var buffModifiers = buff.Modifiers;
		var buffValueMultiplier = buff.ValueMultiplier;

		var stats = buffModifiers.Select(m => $"<span class='{GetStatColor(m.Stat)}'><b>{info[m.Stat].DisplayName}</b></span>").ToArray();
		var values = buffModifiers.Select((m, i) => $"<span class='rz-color-bonus'><b>{m.Format(buffValueMultiplier, buff.ValuePerStack![i])}</b></span>").ToArray();

		var data = new
		{
			stat = stats.FirstOrDefault(),
			value = values.FirstOrDefault(),
			stats = stats,
			values = values
		};

		return new(Smart.Format(infoDescription, data));
	}

	static string GetStatColor(Stats firstStat) {
		return firstStat switch
		{
			Stats.BonusDmg => "rz-color-bonus",
			Stats.ElectricDmg => "rz-color-electric",
			Stats.FireDmg => "rz-color-fire",
			Stats.IceDmg => "rz-color-ice",
			Stats.EtherDmg => "rz-color-ether",
			Stats.PhysicalDmg => "rz-color-physical",
			_ => "rz-color-stat"
		};
	}
}