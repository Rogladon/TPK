using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
	public class InteractiveClick : AInteractive, IAction {


		#region Fields
		[Header("Action Events")]
		[SerializeField] private UnityEvent actionSucess;
		[SerializeField] private UnityEvent actionError;
		[SerializeField] private UnityEvent actionReset;
		[Header("Config")]
		[SerializeField] private bool invert;

		private bool selected;
		#endregion

		#region Properties
		public MonoBehaviour mono => this;
		public UnityEvent sucess => actionSucess;

		public UnityEvent error => actionError;
		public UnityEvent reset => actionReset;
		#endregion

		#region Public Methods


		public void ResetAction() {
			reset.Invoke();
			Debug.Log($"ResetACtion for object: {this}");
		}
		#endregion

		#region Private Methods
		protected override void _OnPointerDown() {
			sucess.Invoke();
		}
		#endregion


	}
}