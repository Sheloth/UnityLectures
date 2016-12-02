using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public bool inPlay;

    private Vector3 ballStartPos;
    private Rigidbody ballRigidBody;
    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        ballRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        ballRigidBody.useGravity = false;
        inPlay = false;
        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity) {
        inPlay = true;
        ballRigidBody.useGravity = true;
        ballRigidBody.velocity = velocity;
        audioSource.Play();
    }

    public void Reset() {
        inPlay = false;
        transform.position = ballStartPos;
        ballRigidBody.useGravity = false;
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
    }
}
