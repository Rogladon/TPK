using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
namespace Assets.Scripts {
	public class Tutorial : MonoBehaviour {
		#region Fields
		private const string noTutoril = "Выполните действие";

		[SerializeField] private ActionProgramm actionProgramm;
		[SerializeField] private Text tutorialOutput;
		[SerializeField] private ActionController actionController;

		private int iteration = -1;
		private bool active = false;
		#endregion


		#region Private Methods
		private void Update() {
			if(iteration != actionController.currentIteration) {
				iteration = actionController.currentIteration;
				if (iteration >= actionProgramm.actions.Count) {
					tutorialOutput.text = $"Конец!";
					return;
				}
				tutorialOutput.text = $"{iteration+1}. {(active?actionProgramm.actions[iteration].tutorial:noTutoril)}";
			}
		}
		public void SetActive(bool active) {
			this.active = active;
		}
		public  void SetProgramm(ActionProgramm programm) {
			iteration = -1;
			SetActive(true);
			actionProgramm = programm;
		}
		#endregion
	}
}