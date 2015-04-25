#pragma warning disable 0649

using UniRx;
using UnityEngine;

namespace Inconspicuous.Framework.Example.Test {
	public class GameView : View {
		[SerializeField]
		private Transform[] cubes;

		public Subject<int> SelectSubject { get; private set; }
		public Subject<Unit> ToggleSubject { get; private set; }

		[Inject]
		public void Construct() {
			SelectSubject = new Subject<int>();
			ToggleSubject = new Subject<Unit>();
		}

		public void Update() {
			if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha1)) {
				SelectSubject.OnNext(0);
			}
			if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha2)) {
				SelectSubject.OnNext(1);
			}
			if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha3)) {
				SelectSubject.OnNext(2);
			}
			if(UnityEngine.Input.GetKeyDown(KeyCode.T)) {
				ToggleSubject.OnNext();
			}
		}

		public void SetCurrent(int current) {
			for(int i = 0; i < cubes.Length; i++) {
				cubes[i].GetComponent<MeshRenderer>().material.color = i == current ? Color.yellow : Color.white;
			}
		}
	}
}
