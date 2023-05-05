using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IpadGrabbing : MonoBehaviour
{
    public Player leftHand;
    public Player rightHand;
    public GameManager gm;
    public GameObject ipad;
    public TextMeshProUGUI debug;
    public GameObject leftHandChild;

    // Start is called before the first frame update
    void Start()
    {
        debug.text = "boo";
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (gm != null)
        {
            if (gm.ipadHit && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                //ipad.transform.position = leftHand.transform.GetChild(0).transform.position;
                debug.text = "yay!";
                ipad.transform.SetParent(leftHandChild.transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gm.currentObject.CompareTag("iPad"))
        {
            debug.text = "first yay!";
            gm.ipadHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gm.ipadHit = false;
    }
}
