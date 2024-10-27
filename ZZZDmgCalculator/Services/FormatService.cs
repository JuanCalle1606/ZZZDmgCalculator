namespace ZZZDmgCalculator.Services;

using Microsoft.AspNetCore.Components;
using Models.Enum;
using Models.Info;
using SmartFormat;
using Util;

public class FormatService(InfoService info) {
	
	
	
	public MarkupString BuffDescription(string infoDescription, IList<StatModifier> buffModifiers) {
		var first = buffModifiers.First();
		var data = new
		{
			stat = $"<span class='{GetStatColor(first.Stat)}'><b>{info[first.Stat].DisplayName}</b></span>",
			value = $"<span class='rz-color-bonus'><b>{first.Format()}</b></span>",
		};
		
		return new(Smart.Format(infoDescription, data));
	}
	string GetStatColor(Stats firstStat) {
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