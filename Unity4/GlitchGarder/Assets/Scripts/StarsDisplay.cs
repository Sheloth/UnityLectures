using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour {

	Text text;
	int starsAmount = 100;
	
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
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
