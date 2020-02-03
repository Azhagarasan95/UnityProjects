using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	public GameObject uiDistressCallsTab;
	public bool isDistressCallsTabActive = false;

	private void Start() {
		
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Tab)) {
			uiDistressCallsTab.GetComponent<Animator>().SetBool("isDistressCallsTabActive", isDistressCallsTabActive = !isDistressCallsTabActive);
		}
	}

}
