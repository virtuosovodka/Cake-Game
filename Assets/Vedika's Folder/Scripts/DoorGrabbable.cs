using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorGrabbable : OVRGrabbable
{
    public GameObject controller;
    public Transform parent;
    public GameObject doorHinge;
    public GameObject actualDoor;
    public TextMeshProUGUI text;

    void Start()
    {
        
    }

    void Update()
    {
        Transform childToRemove = controller.transform.Find("doorHinge");
        childToRemove.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GameController"))
        {
            //parent cube to hand
            doorHinge.transform.SetParent(parent);
            text.text = "GameController detected in door button.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
