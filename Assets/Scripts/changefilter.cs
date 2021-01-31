using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class changefilter : MonoBehaviour
{
    public VolumeProfile[] profiles;
    public Volume volume;
    // Start is called before the first frame update

    void Start()
    {  

        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("redFilter")){
            volume.profile = profiles[2];
        }
        if (other.CompareTag("greenFilter")){
           volume.profile = profiles[1];
        }
        if (other.CompareTag("blueFilter")){
           volume.profile = profiles[0];
        }
        if (other.CompareTag("removeFilter")){
            volume.profile = null;
        }

    }
}
