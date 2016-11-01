using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	MusicManager musicManager;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if(musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.SetVolume(volume);
		}
		else {
			Debug.LogError("MusicManager not found");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
