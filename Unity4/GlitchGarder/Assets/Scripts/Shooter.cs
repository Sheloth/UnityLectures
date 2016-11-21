using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		
		animator = GameObject.FindObjectOfType<Animator>();
		SetMyLaneSpawner();
		print(myLaneSpawner);
	}
	
	void Update () {
		if(IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		}
		else {
			animator.SetBool ("isAttacking", false);
		}
	}
	
	// Find spwaner on the same line
	void SetMyLaneSpawner () {
		Spawner[] spawners = FindObjectsOfType<Spawner>();
		foreach(Spawner spawner in spawners) {
			if(spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError(name + "can't find spawner");
	}
	
	bool IsAttackerAheadInLane () {
		if(myLaneSpawner.transform.childCount == 0) {
			return false;
		}
		
		foreach(Transform attackers in myLaneSpawner.transform) {
			if(attackers.transform.position.x > transform.position.x) {
				return true;
			}
		}
		
		// Attackers are behind
		return false;
	}
	
	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
