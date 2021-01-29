using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Reflection;

public class changefilter : MonoBehaviour
{
    public VolumeProfile[] profiles;
    // Start is called before the first frame update

    void Start()
    {  

        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("volume")){
            other.GetComponent<Volume>().profile = profiles[Random.Range(0,3)];
            // Debug.Log(other.GetComponent<Volume>().profile.GetComponent<>);
            // FieldInfo[] fields = typeof(VolumeComponent).GetFields();
            // foreach (var field in fields)
            // {
            //     // Debug.Log(field);
            // }
            // other.GetComponent<Volume>().profile.colorAdjustments.colorFilter = new Color(0,0,0);
        }

    }
}
