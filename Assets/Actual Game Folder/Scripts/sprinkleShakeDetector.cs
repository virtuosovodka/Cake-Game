using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class sprinkleShakeDetector : MonoBehaviour
{
    bool holding;
    bool shook;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        holding = true;
        shook = false;
    }

    private void Update()
    {
        if (holding && rb.velocity.sqrMagnitude > 2f)
        {
            if (!shook)
            {
                shook = true;
                Debug.Log("shook!");
            }
        } else
        {
            shook = false;
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
