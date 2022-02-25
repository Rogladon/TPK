using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
namespace Assets.Scripts {
	public interface IInteractable {
		public void OnPointerEnter();
		public void OnPointerExit();
		public void OnPointerDown();
		public void OnPointerUp();
	}
}