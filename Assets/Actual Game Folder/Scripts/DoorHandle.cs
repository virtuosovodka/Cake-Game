using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorHandle : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public Player leftHand;
    public Player rightHand;
    //change player scrit to use righthandtrigger rather than button A
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debug.text = " " + leftHand.ovenDoorHit;
        if (leftHand.ovenDoorHit || rightHand.ovenDoorHit)
        {
            
        }
    }
}
