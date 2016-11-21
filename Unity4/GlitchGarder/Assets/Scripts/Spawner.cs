using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackersPrefabs;

	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in attackersPrefabs) {
			if(IsTimeToSpawn(attacker)) {
				Spawn(attacker);
			}
		}	
	}
	
	bool IsTimeToSpawn (GameObject attackerGameObj) {
		Attacker attacker = attackerGameObj.GetComponent<Attacker>();
	
		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by framerate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		if(Random.value < threshold) {
			return true;
		}
		else {
			return false;
		}
	}
	
	void Spawn (GameObject attackerGameObj) {
		GameObject newAttacker = Instantiate(attackerGameObj) as GameObject;
		newAttacker.transform.parent = transform;
		newAttacker.transform.position = transform.position;
	}
	
}
