using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OvenStuff : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debug.text = "" + gm.ovenOn;
    }
}
