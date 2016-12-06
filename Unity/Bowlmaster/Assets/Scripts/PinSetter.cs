using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;

    private Animator animator;
    private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void RaisePins () {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Raise();
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
        pinCounter.Reset();
    }

    public void PerfomeAction(ActionMaster.Action action) {
        switch (action) {
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
    }

}
