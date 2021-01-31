using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBrain : MonoBehaviour {

    public static BigBrain bigBrain;
    public GameObject frontDoor;
    public GameObject roomDoor;
    public GameObject roomBackDoor;
    public GameObject gardenDoor;
    public GameObject stairs;

    public GameObject redSwitch;
    public GameObject blueSwitch;
    public GameObject greenSwitch;

    public bool enterHouse;
    public bool enterRoom;
    public bool enterRoof;


    // Start is called before the first frame update
    void Start () {
        bigBrain=this;
        frontDoor.SetActive(true);
        roomDoor.SetActive(true);
        roomBackDoor.SetActive(true);
        gardenDoor.SetActive(true);
        stairs.SetActive(true);
        redSwitch.transform.GetChild(0).gameObject.SetActive(false);
        blueSwitch.transform.GetChild(0).gameObject.SetActive(false);
        greenSwitch.transform.GetChild(0).gameObject.SetActive(false);
        redSwitch.transform.GetChild(1).GetComponent<Animator>().SetBool("open",false);
        blueSwitch.transform.GetChild(1).GetComponent<Animator>().SetBool("open",false);
        greenSwitch.transform.GetChild(1).GetComponent<Animator>().SetBool("open",false);

    }

    public void stage1Complete(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("PuertaAbierta");
        frontDoor.SetActive(false);
        redSwitch.transform.GetChild(0).gameObject.SetActive(true);
        redSwitch.transform.GetChild(1).GetComponent<Animator>().SetBool("open",true);
    }

    public void stage2Complete(){
        blueSwitch.transform.GetChild(0).gameObject.SetActive(true);
        blueSwitch.transform.GetChild(1).GetComponent<Animator>().SetBool("open",true);
        roomDoor.SetActive(false);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("PuertaAbierta");
    }

    public void stage3Complete(){
        greenSwitch.transform.GetChild(0).gameObject.SetActive(true);
        greenSwitch.transform.GetChild(1).GetComponent<Animator>().SetBool("open",true);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("MensajeEncontrado");

    }

}