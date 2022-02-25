using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts {
	public class InputController : MonoBehaviour {

		#region Fields
		private IInteractable currentInteractable = null;
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		private void Update() {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				IInteractable interactable = null;
				if(hit.transform.TryGetComponent(out interactable)) {
					if(currentInteractable != null && interactable != currentInteractable) {
						interactable.OnPointerEnter();
						currentInteractable.OnPointerExit();
					}
					if (Input.GetMouseButtonDown(0)) interactable.OnPointerDown();
					currentInteractable = interactable;
				} else {
					if (currentInteractable != null) currentInteractable.OnPointerExit();
				}
				if (Input.GetMouseButtonUp(0)) {
					if (currentInteractable != null) currentInteractable.OnPointerUp();
				}
			}
		}
		#endregion
	}
}