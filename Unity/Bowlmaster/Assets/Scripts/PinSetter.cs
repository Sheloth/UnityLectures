using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
    public GameObject pinSet;

    private ActionMaster actionMaster = new ActionMaster();
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private bool ballOutOfPlay = false;

    private Ball ball;
    private Animator animator;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       standingDisplay.text = CountStanding().ToString();

        if(ballOutOfPlay) {
            CheckStanding();
        }
	}

    public void SetBallOutOfPlay() {
        ballOutOfPlay = true;
    }

    public void RaisePins () {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Raise();
            pin.transform.rotation = Quaternion.Euler(new Vector3(270f, 0, 0));
        }
    }

    public void LowerPins () {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }

    public void RenewPins() {
        GameObject newPinSet = Instantiate(pinSet, new Vector3(0f, 0f, 1829f), Quaternion.identity) as GameObject;
        newPinSet.transform.Translate(new Vector3(0, 40f, 0), Space.World);
        lastSettledCount = 10;
    }

    int CountStanding () {
        int standingNumber = 0;

        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if(pin.IsStanding()) {
                standingNumber++;
                standingDisplay.color = Color.red;
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
        int pinFall = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log(action);

        switch(action) {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                break;
            case ActionMaster.Action.EndGame:
            default:
                throw new UnityException("Unhadnled action");
        }

        ballOutOfPlay = false;
        ball.Reset();
        lastStandingCount = -1; // Pins are settled, ball out of the box
        standingDisplay.color = Color.green;
    }

}
