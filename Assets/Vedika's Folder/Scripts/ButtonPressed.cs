using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using TMPro;


public class ButtonPressed : MonoBehaviour
{
    
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (OVRInput.Get(OVRInput.Button.One))
        {
            text.text = "Button One Pressed!";
        }
        else if (OVRInput.Get(OVRInput.Button.Two))
        {
            text.text = "Button Two Pressed!";
        }
    }
    
    
}
