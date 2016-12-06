using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private GameManager gameManager;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private bool ballOutOfPlay = false;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay) {
            print(ballOutOfPlay);
            CheckStanding();
        }
    }
    
    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.GetComponent<Ball>()) {
            ballOutOfPlay = true;
            standingDisplay.color = Color.red;
        }
    }


    public void Reset() {
        lastSettledCount = 10;
    }

    int CountStanding() {
        int standingNumber = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                standingNumber++;
            }
        }

        return standingNumber;
    }

    void CheckStanding() {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime) {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled() {
        int pinFall = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();

        gameManager.Bowl(pinFall);

        ballOutOfPlay = false;
        lastStandingCount = -1; // Pins are settled, ball out of the box
        standingDisplay.color = Color.green;
    }

}
