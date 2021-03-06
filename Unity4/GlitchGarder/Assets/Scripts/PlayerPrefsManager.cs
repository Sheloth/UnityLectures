﻿using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume (float volume) {
		if(volume >= 0f && volume <= 1f) {
				PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else {
			Debug.LogError ("Master volume out of range");
		}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.5f);
	}

	public static void UnlockLevel (int level) {
		if(level <= Application.levelCount -1) {
			PlayerPrefs.SetInt(LEVEL_KEY+level.ToString(), 1); // 1 = true
		}
		else {
			Debug.LogError ("Level value out of range");
		}
	}
	
	public static bool GetLevelUnlocked (int level) {
		if(level <= Application.levelCount -1) {
			return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY+level.ToString()) == 1;
		}
		else {
			Debug.LogError ("Trying to query level not in build order");
			return false;
		}
	}
	
	public static void SetDifficulty (int difficulty) {
		if(difficulty >= 1 && difficulty <= 3) {
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		}
		else {
			Debug.LogError ("Difficulty value out of range");
		}
	}
	
	public static int GetDifficulty () {
		return PlayerPrefs.GetInt(DIFFICULTY_KEY, 2);
	}
}
