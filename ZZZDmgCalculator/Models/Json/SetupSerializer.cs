namespace ZZZDmgCalculator.Models.Json;

using Saves;
using State;

public class SetupSerializer {

	public static SavedEnemy EnemyToModel(EnemyState enemy) {
		return new SavedEnemy()
		{
			Level = enemy.Level,
			Stunned = enemy.Stunned,
			StunMultiplier = enemy.StunMultiplier,
			Resistances = enemy.Resistances,
			Weaknesses = enemy.Weaknesses,
			BaseDefense = enemy.BaseDefense
		};
	}
	public static void ModelToEnemy(SavedEnemy enemy, EnemyState setupEnemy) {
		setupEnemy.Level = enemy.Level;
		setupEnemy.Stunned = enemy.Stunned;
		setupEnemy.StunMultiplier = enemy.StunMultiplier;
		setupEnemy.BaseDefense = enemy.BaseDefense;
		setupEnemy.Resistances.AddRange(enemy.Resistances);
		setupEnemy.Weaknesses.AddRange(enemy.Weaknesses);
	}
}