using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;

    private Vector3 dragStart;
    private Vector3 dragEnd;
    private float startTime;
    private float endTime;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball>();
	}
    
    public void DragStart() {
        if (!ball.inPlay) {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd() {
        if (!ball.inPlay) {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

            ball.Launch(launchVelocity);
        }
    }

    public void MoveStart (float amount) {
        if (!ball.inPlay) {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
