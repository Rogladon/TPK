using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts {
	public class CreateActionProgramm : MonoBehaviour {

		#region Fields
		private List<IAction> actions = new List<IAction>();

		[SerializeField] private ActionProgramm currentProgramm;
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		private void Start() {
			actions = FindObjectsOfType<MonoBehaviour>().Where(p => p is IAction)
				.Select(p => p as IAction)
				.ForEach(p => p.sucess.AddListener(() => AddAction(p))).ToList();
		}
		private void AddAction(IAction action) {
			currentProgramm?.AddAction(new ActionIteration() {
				actionObject = action.mono.gameObject,
				actionEvent = new UnityEngine.Events.UnityEvent(),
				tutorial = ""
			});
		}
		[ContextMenu("Create")]
		public void CreateProgramm() {
			currentProgramm = new GameObject("ActionProgramm").AddComponent<ActionProgramm>();
		}
		#endregion
	}
}