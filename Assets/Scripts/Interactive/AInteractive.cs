using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
	public class AInteractive : MonoBehaviour, IInteractable {

		#region Fields
		[Header("Interactive Events")]
		[SerializeField] private UnityEvent _pointerDown;
		[SerializeField] private UnityEvent _pointerUp;
		[SerializeField] private UnityEvent _pointerEnter;
		[SerializeField] private UnityEvent _pointerExit;
		#endregion

		#region Properties
		public UnityEvent pointerDown => _pointerDown;
		public UnityEvent pointerUp => _pointerUp;
		public UnityEvent pointerEnter => _pointerEnter;
		public UnityEvent pointerExit => _pointerExit;
		#endregion

		#region Public Methods
		public void OnPointerDown() {
			pointerDown.Invoke();
			_OnPointerDown();
		}

		public void OnPointerEnter() {
			pointerEnter.Invoke();
			_OnPointerEnter();
		}

		public void OnPointerExit() {
			pointerExit.Invoke();
			_OnPointerExit();
		}

		public void OnPointerUp() {
			pointerUp.Invoke();
			_OnPointerUp();
		}
		#endregion

		#region Protected Methods
		protected virtual void _OnPointerDown() {
			
		}

		protected virtual void _OnPointerEnter() {
			
		}

		protected virtual void _OnPointerExit() {
			
		}

		protected virtual void _OnPointerUp() {
			
		}
		#endregion

	}
}