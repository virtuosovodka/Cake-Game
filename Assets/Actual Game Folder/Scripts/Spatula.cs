using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    public GameManager gm;
    public Player p;
    public float smoothingFrosting;
    public bool spreadingFrosting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p.holdingSpatula == true)
        {
            if (spreadingFrosting == true) // && smoothingFrosting == 3)
            {
                Destroy (gm.frostingDollop);
                //TODO: set frosting material 
                gm.frosting = Instantiate(gm.frosting, gm.cake.transform.GetChild(0).position, gm.cake.transform.GetChild(0).rotation);
                gm.frosting.GetComponent<Renderer>().material = gm.frostingDollop.GetComponent<Renderer>().material;

                //Instantiate(flavor.GetComponent<Liquid>().liquidPrefab, gm.cake.transform.GetChild(0));
                //Instantiate(flavor.GetComponent<Liquid>().liquidPrefab, gm.cake.transform);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FrostingPile"))
        {
            //smoothingFrosting++;
            spreadingFrosting = true;
        }

    }


}
