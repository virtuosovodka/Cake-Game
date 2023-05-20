using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeFlip : MonoBehaviour
{
    public GameObject cakePan;
    public GameManager gm;
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
            gm.cake.transform.SetParent(transform, true);
            cakePan.SetActive(false);
        }
    }
}
