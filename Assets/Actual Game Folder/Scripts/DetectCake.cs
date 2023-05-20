using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCake : MonoBehaviour
{
    //public GameObject cake;
    public GameManager gm;
    public ConveyorBelt cakeTin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            cakeTin.enabled = false;
            ConveyorBelt cb = GetComponent<ConveyorBelt>();
            
            
            //cb.moveZ = true;
            //cb.moveNegX = true;
            //cb.moveNegZ = true;

            cb.enabled = true;
            gm.moveX = true;
            gm.debug.text = " the conveyorBelt is eneabled " + cb.enabled;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Cake"))
        {
            cakeTin.enabled = false;
            ConveyorBelt cb = GetComponent<ConveyorBelt>();
            gm.enabled = true;
            gm.moveX = true;
            gm.moveZ = true;
            gm.moveNegX = true;
            gm.moveNegZ = true;

            
            gm.debug.text = " the conveyorBelt is eneabled " + cb.enabled;

            //un conveyor belt the cake tin
        }
    }

}
