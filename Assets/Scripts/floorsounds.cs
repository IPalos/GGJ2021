using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class floorsounds : MonoBehaviour {

    public AudioManager audioManager;
    Rigidbody rigidbody;
    Sound sPasto;
    Sound sConcreto;
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        sPasto = Array.Find(audioManager.sounds,sound => sound.name == "Pasto");
        sConcreto = Array.Find(audioManager.sounds,sound => sound.name == "Concreto");
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("pasto")){
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Pasto");
        }
        if(other.CompareTag("concreto")){
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Concreto");
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("pasto")){
            sPasto.source.volume = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0).normalized.magnitude;
        }
        if(other.CompareTag("concreto")){
            sConcreto.source.volume = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0).normalized.magnitude;

        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("pasto")){
            sPasto.source.volume = 0;
        }
        if(other.CompareTag("concreto")){
            sConcreto.source.volume = 0;
        }
    }

}