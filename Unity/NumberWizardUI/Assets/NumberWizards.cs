using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizards : MonoBehaviour {

	int max;
	int min;
	int guess;
	public Text text;
	int maxGuesses;

	// Use this for initialization
	void Start () {
		GameStart();
	}
	
	void GameStart () {
		max = 1000;
		min = 1;
		maxGuesses = 12; 
		
		NextGuess();
	}
	
	void NextGuess() {
		guess = Random.Range(min, max+1);
		text.text = "Your number is " + guess.ToString();
		maxGuesses--;
		if(maxGuesses == 0) {
			Application.LoadLevel("Win");
		}
	}
	
	public void GuessHigher() {
		min = guess;
		NextGuess();
	}
	
	public void GuessLower() {
		max = guess;
		NextGuess();
	}
	
	public void GuessEqual() {
		Application.LoadLevel("Lose");
	}
}