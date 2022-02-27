using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
	
	public class ActionController : MonoBehaviour {


		#region Fields
		[SerializeField] private ActionProgramm actionProgramm;
		private Dictionary<IAction, List<ActionIteration>> iteration = new Dictionary<IAction, List<ActionIteration>>();

		private int iter = 0;
		#endregion

		#region Properties

		public int currentIteration => iter;
		#endregion

		#region Public Methods
		public void StartProgramm(ActionProgramm p) {
			iteration = new Dictionary<IAction, List<ActionIteration>>();
			iter = 0;
			actionProgramm.actions.Select((p, i) => new { p = p, i = i })
				.ForEach(p => {
					p.p.index = p.i;
					if (!iteration.ContainsKey(p.p.action)) {
						iteration[p.p.action] = new List<ActionIteration>();
					}
					iteration[p.p.action].Add(p.p);
				});
			iteration.ForEach(p => p.Key.sucess.AddListener(() => Check(p.Value, p.Key)));
		}
		#endregion

		#region Private Methods
		[ContextMenu("StartProgramm")]
		private void _StartProgramm() {
			StartProgramm(actionProgramm);
		}

		private void Check(List<ActionIteration> actions, IAction a) {
			ActionIteration action = null;
			if((action = actions.FirstOrDefault(p => p.index == iter)) != null) {
				Debug.Log($"sucess: {iter}");
				action.actionEvent.Invoke();
				iter++;
			} else {
				Debug.Log($"error: {iter}");
				a.ResetAction();
			}
		}
		#endregion
	}
}