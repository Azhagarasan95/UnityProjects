using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

	public GameObject uiCredits;

	private void Start() {
		CloseCredits();
	}

	public void Play() {
		SceneManager.LoadScene(1);
	}

	public void ExitGame() {
		Application.Quit();
	}

	public void ShowCredits() {
		uiCredits.SetActive(true);
	}

	public void CloseCredits() {
		uiCredits.SetActive(false);
	}

}
