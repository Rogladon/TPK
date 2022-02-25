using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts {
	public class ActionCheckBoxGroup : MonoBehaviour {
		[System.Serializable]
		class CheckBox {
			public IAction action;
			[SerializeField] private bool active;

			public CheckBox(IAction a, ActionCheckBoxGroup group) {
				action = a;
				active = false;
				action.sucess.AddListener(() => group.Check(this));
				action.reset.AddListener(() =>  active = false);
			}

			public void Reset() {
				if (active == false) return;
				active = false;
				action.ResetAction();
			}
			public void Active() {
				active = true;
			}
		}
		#region Fields
		[SerializeField] private List<CheckBox> actions;
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		private void Start() {
			actions = transform.GetChildrens().Where(p => p.TryGetComponent(out IAction a))
				.Select(p => new CheckBox(p.GetComponent<IAction>(), this)).ToList();
		}

		private void Check(CheckBox checkBox) {
			
			checkBox.Active();
			actions.Where(p => p != checkBox).ForEach(p => p.Reset());
		}
		#endregion
	}
}