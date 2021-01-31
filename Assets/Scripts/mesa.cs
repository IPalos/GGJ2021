using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesa : MonoBehaviour
{
public int count = 1;
 
 private void OnTriggerEnter(Collider other) {
     if(other.CompareTag("lata")){
         count+=1;
         if (count == 3){
             BigBrain.bigBrain.stage2Complete();
         }
     }
 }

 private void OnTriggerExit(Collider other) {
     if(other.CompareTag("lata")){
         count-=1;
     }
 }


}
