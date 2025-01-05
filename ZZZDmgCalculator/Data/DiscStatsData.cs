namespace ZZZDmgCalculator.Data;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.AgentStats;
using static Models.Enum.StatModifiers;

[InfoData<AgentStats>]
public class DiscStatsData {
	public readonly static Dictionary<AgentStats, DiscStatInfo> Data = new()
	{
		[HpPercent] = new()
		{
			Uid = HpPercent,
			MainDiscs = [4, 5, 6],
			SubScales = [1, 2, 3],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.Hp, Type = BasePercent }
		},

		[Hp] = new()
		{
			Uid = Hp,
			MainDiscs = [1],
			SubScales = [39, 79, 112],
			MainScales =
			[
				[183, 244, 305, 366, 427, 489, 550, 611, 672, 734],
				[367, 458, 550, 642, 734, 825, 917, 1009, 1101, 1192, 1284, 1376, 1468],
				[550, 660, 770, 880, 990, 1100, 1210, 1320, 1430, 1540, 1650, 1760, 1870, 1980, 2090, 2200]
			],
			Buff = new() { Stat = Stats.Hp, Type = BaseFlat }
		},

		[AtkPercent] = new()
		{
			Uid = AtkPercent,
			MainDiscs = [4, 5, 6],
			SubScales = [1, 2, 3],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.Atk, Type = BasePercent }
		},

		[Atk] = new()
		{
			Uid = Atk,
			MainDiscs = [2],
			SubScales = [7, 15, 19],
			MainScales =
			[
				[26, 34, 43, 52, 60, 69, 78, 86, 95, 104],
				[53, 66, 79, 92, 106, 119, 132, 145, 159, 172, 185, 198, 212],
				[79, 94, 110, 126, 142, 158, 173, 189, 205, 221, 237, 252, 268, 284, 300, 316]
			],
			Buff = new() { Stat = Stats.Atk, Type = BaseFlat }
		},

		[Impact] = new()
		{
			Uid = Impact,
			MainDiscs = [6],
			MainScales =
			[
				[1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0],
				[3.0, 3.8, 4.5, 5.3, 6.0, 6.8, 7.5, 8.3, 9.0, 9.8, 10.5, 11.3, 12.0],
				[4.5, 5.4, 6.3, 7.2, 8.1, 9.0, 9.9, 10.8, 11.7, 12.6, 13.5, 14.4, 15.3, 16.2, 17.1, 18.0]
			],
			Buff = new() { Stat = Stats.Impact, Type = BasePercent }
		},

		[DefPercent] = new()
		{
			Uid = DefPercent,
			MainDiscs = [4, 5, 6],
			SubScales = [1.6, 3.2, 4.8],
			MainScales =
			[
				[4.0, 5.3, 6.7, 8.0, 9.3, 10.7, 12.0, 13.3, 14.7, 16.0],
				[8.0, 10.0, 12.0, 14.0, 16.0, 18.0, 20.0, 22.0, 24.0, 26.0, 28.0, 30.0, 32.0],
				[12.0, 14.4, 16.8, 19.2, 21.6, 24.0, 26.4, 28.8, 31.2, 33.6, 36.0, 38.4, 40.8, 43.2, 45.6, 48.0]
			],
			Buff = new() { Stat = Stats.Def, Type = BasePercent }
		},

		[Def] = new()
		{
			Uid = Def,
			MainDiscs = [3],
			SubScales = [5, 10, 15],
			MainScales =
			[
				[15, 20, 25, 30, 35, 40, 45, 50, 55, 60],
				[31, 38, 46, 54, 62, 69, 77, 85, 93, 100, 108, 116, 124],
				[46, 55, 64, 73, 82, 92, 101, 110, 119, 128, 138, 147, 156, 165, 174, 184]
			],
			Buff = new() { Stat = Stats.Def, Type = BaseFlat }
		},
		
		[CritRate] = new()
		{
			Uid = CritRate,
			MainDiscs = [4],
			SubScales = [0.8, 1.6, 2.4],
			MainScales =
			[
				[2.0, 2.7, 3.3, 4.0, 4.7, 5.3, 6.0, 6.7, 7.3, 8.0],
				[4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0],
				[6.0, 7.2, 8.4, 9.6, 10.8, 12.0, 13.2, 14.4, 15.6, 16.8, 18.0, 19.2, 20.4, 21.6, 22.8, 24.0]
			],
			Buff = new() { Stat = Stats.CritRate }
		},
		
		[CritDmg] = new()
		{
			Uid = CritDmg,
			MainDiscs = [4],
			SubScales = [1.6, 3.2, 4.8],
			MainScales =
			[
				[4.0, 5.3, 6.7, 8.0, 9.3, 10.7, 12.0, 13.3, 14.7, 16.0],
				[8.0, 10.0, 12.0, 14.0, 16.0, 18.0, 20.0, 22.0, 24.0, 26.0, 28.0, 30.0, 32.0],
				[12.0, 14.4, 16.8, 19.2, 21.6, 24.0, 26.4, 28.8, 31.2, 33.6, 36.0, 38.4, 40.8, 43.2, 45.6, 48.0]
			],
			Buff = new() { Stat = Stats.CritDmg }
		},
		
		[PenRatio] = new()
		{
			Uid = PenRatio,
			MainDiscs = [5],
			MainScales =
			[
				[2.0, 2.7, 3.3, 4.0, 4.7, 5.3, 6.0, 6.7, 7.3, 8.0],
				[4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0],
				[6.0, 7.2, 8.4, 9.6, 10.8, 12.0, 13.2, 14.4, 15.6, 16.8, 18.0, 19.2, 20.4, 21.6, 22.8, 24.0]
			],
			Buff = new() { Stat = Stats.PenRatio }
		},
		
		[Pen] = new()
		{
			Uid = Pen,
			SubScales = [3, 6, 9],
			Buff = new() { Stat = Stats.Pen, Type = BaseFlat }
		},
		
		[AnomalyProficiency] = new()
		{
			Uid = AnomalyProficiency,
			MainDiscs = [4],
			SubScales = [3, 6, 9],
			MainScales =
			[
				[8, 10, 13, 16, 18, 21, 24, 26, 29, 32],
				[15, 18, 22, 26, 30, 33, 37, 41, 45, 48, 52, 56, 60],
				[23, 27, 32, 36, 41, 46, 50, 55, 59, 64, 69, 73, 78, 82, 87, 92]
			],
			Buff = new() { Stat = Stats.Proficiency, Type = BaseFlat }
		},
		
		[AnomalyMastery] = new()
		{
			Uid = AnomalyMastery,
			MainDiscs = [6],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.Mastery, Type = BasePercent }
		},
		
		[EnergyRegen] = new()
		{
			Uid = EnergyRegen,
			MainDiscs = [6],
			MainScales =
			[
				[5, 6, 8, 10, 11, 13, 15, 16, 18, 20],
				[10, 12, 15, 17, 20, 22, 25, 27, 30, 32, 35, 37, 40],
				[15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60]
			],
			Buff = new() { Stat = Stats.EnergyRegen, Type = BasePercent }
		},
		
		[PhysicalDmg] = new()
		{
			Uid = PhysicalDmg,
			MainDiscs = [5],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.PhysicalDmg }
		},
		
		[FireDmg] = new()
		{
			Uid = FireDmg,
			MainDiscs = [5],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.FireDmg }
		},
		
		[IceDmg] = new()
		{
			Uid = IceDmg,
			MainDiscs = [5],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.IceDmg }
		},
		
		[ElectricDmg] = new()
		{
			Uid = ElectricDmg,
			MainDiscs = [5],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.ElectricDmg }
		},
		
		[EtherDmg] = new()
		{
			Uid = EtherDmg,
			MainDiscs = [5],
			MainScales =
			[
				[2.5, 3.3, 4.2, 5.0, 5.8, 6.7, 7.5, 8.3, 9.2, 10.0],
				[5.0, 6.3, 7.5, 8.8, 10.0, 11.3, 12.5, 13.8, 15.0, 16.3, 17.5, 18.8, 20.0],
				[7.5, 9.0, 10.5, 12.0, 13.5, 15.0, 16.5, 18.0, 19.5, 21.0, 22.5, 24.0, 25.5, 27.0, 28.5, 30.0]
			],
			Buff = new() { Stat = Stats.EtherDmg }
		},
	};
}