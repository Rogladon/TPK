using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
	public class ActionComponent : MonoBehaviour, IAction {

		#region Fields
		[SerializeField] private UnityEvent actionSucess;
		[SerializeField] private UnityEvent actionError;
		#endregion

		#region Properties
		public UnityEvent sucess => actionSucess;

		public UnityEvent error => actionError;
		public UnityEvent reset { get; }
		#endregion

		#region Public Methods
		public void ResetAction() {
			
		}
		#endregion

		#region Private Methods

		#endregion
	}
}