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
    public double yTransform;

    //change player scrit to use righthandtrigger rather than button A
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        debug.text = "" + leftHand.gm.ovenDoorHit;
        if (leftHand.gm.ovenDoorHit)
        {

            parent = leftHand.transform;
            handle.transform.SetParent(parent);

        }

    }
}
