using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    public GameObject currentObject;
    public float grabDistance;
    public Transform objectPivot;
    public float objectSpeed;

    void Start () {
        currentObject = null;

    }
    void FixedUpdate () {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        // layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (!currentObject) {
            if (Input.GetButton ("Fire1")) {
                if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit, grabDistance, layerMask)) {
                    Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * hit.distance, Color.yellow);
                    GrabObject(hit.transform.gameObject);

                } else {
                    Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 1000, Color.white);
                    Debug.Log ("Did not Hit");
                }
            }

        }
        else{
            currentObject.transform.position = Vector3.MoveTowards(currentObject.transform.position,objectPivot.position, objectSpeed*Time.deltaTime);
            if (Input.GetButton("Fire2")){
                currentObject.GetComponent<Rigidbody>().useGravity =true;
                currentObject = null;
            }
        }

    }

    void GrabObject(GameObject obj){
        currentObject = obj;
        currentObject.GetComponent<Rigidbody>().useGravity = false;

    }

}