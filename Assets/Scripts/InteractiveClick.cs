using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
	public class InteractiveClick : AInteractive, IAction {


		#region Fields
		[SerializeField] private UnityEvent actionSucess;
		[SerializeField] private UnityEvent actionError;
		#endregion

		#region Properties
		public UnityEvent sucess => actionSucess;

		public UnityEvent error => actionError;
		#endregion

		#region Public Methods


		public void ResetAction() {
			throw new NotImplementedException();
		}
		#endregion

		#region Private Methods
		protected override void _OnPointerDown() {
			sucess.Invoke();
		}
		#endregion


	}
}