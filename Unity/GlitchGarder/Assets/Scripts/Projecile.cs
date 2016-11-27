using UnityEngine;
using System.Collections;

public class Projecile : MonoBehaviour {

	public float speed = 1;
	public float damage = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health  = collider.gameObject.GetComponent<Health>();
		
		if(attacker && health) {
			health.DealDamage (damage);
			Destroy (gameObject);
		}
	}
}
