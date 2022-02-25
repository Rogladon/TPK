using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts {
	public class InputController : MonoBehaviour {
		[System.Serializable]
		private class CursorTexture {
			public static CursorTexture current;

			public Texture2D texture;
			public Vector2 hotspot;
			public CursorMode cursorMode;

			public void Apply() {
				if (current == this) return;
				current = this;
				Cursor.SetCursor(texture, hotspot, cursorMode);
			}
		}
		#region Fields
		[SerializeField] private CursorTexture defaultCursor;
		[SerializeField] private CursorTexture selectCursor;

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
					selectCursor.Apply();
					if(currentInteractable != null && interactable != currentInteractable) {
						interactable.OnPointerEnter();
						currentInteractable.OnPointerExit();
					}
					if (Input.GetMouseButtonDown(0)) interactable.OnPointerDown();
					currentInteractable = interactable;
				} else {
					defaultCursor.Apply();
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