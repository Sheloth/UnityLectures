using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;
    public float distanceToRaise = 40f;

    private float thresholdEps = 0.5f;

    Rigidbody pinRigidBody;

    // Use this for initialization
    void Start () {
        pinRigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Raise () {
        if(IsStanding()) {
            pinRigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
    }

    public void Lower() {
        if (IsStanding()) {
            transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
            pinRigidBody.useGravity = true;
        }
    }

    public bool IsStanding () {
        Vector3 rotation = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotation.x) - thresholdEps;
        float tiltInZ = Mathf.Abs(rotation.z) - thresholdEps;

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
