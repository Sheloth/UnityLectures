using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallPosition;
	private bool hasGameStarted = false;
		
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallPosition = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasGameStarted)
		{
			this.transform.position = paddle.transform.position + paddleToBallPosition;
			if(Input.GetMouseButtonDown(0))
			{
				hasGameStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D obj) {
		Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.4f), Random.Range(-0.2f, 0.4f));
		this.GetComponent<Rigidbody2D>().velocity += tweak;

		if(hasGameStarted) {
			this.GetComponent<AudioSource>().Play();
		}
	}
}
