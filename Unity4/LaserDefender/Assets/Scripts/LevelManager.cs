using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
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
