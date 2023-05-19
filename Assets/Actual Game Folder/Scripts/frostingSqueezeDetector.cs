using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class frostingSqueezeDetector : MonoBehaviour
{
    public bool squeezing;
    //NOTE BY HODAKA
    //implemented small part of my modular event-based VR system
    //this script should be attached to each pipingbag

    //will implement later

    bool holding;

    InputDevice targetDevice;

    [SerializeField]
    GameObject full;
    [SerializeField]
    GameObject squeezed;

    private void Start()
    {
        squeezing = false;
        holding = false;

        List<InputDevice> devices = new List<InputDevice>();

        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
            targetDevice = devices[0];
    }

    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue);

        if (triggerButtonValue && holding)
        {
            squeezing = true;

            full.SetActive(false);
            full.SetActive(true);
        } else
        {
            squeezing = false;

            full.SetActive(true);
            full.SetActive(false);
        }
    }

    public void OnSelectFirstEntered()
    {
        holding = true;
    }

    public void OnSelectLastExit()
    {
        holding = false;
    }
}
