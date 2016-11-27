using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private StarsDisplay starDisplay;
	
	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find("Defenders");
		if(!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
		
		starDisplay =FindObjectOfType<StarsDisplay>();
	}
	
	void OnMouseDown () {
		Vector2 pos = SnapToGrid(CalculateWorldPointOfMouseClick());
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<Defender>().starCost;
		
		if(starDisplay.UseStars(defenderCost) == StarsDisplay.Status.SUCCESS) {
			SpawnDefender (pos, defender);
		}
		else {
			Debug.Log("Insufficient stars to spawn");
		}
	}

	void SpawnDefender (Vector2 pos, GameObject defender) {
		GameObject newDefender = Instantiate (defender, pos, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		Vector2 worldPos = new Vector2(Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
		return worldPos;
	}
	
	Vector2 CalculateWorldPointOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
	
		Vector3 screenVec = new Vector3(mouseX, mouseY, distanceFromCamera);
	
		Vector2 worldPos = myCamera.ScreenToWorldPoint(screenVec);
		
		return worldPos;
	}
}
