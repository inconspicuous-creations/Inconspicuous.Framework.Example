using System;
using System.ComponentModel.Composition;
using UniRx;
using UnityEngine;

namespace Inconspicuous.Framework.Example.Test {
	[Export]
	public sealed class GameViewModel : ViewModel {
		private readonly SerialDisposable disposable;
		private int currentCube;

		public GameViewModel() {
			this.disposable = new SerialDisposable();
		}

		public int CurrentCube {
			get { return currentCube; }
			set { SetProperty(ref currentCube, value, "CurrentCube"); }
		}

		public void ToggleAutoCycle() {
			if(disposable.Disposable != null) {
				disposable.Disposable = null;
			} else {
				disposable.Disposable = Observable.Interval(TimeSpan.FromSeconds(0.5f))
					.Subscribe(_ => CurrentCube = (int)Mathf.Repeat(CurrentCube + 1, 3));
			}
		}
	}
}
