using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePan : MonoBehaviour
{
    public GameManager gm;
    public ConveyorBelt cb;

    public GameObject Belt2;
    public GameObject Belt3;
    //public GameObject counter;
    public GameObject cakeBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      


                if (cb.cakeSwapping == true)
                {
           
            transform.Translate(0, 0, 0);

                }
            }
   
}
