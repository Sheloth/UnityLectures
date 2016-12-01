using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public bool inPlay;

    private Rigidbody ballRigidBody;
    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        ballRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        ballRigidBody.useGravity = false;

        inPlay = false;
    }

    public void Launch(Vector3 velocity) {
        inPlay = true;
        ballRigidBody.useGravity = true;
        ballRigidBody.velocity = velocity;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update() {

    }
}
