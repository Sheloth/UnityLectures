using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

	LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnMouseDown () {
		levelManager.LoadLevel("01a MainMenu");
	}
}
