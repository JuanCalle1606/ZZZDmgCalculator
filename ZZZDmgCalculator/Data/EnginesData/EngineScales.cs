namespace ZZZDmgCalculator.Data.EnginesData;

public static class EngineScales {
	public readonly static Dictionary<string, double[]> Templates = new()
	{
		["Mark1.Main"] = [32, 82, 110, 160, 189, 239, 268, 318, 346, 397, 425, 475],
		["Mark1.Sub"] = [8, 8, 10.4, 10.4, 12.8, 12.8, 15.2, 15.2, 17.6, 17.6, 20, 20],
		["Mark1.Buff"] = [8, 9, 10, 11, 12],
		["Mark2.Sub"] = [16, 16, 20.8, 20.8, 25.6, 25.6, 30.4, 30.4, 35.2, 35.2, 40, 40],
		["Mark2.Buff"] = [10, 12, 13, 15, 16],
		["GameBall.Main"] = [40, 102, 138, 201, 236, 299, 335, 397, 433, 496, 532, 594],
		["GameBall.Sub"] = [20, 20, 26, 26, 32, 32, 38, 38, 44, 44, 50, 50],
		["GameBall.Buff"] = [12, 13.5, 15.5, 17.5, 20],
		["TheVault.Main"] = [42, 107, 145, 211, 248, 314, 352, 417, 455, 521, 558, 624],
		["TheVault.Buff"] = [15, 17.5, 20, 22, 24],
		["TheVault.Buff2"] = [0.5, 0.58, 0.65, 0.72, 0.8],
		["SliceOfTime.Sub"] = [10, 10, 13, 13, 16, 16, 19, 19, 22, 22, 25, 25],
		["Kaboom.Buff"] = [2.5, 2.8, 3.2, 3.6, 4],
		["BashfulDemon.Buff"] = [2, 2.3, 2.6, 2.9, 3.2],
		["Cradle.Main"] = [46, 118, 159, 231, 272, 344, 385, 457, 498, 570, 611, 684],
		["Cradle.Sub"] = [9.6, 9.6, 12.5, 12.5, 15.4, 15.4, 18.2, 18.2, 21.1, 21.1, 24, 24],
		["Cradle.Buff"] = [0.6, 0, 76, 0.9, 1.05, 1.2],
		["Cradle.Buff2"] = [10, 12.5, 15, 17.5, 20],
		["Cradle.Buff3"] = [1.7, 2, 2.5, 3, 3.3],
		["Inflection.Sub"] = [12.8, 12.8, 16.6, 16.6, 20.5, 20.5, 24.3, 24.3, 28.2, 28.2, 32, 32],
		["Inflection.Buff"] = [6, 7, 8, 9, 10],
		["Base.Buff"] = [20, 23, 26, 29, 32],
		["Spring.Buff"] = [7.5, 8.5, 9.5, 10.5, 12],
		["Spring.Buff1"] = [10, 11.5, 13, 14.5, 16],
		["Peacekeeper.Buff"] = [36, 40, 45, 50, 55],
		["Transmorpher.Buff"] = [8, 9.2, 10.4, 11.6, 12.8],
		["Cylinder.Skill"] = [600, 690, 780, 870, 960],
		["Charlie.Sub"] = [6.4, 6.4, 8.3, 8.3, 10.2, 10.2, 12.2, 12.2, 14.1, 14.1, 16, 16],
		["Bravo.Sub"] = [24, 24, 31, 31, 38, 38, 45, 45, 52, 52, 60, 60],
		["Bravo.Buff"] = [25, 28, 32, 36, 40],
		["Gemini.Buff"] = [30, 34, 38, 42, 46],
		["Roaring.Buff"] = [40, 46, 52, 58, 64],
		["Rainforest.Sub"] = [30, 30, 39, 39, 48, 48, 57, 57, 66, 66, 75, 75],
		["ElectroLip.Buff"] = [15, 17.5, 20, 22.5, 25],
		["Stinger.Main"] = [48, 123, 166, 241, 284, 359, 402, 477, 520, 595, 638, 713],
		["Stinger.Sub"] = [36, 36, 46.8, 46.8, 57.6, 57.6, 68.4, 68.4, 79.2, 79.2, 90, 90],
		["Stinger.Buff"] = [12, 15, 18, 21, 24],
		["Stinger.Buff1"] = [40, 50, 60, 70, 80],
		["Compiler.Buff"] = [25, 31, 37, 43, 50],
		["Harchet.Buff"] = [9, 10, 11, 12, 13],
		["Arrow.Sub"] = [4.8, 4.8, 6.2, 6.2, 7.7, 7.7, 9.1, 9.1, 10.6, 10.6, 12, 12],
		["Shooter.Sub"] = [6, 6, 7.8, 7.8, 9.6, 9.6, 11.4, 11.4, 13.2, 13.2, 15, 15],
		["Battery.Buff"] = [18, 20.5, 23, 25, 27.5],
		["Teapot.Sub"] = [7.2, 7.2, 9.4, 9.4, 11.5, 11.5, 13.7, 13.7, 15.8, 15.8, 18, 18],
		["Teapot.Buff"] = [0.7, 0.88, 1.05, 1.22, 1.4],
		["Pleniluna.Buff"] = [12, 14, 16, 18, 20],
		["Superstar.Buff"] = [15, 17.2, 19.5, 21.7, 24],
		["StarlightReplica.Buff"] = [36, 41, 46.5, 52, 57.5],
		["Starlight.Buff"] = [12, 13.8, 15.6, 17.4, 19.2],
		["Housekeeper.Buff"] = [0.45, 0.52, 0.58, 0.65, 0.72],
		["Housekeeper.Buff1"] = [3, 3.5, 4, 4.4, 4.8],
		["Blossom.Buff"] = [6, 6.9, 7.8, 8.7, 9.6],
		["Drill.Buff"] = [50, 57.5, 65, 72.5, 80],
		["Brimstone.Sub"] = [12, 12, 15.6, 15.6, 19.2, 19.2, 22.8, 22.8, 26.4, 26.4, 30, 30],
		["Brimstone.Buff"] = [3.5, 4.4, 5.2, 6, 7],
		["Cushion.Buff"] = [20, 25, 30, 35, 40],
		["Cushion.Buff1"] = [25, 31.5, 38, 44, 50],
		["Suppressor.Sub"] = [19.2, 19.2, 25, 25, 30.7, 30.7, 36.5, 36.5, 42.2, 42.2, 48, 48],
		["Suppressor.Buff"] = [15, 18.8, 22.6, 26.4, 30],
		["Suppressor.Buff1"] = [35, 43.5, 52, 60.5, 70],
		["TuskOfFury.Buff"] = [30, 38, 46, 54, 60],
		["TuskOfFury.Buff1"] = [18, 22.5, 27, 31.5, 36],
		["Cannon.Buff"] = [7.5, 8.6, 9.7, 10.8, 12],
		["Blazing.Buff"] = [25, 28.75, 32.5, 36.25, 40],
		["Blazing.Buff1"] = [1.5, 1.72, 1.95, 2.17, 2.4],
		["Flamemaker.Buff"] = [50, 62, 75, 87, 100],
		["Hailstorm.Main"] = [50, 128, 173, 251, 296, 374, 419, 497, 542, 620, 665, 743],
		["Hailstorm.Buff"] = [50, 57, 65, 72, 80],
		["Timeweaver.Buff"] = [30, 35, 40, 45 ,50],
		["Timeweaver.Buff1"] = [75, 85, 95, 105, 115],
		["Timeweaver.Buff2"] = [25, 27.5, 30, 32.5, 35],
	};
}