namespace ZZZDmgCalculator.Components.Setup;

using MessagePipe;
using Microsoft.AspNetCore.Components;
using Models.Info;
using Models.State;
using Util;

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
	}

	void StacksChanged(int val) {
		Buff.Stacks = val;
		NotifyAll();
	}

	void NotifyAll() {
		if (Buff.Shared)
		{
			foreach (var agent in State.CurrentSetup.Agents)
			{
				agent?.UpdateAllStats();
			}
		}
		else
		{
			State.CurrentAgent.UpdateAllStats();
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
		Buff.DependencyChecker?.CheckBuffDependencies(Buff);
		if (flag == Buff.Available) return;
		NotifyAll();
		StateHasChanged();
	}

	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		Notifier.OnBuffChanged.Subscribe(CheckIfNeedUpdate).AddTo(bag);
	}
}