using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour {

	[Range(5, 30)]
	public float spawnRate = 10f;
	
	[Range(1, 500)]
	public int bonusAmount = 40;

	Animator animator;
	StarsDisplay starsDisplay;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		starsDisplay = FindObjectOfType<StarsDisplay>();
		InvokeRepeating("SpawnStar", spawnRate, spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void SpawnStar () {
		animator.CrossFade("Star rising",0);
	}
	
	public void AddStars() {
		starsDisplay.AddStars(bonusAmount);
	}
}
