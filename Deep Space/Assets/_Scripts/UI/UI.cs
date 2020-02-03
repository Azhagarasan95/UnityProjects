using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	[Header("Stats")]
	public Image imgHealthBar;
	public Image imgFuelBar;

	[Header("UI")]
	public GameObject uiGameOver;
	public GameObject uiGameFinished;
	public GameObject uiPlayerStats;

	PlayerShip scriptPlayerShip;

	private void Start() {
		scriptPlayerShip = FindObjectOfType<PlayerShip>();
		uiGameOver.SetActive(false);
		uiGameFinished.SetActive(false);
		uiPlayerStats.SetActive(false);
		Time.timeScale = 1;
	}

	private void Update() {

		UpdateStats();

	}

	void UpdateStats() {
		imgHealthBar.fillAmount = (float) scriptPlayerShip.currentHealth / (float) scriptPlayerShip.maxHealth;
		imgFuelBar.fillAmount = (float) scriptPlayerShip.currentFuel / (float) scriptPlayerShip.maxFuel;
	}

	public void RestartGame() {
		SceneManager.LoadScene(1);
	}

	public void GoToMainMenu() {
		SceneManager.LoadScene(0);
	}

	public void ExitGame() {
		Application.Quit();
	}

}
