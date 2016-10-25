using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10f;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	
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
		
		Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0f);
		GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity += new Vector2(0, -projectileSpeed);
	}

	void OnTriggerEnter2D (Collider2D collider) {
			Projectile missile = collider.gameObject.GetComponent<Projectile>();
			
			if(missile) {
				health -= missile.GetDamage();
				missile.Hit();
				if(health <= 0) {
					scoreKeeper.AddScore(scoreValue);
					Destroy(gameObject);
				}
			}
	}
}
