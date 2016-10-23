using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemy;
	public float speed=3f;
	public float width = 10f;
	public float height = 5f;
	
	private bool isMovingRight = false;
	private float minX;
	private float maxX;
	
	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));
		minX = leftBoundary.x;
		maxX = rightBoundary.x;
	
		foreach(Transform child in transform)
		{
			GameObject enemyInstance = Instantiate(enemy, child.position, Quaternion.identity) as GameObject;
			enemyInstance.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
		MoveFormation();
	}
	
	void MoveFormation () {
		if(isMovingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		if((transform.position.x <= (minX + width*0.5f)) || (transform.position.x >= (maxX - width*0.5f))) {
			isMovingRight = !isMovingRight;
		}
	}	
	
	void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
}
