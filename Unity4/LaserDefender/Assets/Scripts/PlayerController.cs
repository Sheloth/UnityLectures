using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 3.0f;
	public GameObject projectile;
	public float projectileSpeed = 7.0f;
	public float fireRate = 0.2f;
	public float health = 150f;
	
	public AudioClip fireSound;
	public AudioClip deathSound;
	
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
		projectileInstance.rigidbody2D.velocity += new Vector2(0f, projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		
		if(missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0) {
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				Destroy(gameObject);
			}
		}
	}
	
}
