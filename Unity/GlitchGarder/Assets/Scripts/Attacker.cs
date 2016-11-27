using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySecond;
	
	[Range(1, 200)]
	public float damage = 20;
	
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget) {
			animator.SetBool("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D() {
	}
	
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget () {
		if(currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			
			if(health) {
				health.DealDamage(damage);
			}
			
			Stone stone = currentTarget.GetComponent<Stone>();
			if(stone) {
				stone.Attack();
			}
		}
	}
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
