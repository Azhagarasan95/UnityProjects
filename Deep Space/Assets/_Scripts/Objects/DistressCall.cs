using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Call", menuName = "New Distress Call")]
public class DistressCall : ScriptableObject {

	public string callName;
	public string description;
	public float timeRemaining;
	public List<Item> itemsNeeded;
	public List<Item> rewards;
	public bool isAccepted;
	public bool isFailed;
	public bool isSucceeded;

}
