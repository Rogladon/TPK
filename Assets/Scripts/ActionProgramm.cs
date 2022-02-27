using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
	[System.Serializable]
	public class ActionIteration {
		public GameObject actionObject;
		[TextArea] public string tutorial;
		public UnityEvent actionEvent;
		public IAction action => actionObject.GetComponent<IAction>();
		public int index { get; set; }

	}
	public class ActionProgramm : MonoBehaviour {

		#region Fields
		[SerializeField] private List<ActionIteration> actionsObjects = new List<ActionIteration>();
		#endregion

		#region Properties
		public List<ActionIteration> actions => actionsObjects;
		#endregion

		#region Public Methods
		public void AddAction(ActionIteration iter) {
			actionsObjects.Add(iter);
		}
		#endregion

		#region Private Methods

		#endregion
	}
}