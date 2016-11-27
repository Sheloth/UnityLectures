using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public float loadLevelDelay;
	public float levelSpawnRate = 1;
	
	int difficulty = 1;
	
	void Start () {
		if(loadLevelDelay > 0) {
			Invoke("LoadNextLevel", loadLevelDelay);
		}
		
		difficulty = PlayerPrefsManager.GetDifficulty();
		Debug.Log("Difficulty = " + difficulty);
	}
	
	public void LoadLevel (string name) {
		Debug.Log ("LoadLevel called. Param: " + name);
		Application.LoadLevel(name);
	}

	public void Quit () {
		Debug.Log ("Quit called");
		Application.Quit();
	}
	
	public void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);	
	}
	
	public int GetDifficulty () {
		return difficulty;
	}
}
