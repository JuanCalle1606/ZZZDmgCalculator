namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.State;

public partial class EnemyView {
	[Parameter]
	public EnemyState Enemy { get; set; } = null!;

	void UpdateResistances() {
		Enemy.UpdateResistances();
		Notifier.CurrentEnemyUpdated(Enemy);
	}
	void ChangeStunMultipler(int obj) {	
		Enemy.StunMultiplier = obj;
		Notifier.CurrentEnemyUpdated(Enemy);
	}
	void ChangeStunned(bool obj) {
		Enemy.Stunned = obj;
		Notifier.CurrentEnemyUpdated(Enemy);
	}
	void ChangeDefense(int obj) {
		Enemy.BaseDefense = obj;
		Notifier.CurrentEnemyUpdated(Enemy);
	}
	void ChangeLevel(int obj) {
		Enemy.Level = obj;
		Notifier.CurrentEnemyUpdated(Enemy);
	}
}