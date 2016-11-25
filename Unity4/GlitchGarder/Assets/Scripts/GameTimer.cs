using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;
	
	private AudioSource audioSource;
	private Slider slider;
	private LevelManager levelManager;
	private bool isLevelEnded = false;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);
		
		if(Time.timeSinceLevelLoad > levelSeconds && !isLevelEnded) {
			audioSource.Play();
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isLevelEnded = true;
		}
	}
	
	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
}
