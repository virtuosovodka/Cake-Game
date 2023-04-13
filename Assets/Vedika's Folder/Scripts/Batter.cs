using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Batter : MonoBehaviour
{

    public GameObject batterButton;
    public GameObject batter;
    public bool batterOn;
    public TextMeshProUGUI text;
    public Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        ren.material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        text.text = "Batter is on!";
        ren.material.color = Color.red;
        if (other.gameObject.CompareTag("GameController"))
        {
            
        }
    }

    private void OnCollisionExit(Collision other)
    {
        BatterOff();
    }

    void BatterOn()
    {
        ren.material.color = Color.white;
        text.text = "Batter is on!";
        batterOn = true;
        //transform batter downwards until it hits the counter
    }

    void BatterOff()
    {
        ren.material.color = Color.black;
        text.text = "Batter is off!";
        batterOn = false;
        //transform batter downwards until it hits the counter
    }
}