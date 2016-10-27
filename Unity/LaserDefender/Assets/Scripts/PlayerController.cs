using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 3.0f;
	public GameObject projectile;
	public float projectileSpeed = 7.0f;
	public float fireRate = 0.2f;
	
	float maxHealth = 300f;
	
	float health;
	
	public AudioClip fireSound;
	public AudioClip deathSound;
	public AudioClip bonusSound;
	
	HealthBarController healthBar = null;
	
	float minX;
	float maxX;
	float padding = 1f;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftmost.x + padding;
		maxX = rightmost.x - padding;
		health = maxHealth;
		
		healthBar = GameObject.Find("HealthBar").GetComponent<HealthBarController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.00001f, fireRate);
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp(transform.position.x, minX, maxX);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void Fire () {
		GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		projectileInstance.GetComponent<Rigidbody2D>().velocity += new Vector2(0f, projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		string tag = collider.tag;
		
		if(tag == "Missile") {
			Projectile missile = collider.gameObject.GetComponent<Projectile>();
			if(missile) {
				health -= missile.GetDamage();
				missile.Hit();
				healthBar.RemoveHealth();
				if(health <= 0) {
					AudioSource.PlayClipAtPoint(deathSound, transform.position);
					Die();	
				}
			}
		}
		else if(tag == "Bonus") {
			HealthBonus bonus = collider.gameObject.GetComponent<HealthBonus>();
			if(bonus) {
				if(health < maxHealth) {
					AudioSource.PlayClipAtPoint(bonusSound, transform.position);
				}
				health += 100;
				if(health > maxHealth)
					health = maxHealth;
		
				healthBar.AddHealth();
				bonus.Gained();
			}
		} 
		
	}
	
	void Die () {
		LevelManager manager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		Destroy(gameObject);
		manager.LoadLevel("Lose");
	}	
}
