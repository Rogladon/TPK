using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
namespace Assets.Scripts {
	public class Tutorial : MonoBehaviour {
		#region Fields
		[SerializeField] private ActionProgramm actionProgramm;
		[SerializeField] private Text tutorialOutput;
		[SerializeField] private ActionController actionController;

		private int iteration = -1;
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		private void Update() {
			if(iteration != actionController.currentIteration) {
				iteration = actionController.currentIteration;
				if (iteration >= actionProgramm.actions.Count) {
					tutorialOutput.text = $"Конец!";
					return;
				}
				tutorialOutput.text = $"{iteration+1}. {actionProgramm.actions[iteration].tutorial}";
			}
		}
		#endregion
	}
}