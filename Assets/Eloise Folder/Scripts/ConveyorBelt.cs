using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed = 2;
    public bool moveX = true;
    public GameObject Belt2;
    public GameObject Belt3;
    bool moveZ = true;
    public GameObject counter;
    bool moveNegX = true;
    Player player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.beltOn)
        {
            if (moveX == true)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (gameObject.transform.position.x >= Belt2.transform.position.x & moveZ == true)
            {

                moveX = false;
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            }
            if (gameObject.transform.position.z <= Belt3.transform.position.z & moveNegX == true)
            {

                moveZ = false;
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
            if (gameObject.transform.position.x <= counter.transform.position.x)
            {
                moveNegX = false;

            }
        }

    }

}
