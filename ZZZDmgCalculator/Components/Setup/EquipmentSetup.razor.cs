namespace ZZZDmgCalculator.Components.Setup;

using MessagePipe;
using Microsoft.AspNetCore.Components;
using Models.State;
using Extensions;

public partial class EquipmentSetup {
	[Parameter]
	public AgentState Agent { get; set; } = null!;

	int _equipmentSelectedIndex = 0;
	async Task EngineClick() {
		if(Agent.Engine == null) {
			// open engine choose dialog
			if (await Dialogs.OpenEngineDialog() is {} info)
			{
				Notifier.SwapCurrentEngine(info);
				_equipmentSelectedIndex = 0;
			}
		}
		else
		{
			_equipmentSelectedIndex = 0;
		}
	}
	async Task DiscsClick(int i) {
		if(Agent.Discs[i] == null) {
			// open disc choose dialog
			if (await Dialogs.OpenDiscDialog(i) is {} info)
			{
				Notifier.SwapCurrentDisc(i, info);
				_equipmentSelectedIndex = i + 1;
			}
		}
		else
		{
			_equipmentSelectedIndex = i + 1;
		}
	}

	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		Notifier.OnCurrentEngineChanged.SubscribeUpdate(this).AddTo(bag);
		Notifier.OnCurrentDiscChanged.SubscribeUpdate(this).AddTo(bag);
	}
}