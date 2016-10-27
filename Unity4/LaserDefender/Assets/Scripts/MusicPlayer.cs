using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startMusic;
	public AudioClip gameMusic;
	public AudioClip endMusic;
	
	private AudioSource source;

	// Use this for initialization
	void Start () {
		if(instance != null) {
			Destroy(gameObject);
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);	
			source = GetComponent<AudioSource>();
			source.clip = startMusic;
			source.loop = true;
			source.Play();
		}

	}
	
	public void OnLevelWasLoaded (int level) {
		source.Stop();
		if(level == 0) {
			source.clip = startMusic;
		}
		else if(level == 1) {
			source.clip = gameMusic;
		}
		else if(level == 2) {
			source.clip = endMusic;
		}
		source.loop = true;
		source.Play();
	}
}
