using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool isGameFinished;
	public bool isGameOver;

	UI scriptUI;

	private void Start() {
		scriptUI = FindObjectOfType<UI>();
		scriptUI.uiPlayerStats.SetActive(true);
		Time.timeScale = 1;
	}

	private void Update() {
		if(isGameFinished) {
			scriptUI.uiGameFinished.SetActive(true);
			scriptUI.uiPlayerStats.SetActive(false);
			Time.timeScale = 0;
		}
		if(isGameOver) {
			scriptUI.uiGameOver.SetActive(true);
			scriptUI.uiPlayerStats.SetActive(false);
			Time.timeScale = 0;
		}
	}

}
