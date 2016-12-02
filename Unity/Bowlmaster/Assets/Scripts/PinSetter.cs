using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;

    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       standingDisplay.text = CountStanding().ToString();
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
