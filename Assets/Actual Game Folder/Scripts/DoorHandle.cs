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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        debug.text = "" + leftHand.gm.ovenDoorHit;
        
        if (gm.ovenDoorHit)
        {
            parent = leftHand.transform;
            handle.transform.SetParent(parent);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gm.currentObject.CompareTag("OvenDoorHandle"))// || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            gm.ovenDoorHit = true;
        }
    }
}
