using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistressManager : MonoBehaviour {

	public float distressCallIntervel = 10f;

	public List<DistressCall> acceptedDistressCall;
	public List<DistressCall> availableDistressCall;
	public List<DistressCall> allDistressCalls;

	public GameObject uiDistressCallPrefab;
	public Transform uiAvailableCallsContainer;
	public Transform uiAcceptedCallsContainer;

	[Header("Info Panel")]
	public TextMeshProUGUI tmpCallName;
	public TextMeshProUGUI tmpCallDescription;
	public Transform uiItemsNeededContainer;
	public Transform uiRewardsContainer;
	public GameObject uiItemPrefab;

	private void Start() {
		StartCoroutine(MakeNewDistressCall());
		UpdateDistressCall();
	}

	private void Update() {
		
	}

	void UpdateDistressCall() {
		GameObject newCall = new GameObject();
		for(int i = 0; i < uiAvailableCallsContainer.childCount; i++) {
			Destroy(uiAvailableCallsContainer.GetChild(i).gameObject);
		}
		int index = 0;
		foreach(DistressCall eachCall in availableDistressCall) {
			newCall = Instantiate(uiDistressCallPrefab, uiAvailableCallsContainer);
			newCall.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = eachCall.callName;
			newCall.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = eachCall.timeRemaining + "";
			newCall.GetComponent<DistressCallInfo>().availableIndex = index++;
		}

		for(int i = 0; i < uiAcceptedCallsContainer.childCount; i++) {
			Destroy(uiAcceptedCallsContainer.GetChild(i).gameObject);
		}
		index = 0;
		foreach(DistressCall eachCall in acceptedDistressCall) {
			newCall = Instantiate(uiDistressCallPrefab, uiAcceptedCallsContainer);
			newCall.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = eachCall.callName;
			newCall.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = eachCall.timeRemaining + "";
			newCall.GetComponent<DistressCallInfo>().acceptedIndex = index++;
		}
	}

	public void DistressCallInfo(int index, bool isAccepted = false) {
		if(isAccepted) {
			tmpCallName.text = acceptedDistressCall[index].callName;
			tmpCallDescription.text = acceptedDistressCall[index].description;
			for(int i = 0; i < uiItemsNeededContainer.childCount; i++) {
				Destroy(uiItemsNeededContainer.GetChild(i).gameObject);
			}
			GameObject item = new GameObject();
			foreach(Item eachItem in acceptedDistressCall[index].itemsNeeded) {
				item = Instantiate(uiItemPrefab, uiItemsNeededContainer);
				item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = eachItem.name;
				item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = eachItem.quantity + "";
			}
		} else {
			tmpCallName.text = availableDistressCall[index].callName;
			tmpCallDescription.text = availableDistressCall[index].description;
			for(int i = 0; i < uiItemsNeededContainer.childCount; i++) {
				Destroy(uiItemsNeededContainer.GetChild(i).gameObject);
			}
			GameObject item = new GameObject();
			foreach(Item eachItem in availableDistressCall[index].itemsNeeded) {
				item = Instantiate(uiItemPrefab, uiItemsNeededContainer);
				item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = eachItem.name;
				item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = eachItem.quantity + "";
			}
		}
	}

	IEnumerator MakeNewDistressCall() {
		while(true) {

			yield return new WaitForSeconds(distressCallIntervel);
		}
	}

}

