using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeFlip : MonoBehaviour
{
    public GameObject cakePan;
    public GameManager gm;
    public OvenStuff oven;
    public GameObject underfilledAO;
    public GameObject averageAO;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CakePan"))
        {
            cakePan.SetActive(false);
            if (oven.underfilledTrue == true)
            {
              underfilledAO.gameObject.GetComponent<Renderer>().material = gm.underfilled.GetComponent<Renderer>().material;
              underfilledAO.SetActive(true);
            }
            else
            {
              averageAO.gameObject.GetComponent<Renderer>().material = gm.average.GetComponent<Renderer>().material;
              averageAO.SetActive(true);
            }
        }
    }
}
