using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorHandle : MonoBehaviour
{
    public Player leftHand;
    public Player rightHand;
    public Transform parent;
    public GameManager gm;
    public GameObject handle;
    public TextMeshProUGUI debug;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (debug != null)
        {
            //debug.text = "" + leftHand.gm.ovenDoorHit;
        }
        
        if (gm != null)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))//gm.ovenDoorHit && 
            {
                //parent = leftHand.transform;
                debug.text = "yay";
                //handle.transform.Translate(0, 0, Time.deltaTime * speed);
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                /*
                gm.ovenDoorHit = false;
                Transform childToRemove = leftHand.transform.Find("OvenDoorHandle");
                childToRemove.parent = null;
                */
                debug.text = "boo";
                handle.transform.Translate(0, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gm.currentObject.CompareTag("OvenDoorHandle"))
        {
            gm.ovenDoorHit = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        gm.ovenDoorHit = false;
    }
}
