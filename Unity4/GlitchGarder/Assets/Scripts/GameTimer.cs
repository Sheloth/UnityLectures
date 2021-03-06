﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;
	
	private AudioSource audioSource;
	private Slider slider;
	private LevelManager levelManager;
	private bool isLevelEnded = false;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find("WinLabel");
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);
		
		if(Time.timeSinceLevelLoad > levelSeconds && !isLevelEnded) {
			isLevelEnded = true;
			Invoke ("LoadNextLevel", audioSource.clip.length);
			audioSource.Play();
			winLabel.SetActive(true);
			DestroyAttackers();
		}
	}
	
	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
	
	void DestroyAttackers() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("DestroyOnWin");
		foreach(GameObject obj in objects) {
			Destroy(obj);
		}
	}
}
