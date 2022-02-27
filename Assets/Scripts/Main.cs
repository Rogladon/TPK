using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
	public class Main : MonoBehaviour {
		[SerializeField] private ActionController actionController;
		[SerializeField] private Tutorial tutorialController;

		[SerializeField] private ActionProgramm up;
		[SerializeField] private GameObject chiceProgramm;
		[SerializeField] private GameObject menu;
		private void Start() {
			Time.timeScale = 0;
		}
		public void StartProgrammUp(bool tutorial) {
			Continue();
			actionController.StartProgramm(up);
			if (tutorial) tutorialController.SetProgramm(up);
			else tutorialController.SetActive(false);
			chiceProgramm.SetActive(false);
			menu.SetActive(false);
		}
		public void Continue() {
			Time.timeScale = 1;
			menu.SetActive(false);
		}
		public void Restart() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		public void Quit() {
			Application.Quit();
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Escape) && menu.activeSelf == false && chiceProgramm.activeSelf == false) {
				Time.timeScale = 0;
				menu.SetActive(true);
			}
		}
	}
}
