using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerExit(Collider collider) {
        GameObject hitObject = collider.gameObject;

        if (hitObject.GetComponent<Pin>()) {
            Destroy(hitObject);
        }
    }
}
