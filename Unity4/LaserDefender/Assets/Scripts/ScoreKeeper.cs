using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	
	public static int totalScores = 0;
	
	private Text text;
	
	void Start () {
		text = GetComponent<Text>();
		text.text = "0";
		Reset();
	}
	
	// Use this for initialization
	public void AddScore (int score) {
		totalScores += score;
		text.text = totalScores.ToString();
	} 
	
	public static void Reset () {
		totalScores = 0;
	}
}
