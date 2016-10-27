using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
	
	public Sprite[] sprites;
	
	private int minHealth = 1;
	private int maxHealth;
	private int currentHealth;
	
	Image image = null;

	void Start () {
		image = GameObject.Find("Health").GetComponent<Image>();
		maxHealth = sprites.Length;
		currentHealth = maxHealth;
		UpdateImage();
	}
	
	void UpdateImage () {
		image.sprite = sprites[currentHealth - 1];
	} 

	public void AddHealth () {
		if(currentHealth != maxHealth) {
			currentHealth++;
			UpdateImage();
		}
	}
	
	public void RemoveHealth () {
		if(currentHealth != minHealth) {
			currentHealth--;
			UpdateImage();
		}
	}
}
