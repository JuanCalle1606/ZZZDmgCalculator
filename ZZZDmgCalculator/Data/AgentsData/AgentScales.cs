namespace ZZZDmgCalculator.Data.AgentsData;

using Models.Enum;
using Models.Info;

public static class AgentScales {
	public readonly static Dictionary<string, double[]> Templates = new()
	{
		["Rina.Atk"] = [103, 157, 194, 254, 291, 351, 388, 448, 484, 544, 581, 642],
		["Rina.Hp"] = [692, 1537, 2012, 2951, 3426, 4366, 4841, 5780, 6255, 7194, 7669, 8609],
		["Rina.Def"] = [48, 106, 139, 205, 238, 304, 337, 402, 436, 502, 535, 600],

		["Nicole.Atk"] = [93, 140, 173, 227, 261, 314, 347, 400, 433, 486, 520, 574],
		["Nicole.Hp"] = [655, 1454, 1903, 2792, 3242, 4131, 4580, 5469, 5919, 6808, 7257, 8145],
		["Nicole.Def"] = [50, 111, 145, 213, 248, 315, 349, 417, 451, 519, 554, 622],

		["Lucy.Atk"] = [95, 143, 177, 232, 266, 320, 354, 408, 441, 495, 529, 583],
		["Lucy.Hp"] = [645, 1433, 1876, 2751, 3194, 4070, 4514, 5389, 5832, 6708, 7150, 8025],
		["Lucy.Def"] = [49, 109, 143, 210, 244, 310, 343, 410, 444, 511, 545, 612],
		["Lucy.b1"] = [13.8, 14.6, 15.4, 16.2, 17.0, 17.8, 18.6, 19.4, 20.2, 21.0, 21.8, 22.6, 23.4, 24.2, 25.0, 25.8],
		["Lucy.b2"] = [44, 48, 52, 56, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104],

		["Soukaku.Atk"] = [96, 145, 179, 234, 268, 323, 358, 413, 447, 501, 535, 590],
		["Soukaku.Def"] = [48, 106, 139, 204, 237, 303, 336, 401, 434, 499, 532, 597],

		["Anby.Hp"] = [603, 1339, 1753, 2572, 2986, 3804, 4218, 5036, 5450, 6269, 6682, 7500],

		["Koleda.Atk"] = [106, 161, 199, 261, 299, 361, 398, 460, 498, 560, 598, 660],
		["Koleda.Hp"] = [653, 1451, 1899, 2785, 3234, 4121, 4569, 5456, 5905, 6792, 7240, 8127],
		["Koleda.Def"] = [48, 106, 139, 204, 237, 302, 334, 398, 431, 496, 529, 594],

		["Qingyi.Atk"] = [109, 166, 205, 270, 309, 373, 412, 476, 515, 579, 618, 683],
		["Qingyi.Hp"] = [663, 1473, 1928, 2828, 3284, 4184, 4639, 5540, 5995, 6895, 7350, 8250],

		["Lycaon.Atk"] = [105, 160, 197, 258, 296, 357, 394, 456, 494, 555, 592, 653],
		["Lycaon.Hp"] = [677, 1503, 1967, 2885, 3350, 4268, 4732, 5650, 6114, 7033, 7498, 8416],
		["Lycaon.Def"] = [49, 108, 141, 207, 241, 307, 340, 407, 441, 507, 540, 606],

		["Ellen.Atk"] = [135, 209, 257, 339, 387, 470, 519, 602, 650, 732, 780, 863],
		["Ellen.Hp"] = [617, 1370, 1793, 2630, 3054, 3891, 4314, 5152, 5576, 6413, 6836, 7673],
		["Ellen.Core"] = [50, 58.3, 66.6, 75, 83.3, 91.6, 100],

		["Billy.Atk"] = [113, 173, 213, 280, 321, 389, 429, 496, 537, 604, 644, 712],
		["Billy.Hp"] = [555, 1233, 1614, 2367, 2748, 3502, 3883, 4637, 5018, 5771, 6153, 6907],

		["Nekomata.Atk"] = [131, 202, 249, 329, 376, 456, 502, 582, 629, 708, 755, 835],
		["Nekomata.Hp"] = [608, 1350, 1767, 2592, 3009, 3833, 4250, 5075, 5492, 6317, 6735, 7560],
		["Nekomata.Def"] = [47, 104, 136, 200, 233, 298, 330, 394, 427, 491, 523, 587],

		["Corin.Atk"] = [116, 178, 219, 288, 330, 400, 441, 510, 552, 621, 662, 732],
		["Corin.Hp"] = [561, 1246, 1631, 2392, 2777, 3538, 3923, 4684, 5069, 5830, 6215, 6976],
		["Corin.Def"] = [49, 108, 141, 207, 241, 307, 340, 405, 438, 504, 538, 604],
	};

	public static bool BasicAdditionalCondition(AgentInfo agent, AgentInfo target) => agent.Attribute == target.Attribute || agent.Faction == target.Faction;


	public static Func<AgentInfo, AgentInfo, bool> SpecialyAdditionalCondition(Specialties specialty) => (a, b) => b.Specialty == specialty || a.Faction == b.Faction;
}