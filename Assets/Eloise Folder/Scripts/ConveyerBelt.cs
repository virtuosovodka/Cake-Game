using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public float moveSpeed = 2;
    public bool moveX = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveX == true)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            print("collided");
            moveX = false;
        }
    }
}
