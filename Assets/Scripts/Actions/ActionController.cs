using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts {
	public class ActionController : MonoBehaviour {
		private class ActionIteration {
			private IAction action;
			private List<int> indexes;

			public ActionIteration(IAction a, int index, ActionController controller) {
				Debug.Log($"Create action: {action} index: {index}");
				action = a;
				indexes = new List<int>() { index };
				action.sucess.AddListener(() => Check(controller));
			}
			public void AddIndex(int index) {
				Debug.Log($"Add index action: {action} index: {index}");
				indexes.Add(index);
			}
			public void Check(ActionController controller) {
				controller.Check(action, indexes);
			}
			public bool Equals(IAction a) {
				return a == action;
			}
		}

		#region Fields
		[SerializeField] private List<GameObject> actionsObjects;
		private List<ActionIteration> iteration = new List<ActionIteration>();

		private int iter = 0;
		#endregion

		#region Properties
		private List<IAction> actions => actionsObjects.Where(p => p.TryGetComponent(out IAction a))
			.Select(p => p.GetComponent<IAction>()).ToList();
		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		private void Awake() {
			actions.Select((p, i) => new { p = p, i = i })
				.ForEach(p => {
					Debug.Log($"Start added action: {p.p}");
					var i = iteration.FirstOrDefault(c => c.Equals(p.p));
					if (i != default(ActionIteration)) i.AddIndex(p.i);
					else iteration.Add(new ActionIteration(p.p, p.i, this));
				});
		}

		private void Check(IAction action, List<int> indexes) {
			if(indexes.Contains(iter)) {
				Debug.Log($"sucess action for iter: {iter}");
				iter++;
			} else {
				Debug.Log($"error action iter: {iter}, index: {indexes}");
				action.ResetAction();
			}
		}
		#endregion
	}
}