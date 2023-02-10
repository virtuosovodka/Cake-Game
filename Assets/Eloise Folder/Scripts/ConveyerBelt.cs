using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public float moveSpeed = 2;
    public bool moveX = true;
    bool touchBelt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (moveX == true & touchBelt == true)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        print("collided");
        if (collision.gameObject.CompareTag("Belt"))
        {
            print ("collided");
            moveX = true;
            touchBelt = true;
        }
    }
}
