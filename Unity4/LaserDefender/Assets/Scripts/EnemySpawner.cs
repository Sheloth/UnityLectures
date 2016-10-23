using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemy;
	public float speed=3f;
	public float width = 10f;
	public float height = 5f;
	public float spawnDelay = 0.5f;
	
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
		SpawnUntilFull();
	}
	
	// Update is called once per frame
	void Update () {
		MoveFormation();
		if(AllEnemiesDestroyed()) {
			SpawnUntilFull();
		}
	}
	
	void SpawnEnemies () {
		foreach(Transform child in transform) {
			GameObject enemyInstance = Instantiate(enemy, child.position, Quaternion.identity) as GameObject;
			enemyInstance.transform.parent = child;
		}
	}
	
	void SpawnUntilFull () {
		Transform nextPosition = NextFreePosition();
		if(nextPosition) {
			GameObject enemyInstance = Instantiate(enemy, nextPosition.position, Quaternion.identity) as GameObject;
			enemyInstance.transform.parent = nextPosition;
		}
		if(NextFreePosition()) {
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}
	
	Transform NextFreePosition () {
		foreach(Transform childObject in transform) {
			if(childObject.childCount == 0) {
				return childObject;
			}
		}
		
		return null;
	}
	
	bool AllEnemiesDestroyed () {
		foreach(Transform childObject in transform) {
			if(childObject.childCount > 0) {
				return false;
			}
		}
		
		return true;
	}
	
	void MoveFormation () {
		if(isMovingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		if(transform.position.x <= (minX + width*0.5f)) {
			isMovingRight = true;
		}
		else if(transform.position.x >= (maxX - width*0.5f)) {
			isMovingRight = false;
		}
	}	
	
	void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
}
