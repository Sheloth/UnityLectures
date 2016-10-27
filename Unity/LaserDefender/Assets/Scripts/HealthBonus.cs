using UnityEngine;
using System.Collections;

public class HealthBonus : MonoBehaviour {

	public void Gained () {
		Destroy(gameObject);
	}
}
