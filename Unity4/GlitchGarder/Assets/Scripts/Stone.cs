using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	Animator animator;

	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}

	public void Attack() {
		animator.SetTrigger("attackedTrigger");
	}
	
}
