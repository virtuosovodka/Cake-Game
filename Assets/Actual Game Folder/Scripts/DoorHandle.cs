using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorHandle : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public Player leftHand;
    public Player rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (leftHand.ovenDoorHit || rightHand.ovenDoorHit)
        //{
            if (OVRInput.Get(OVRInput.RawButton.LHandTrigger)){

            }
        //}
    }
}
