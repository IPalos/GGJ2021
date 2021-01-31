using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyhole : MonoBehaviour {

private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("key")){
        BigBrain.bigBrain.stage1Complete();
        other.gameObject.SetActive(false);  
        GameObject.Find("cam").GetComponent<pickup>().currentObject=null;      
    }
}

}