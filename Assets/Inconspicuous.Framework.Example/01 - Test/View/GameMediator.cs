using System.ComponentModel.Composition;
using UniRx;

namespace Inconspicuous.Framework.Example.Test {
	[Export(typeof(IMediator<GameView>))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class GameMediator : Mediator<GameView> {
		private readonly GameViewModel gameViewModel;

		public GameMediator(GameViewModel gameViewModel) {
			this.gameViewModel = gameViewModel;
		}

		public override void Mediate(GameView view) {
			gameViewModel.AsObservable("CurrentCube", () => gameViewModel.CurrentCube)
				.Subscribe(x => view.SetCurrent(x)).AddTo(view);
			view.SelectSubject
				.Subscribe(x => gameViewModel.CurrentCube = x).AddTo(view);
			view.ToggleSubject
				.Subscribe(_ => gameViewModel.ToggleAutoCycle()).AddTo(view);
		}
	}
}
