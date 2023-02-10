using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPlayer : MonoBehaviour
{
    enum Station
    {
        Oven,

    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("Oven On");
            States.Station = Oven();
        }

        //oven door
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //hold and drag to reset door position.can't go past certain coordinates
            //door must be closed to turn oven on oven must be off to open door
        }
    }

    void Oven()
    {
        //on start of function begin baking animation (timer)
    }
}
