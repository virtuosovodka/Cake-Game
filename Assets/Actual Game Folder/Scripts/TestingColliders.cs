using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestingColliders : MonoBehaviour
{
    public TextMeshProUGUI debug;

    // Start is called before the first frame update
    void Start()
    {
        debug.text = "Nothing pressed.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //left hand x button, hold down
        if (collision.gameObject.CompareTag("StartBelt") && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            debug.text = "X was pressed and belt was started.";
        }

    }
}
