using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject projectile;
	public GameObject healthBonus;
	public float health = 150f;
	public float projectileSpeed = 10f;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	public float healthBonusProbability = 0.05f;
	public float bousSpeed = 10f;
	
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start () { 
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update () {
		float probabiltity  = Time.deltaTime * shotsPerSecond;
		if(Random.value < probabiltity) {
			Fire();
		}
	}
	
	void Fire () {
		GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity += new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void OnTriggerEnter2D (Collider2D collider) {
			Projectile missile = collider.gameObject.GetComponent<Projectile>();
			
			if(missile) {
				health -= missile.GetDamage();
				missile.Hit();
				if(health <= 0) {
					Death();
				}
			}
	}
	
	void Death() {
		scoreKeeper.AddScore(scoreValue);
		if(Random.value < healthBonusProbability) {
			SpawBonus();
		}
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
	}
	
	void SpawBonus() {
		GameObject bonus = Instantiate(healthBonus, transform.position, Quaternion.identity) as GameObject;
		bonus.GetComponent<Rigidbody2D>().velocity += new Vector2(0, -bousSpeed);
	}
}
