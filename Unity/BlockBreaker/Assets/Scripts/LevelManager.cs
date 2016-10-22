using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel (string name) {
		Debug.Log ("LoadLevel called. Param: " + name);
		ResetBlockCount();
		Application.LoadLevel(name);
	}

	public void Quit () {
		Debug.Log ("Quit called");
		Application.Quit();
	}
	
	public void LoadNextLevel () {
		ResetBlockCount();
		Application.LoadLevel(Application.loadedLevel + 1);	
	}
	
	private void ResetBlockCount () {
		Brick.breakableCount = 0;
	}
	
	public void BlockDestroyed () {
		if(Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
