using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {

	int max;
	int min;
	int guess;

	// Use this for initialization
	void Start () {
		GameStart();
	}
	
	void GameStart () {
		print ("=============================");
		max = 1000;
		min = 1;
		guess = 500;
		print ("Hello");
		print ("Pick a number in your head, but don't tell me.");
		
		print ("The highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
		print ("Up for higher, Down for lowe, Return for equal");
		
		max += 1;
		
		NextGuess();
	}
	
	void NextGuess() {
		guess = (min + max) / 2;
		print ("Min " + min + " Max " + max);
		print ("Is the number lower or higher than " + guess);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			// print ("Up key pressed");
			min = guess;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			// print ("Down key pressed");
			max = guess;
			guess = (min + max) / 2;
			NextGuess();
		}
		else 	if (Input.GetKeyDown(KeyCode.Return)) {
			print ("I won");
			GameStart();
		}
	}
}