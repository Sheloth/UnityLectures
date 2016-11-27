using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackersPrefabs;
	
	private LevelManager levelManager;
	bool isSpawnEnabled;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		Invoke("SetSpawnEnabled", 20-5*levelManager.GetDifficulty());
	}

	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in attackersPrefabs) {
			if(IsTimeToSpawn(attacker) && isSpawnEnabled) {
				Spawn(attacker);
			}
		}	
	}
	
	void SetSpawnEnabled () {
		isSpawnEnabled = true;
	}
	
	bool IsTimeToSpawn (GameObject attackerGameObj) {
		Attacker attacker = attackerGameObj.GetComponent<Attacker>();
	
		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnsPerSecond = 1f / meanSpawnDelay * levelManager.GetDifficulty() * levelManager.levelSpawnRate;
		
		if(Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by framerate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		return Random.value < threshold;
	}
	
	void Spawn (GameObject attackerGameObj) {
		GameObject newAttacker = Instantiate(attackerGameObj) as GameObject;
		newAttacker.transform.parent = transform;
		newAttacker.transform.position = transform.position;
	}
	
}
