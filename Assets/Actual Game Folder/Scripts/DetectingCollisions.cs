using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectingCollisions : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.CompareTag("StartBelt"))
        //{
            if (OVRInput.GetDown(OVRInput.RawButton.X))
            {
                text.text = "X pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                text.text = "Y pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.One))
            {
                text.text = "A pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                text.text = "B pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                text.text = "Left Index Trigger Pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                text.text = "Right Index Trigger Pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) //left hand trigger
            {
                text.text = "Left Hand Trigger Pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)) //right hand trigger
            {
                text.text = "Right Hand Trigger Pressed!";
            }
        //}
    }

    private void OnTriggerExit(Collider other)
    {

    }

}