using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float launchSpeed = 1;

    private Rigidbody ballRigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        Launch();
    }

    private void Launch()
    {
        ballRigidBody.velocity = new Vector3(0, 0, launchSpeed);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
