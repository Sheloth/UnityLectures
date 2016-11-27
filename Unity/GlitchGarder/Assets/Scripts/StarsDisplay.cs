using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour {

	[Range(0,1000)]
	public int starsAmount = 100;
	
	Text text;
	LevelManager levelManager;
	
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		starsAmount = starsAmount + (3-levelManager.GetDifficulty())*60;
		UpdateDisplay();
	}
	
	void UpdateDisplay () {
		text.text = starsAmount.ToString();	
	}
	
	public void AddStars(int amount) {
		starsAmount += amount;
		UpdateDisplay();
	}
	
	public Status UseStars(int amount) {
	
		if(starsAmount >= amount) {
			starsAmount -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		
		return Status.FAILURE;
	}
	
}
