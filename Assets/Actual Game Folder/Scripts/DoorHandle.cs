using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorHandle : MonoBehaviour
{
    //instantiating players and game manager
    public Player leftHand;
    public Player rightHand;
    public GameManager gm;
    public ConveyorBelt cb;

    //instantiating the handles that will go up and down at the same time and where the conveyor belt should stop
    public GameObject frontHandle;
    public GameObject backHandle;
    public GameObject frontDoorStop;
    public GameObject backDoorStop;
    //boolean that decides whether the handles are already up or whether they are down

    public bool ovenDoorUp = false;


    void Update()
    {
        OVRInput.Update();

        if (gm != null)
        {
            //checking if the oven handle has been hit and if the left hand or right hand trigger is down
            if ((gm.ovenDoorHit && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) || (gm.ovenDoorHit && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)))
            {
                if (!ovenDoorUp)
                {
                    //if the handles are down, in other words not up, both handles will go up instantly and the boolean up is true
                    frontHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                    backHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                    ovenDoorUp = true;

                    cb.frontOvenDoorStop.SetActive(false);
                    cb.backOvenDoorStop.SetActive(false);
                }
                else if (ovenDoorUp)
                {
                    //if the handles are up, both handles will go down instantly and the boolean up is false
                    frontHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                    backHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                    ovenDoorUp = false;

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //this makes the boolean ovenDoorHit true if a collision is detected between the handle and the hands
        if (gm.currentObject.CompareTag("OvenDoorHandle"))
        {
            gm.ovenDoorHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //this makes the boolean ovenDoorHit false when the collision is over
        gm.ovenDoorHit = false;
    }
}
