using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caballetes : MonoBehaviour
{
    public static int count;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("caballete") && other.name == gameObject.name){
            count+=1 ;
            if (count== 3){
                BigBrain.bigBrain.stage3Complete();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("caballete") && other.name ==gameObject.name){
            count-=1;
        }
    }

}
