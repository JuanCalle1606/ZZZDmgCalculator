namespace ZZZDmgCalculator.Components.Setup;

using Extensions;
using MessagePipe;
using Microsoft.AspNetCore.Components;
using Models.Info;
using Models.State;

public partial class BuffView {
	[Parameter]
	public BuffState Buff { get; set; } = null!;

	BaseInfo? OwnerInfo
	{
		get
		{
			if (Buff.Shared && Buff.Owner != State.CurrentAgent && Buff.SourceInfo is not AgentInfo)
				return Buff.Owner.Info;

			return null;
		}
	}

	string Url =>
		Buff.SourceInfo is DiscInfo info ? $"icons/discs/Setup_Disc_{info.Id.ToUnderscore()}.png" : Buff.SourceInfo?.Url ?? string.Empty;

	protected override void OnInitialized() {
		base.OnInitialized();
		Buff.DependencyChecker?.CheckBuffDependencies(Buff);
		if (Buff.HasDependencies && Buff.Dependency is not null/* Dependency is null when engine is used on agents of another specialty */)
		{
			Buff.AppliedTo = Buff.Dependency!.AppliedTo;
		}
	}

	void StacksChanged(int val) {
		Buff.Stacks = val;
		NotifyAll();
	}

	void NotifyAll() {
		// to prevent desync of shared amplify buffs we update the current owner first
		Buff.Owner.UpdateAllStats();
		
		if (Buff.Shared || Buff.Info.Pass)
		{
			foreach (var agent in State.CurrentSetup.Agents.Where(a => a != Buff.Owner))
			{
				agent?.UpdateAllStats();
			}
		}
		if (Buff.Enemy)
		{
			State.CurrentSetup.Enemy.UpdateAllStats();
		}
		
		Notifier.BuffUpdated(Buff);
	}

	void SwitchChanged(bool obj) {
		Buff.Enabled = obj;
		NotifyAll();
	}

	void CheckIfNeedUpdate(BuffState buff) {
		if (buff != Buff.Dependency) return;
		var flag = Buff.Available;
		var flag2 = Buff.AppliedTo;
		Buff.DependencyChecker?.CheckBuffDependencies(Buff);
		Buff.AppliedTo = Buff.Dependency.AppliedTo;
		if (flag == Buff.Available && flag2 == Buff.AppliedTo) return;
		NotifyAll();
		StateHasChanged();
	}

	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		Notifier.OnBuffChanged.Subscribe(CheckIfNeedUpdate).AddTo(bag);
	}


	void ApplyToChanged(AgentState agent) {
		Buff.AppliedTo = agent == Buff.Owner ? null : agent;
		NotifyAll();
	}
}