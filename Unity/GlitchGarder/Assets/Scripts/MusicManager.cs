using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicArray;

	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded (int level) {
		AudioClip currentLevelMusic = levelMusicArray[level];
		
		if(currentLevelMusic) {
			audioSource.clip = currentLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void SetVolume (float volume) {
		audioSource.volume = volume;
	}
}
