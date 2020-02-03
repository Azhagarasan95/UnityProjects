using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawn : MonoBehaviour {

	public GameObject enemyPrefab;

	private void Start() {
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy() {
		while(true) {
			Instantiate(enemyPrefab, new Vector3(new System.Random().Next(-5, 5), 6, 0), Quaternion.identity);
			yield return new WaitForSeconds(3);
		}
	}

}
