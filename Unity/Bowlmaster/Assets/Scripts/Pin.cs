using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsStanding () {
        Vector3 rotation = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotation.x);
        float tiltInZ = Mathf.Abs(rotation.z);

        if (tiltInX > 180) {
            tiltInX = 360 - tiltInX;
        }
        if (tiltInZ > 180) {
            tiltInZ = 360 - tiltInZ;
        }

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
            return true;
        }
        else {
            return false;
        }
    }
}
