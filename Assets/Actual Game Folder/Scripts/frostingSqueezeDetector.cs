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

    [SerializeField]
    ParticleSystem frostingParticle;

    [SerializeField]
    ParticleSystemRenderer particleRenderer;

    [SerializeField]
    Material colorMat;

    private void Start()
    {
        squeezing = false;
        holding = false;

        List<InputDevice> devices = new List<InputDevice>();

        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
            targetDevice = devices[0];

        particleRenderer.material = colorMat;

        //frostingParticle.Stop();
    }

    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue);

        if (triggerButtonValue && holding || Input.GetKey(KeyCode.N))
        {
            squeezing = true;

            full.SetActive(false);
            squeezed.SetActive(true);

            if (frostingParticle.isStopped)
                frostingParticle.Play();
        } else
        {
            squeezing = false;

            full.SetActive(true);
            squeezed.SetActive(false);

            if (frostingParticle.isPlaying)
                frostingParticle.Stop();
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
