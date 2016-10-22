using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool isAutoplay = false;
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) {
			isAutoplay = true;
		}
		else if(Input.GetKeyDown(KeyCode.S))	{
			isAutoplay = false;
		}
		
		if(!isAutoplay) {
			MouseMovement();
		}
		else {
			AutoMovement();
		}
	}
	
	private void AutoMovement () {
		Vector3 ballPosition = ball.transform.position;		
		Vector3 paddlePosition = new Vector3 (ballPosition.x, this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePosition;
	}
	
	private void MouseMovement () {
		float mousePositionInBlocks = (Input.mousePosition.x / Screen.width * 16);
		
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		paddlePosition.x = Mathf.Clamp(mousePositionInBlocks, 1f, 15f);
		
		this.transform.position = paddlePosition;
	}
}
