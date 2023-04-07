using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Batter : MonoBehaviour
{
    public GameObject batterButton;
    public GameObject batter;
    public bool frostingOn;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FrostingButton"))
        {
            if (other.gameObject.CompareTag("GameController")) //Right hand trigger squeezes out frosting
            {
                Frosting();
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                
            }
        }
    }

    void Frosting()
    {
        text.text = "Frosting is on!";
        frostingOn = true;
        //transform batter downwards until it hits the counter
    }
}
