// ReSharper disable InconsistentNaming
namespace ZZZDmgCalculator.Models.Enum;

using System.ComponentModel.DataAnnotations;

public enum AscensionState {
	[Display(Description = "0/10")]
	A0_10,
	[Display(Description = "10/10")]
	A10_10,
	[Display(Description = "10/20")]
	A10_20,
	[Display(Description = "20/20")]
	A20_20,
	[Display(Description = "20/30")]
	A20_30,
	[Display(Description = "30/30")]
	A30_30,
	[Display(Description = "30/40")]
	A30_40,
	[Display(Description = "40/40")]
	A40_40,
	[Display(Description = "40/50")]
	A40_50,
	[Display(Description = "50/50")]
	A50_50,
	[Display(Description = "50/60")]
	A50_60,
	[Display(Description = "60/60")]
	A60_60,
}