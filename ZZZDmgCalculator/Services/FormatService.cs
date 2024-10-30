namespace ZZZDmgCalculator.Services;

using Microsoft.AspNetCore.Components;
using Models.Enum;
using Models.Info;
using Models.State;
using SmartFormat;
using Util;

public class FormatService(InfoService info) {


	public MarkupString BuffDescription(string infoDescription, BuffState buff) {
		var buffModifiers = buff.Modifiers.Where(m => m.NotDummy).ToList();
		var buffValueMultiplier = buff.ValueMultiplier;
		
		var stats = buffModifiers.Select(m => $"<span class='{GetStatColor(m.Stat)}'><b>{info[m.Stat].DisplayName}</b></span>").ToArray();
		var values = buffModifiers.Select((m, i) => $"<span class='rz-color-bonus'><b>{m.Format(buffValueMultiplier, buff.ValuePerStack![i], true)}</b></span>").ToArray();

		var data = new
		{
			stat = stats.FirstOrDefault(),
			value = values.FirstOrDefault(),
			stats = stats,
			values = values,
			buff = buff
		};

		return new(Smart.Format(infoDescription, data));
	}

	static string GetStatColor(Stats firstStat) {
		return firstStat switch
		{
			Stats.ElectricDmg or Stats.ElectricRes or Stats.ElectricCritDmg or Stats.ElectricCritRate => "rz-color-electric",
			Stats.FireDmg or Stats.FireRes or Stats.FireCritDmg or Stats.FireCritRate => "rz-color-fire",
			Stats.IceDmg or Stats.IceRes or Stats.IceCritDmg or Stats.IceCritRate => "rz-color-ice",
			Stats.EtherDmg or Stats.EtherRes or Stats.EtherCritDmg or Stats.EtherCritRate => "rz-color-ether",
			Stats.PhysicalDmg or Stats.PhysicalRes or Stats.PhysicalCritDmg or Stats.PhysicalCritRate => "rz-color-physical",
			_ => "rz-color-stat"
		};
	}
}