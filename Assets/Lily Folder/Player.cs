using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject currentObject;
    Rigidbody rb;
    enum Station
    {
        Order,
        BeltOn,
        BeltOff,
        Batter,
        Oven,
        Frosting,
    }

    bool startOfState;
    Station state;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentObject = null;
        state = Station.Order;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: @Vedika, please remove this as well, this is temp for testing without vr
        //this ONLY WORKS with a z value of zero!!!!!!!
        rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        if (state == Station.Order)
        {

        }

        else if (state == Station.BeltOn)
        {

        }

        else if (state== Station.BeltOff)
        {

        }

        else if (state == Station.Batter)
        {

        }

        else if (state == Station.Oven)
        {
            Oven();
        }

        else if (state == Station.Frosting)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        currentObject = other.gameObject;
        print(currentObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        currentObject = null;
        print(currentObject.name);
    }

    //TODO: @Vedika move this to a vr function, should not appear in final game.
    void OnMouseOver()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("OvenOn") && state != Station.Oven)
        {
            print("Oven On");
            state = Station.Oven;
        }

        //oven door
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("OvenOff") && state != Station)
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
