using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;

	private int hits = 0;
	private bool isBreakable;
	
	public LevelManager levelManager;
	public AudioClip sound;
	public Sprite[] sprites;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		isBreakable = (this.tag ==  "Breakable");
		if(isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D (Collision2D obj) {
		if(isBreakable)
		{
			HandleCollision();
		}
	}
	
	private void HandleCollision () {
		AudioSource.PlayClipAtPoint(sound, this.transform.position);
		int maxHits = sprites.Length + 1;
		hits++;
		if(hits >= maxHits)	{
			breakableCount--;
			
			GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = GetComponent<SpriteRenderer>().color;
			
			Destroy(gameObject);
			levelManager.BlockDestroyed();
		}
		else {
			LoadSprite();
		}
	}
	
	private void LoadSprite () {
		int spriteIndex = hits - 1;
		this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
	}
	
	private void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
}
