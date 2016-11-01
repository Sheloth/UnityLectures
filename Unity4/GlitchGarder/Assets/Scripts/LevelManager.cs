using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public float loadLevelDelay;
	
	void Start () {
		if(loadLevelDelay > 0) {
			Invoke("LoadNextLevel", loadLevelDelay);
		}
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
}
