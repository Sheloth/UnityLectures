using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 50f;

    private Ball ball;
    private bool ballEnteredBox = false;
    private float lastChangeTime;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
       standingDisplay.text = CountStanding().ToString();

        if(ballEnteredBox) {
            CheckStanding();
        }
	}

    public void RaisePins () {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                pin.transform.Translate( new Vector3(0, distanceToRaise, 0));
            }
        }
    }

    public void LowerPins () {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                pin.transform.Translate(new Vector3(0, -distanceToRaise, 0));
            }
        }
    }

    public void RenewPins() {
        Debug.Log("Renew");
    }

    int CountStanding () {
        int standingNumber = 0;

        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if(pin.IsStanding()) {
                standingNumber++;
            }
        }

        return standingNumber;
    }

    void CheckStanding () {
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if((Time.time - lastChangeTime) > settleTime) {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled () {
        ballEnteredBox = false;
        ball.Reset();
        lastStandingCount = -1; // Pins are settled, ball out of the box
        standingDisplay.color = Color.green;
    }

    void OnTriggerEnter (Collider collider) {
        GameObject hitObject = collider.gameObject;

        if(hitObject.GetComponent<Ball>()) {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider) {
        GameObject hitObject = collider.gameObject;

        if (hitObject.GetComponent<Pin>()) {
            Destroy(hitObject);
        }
    }

}
