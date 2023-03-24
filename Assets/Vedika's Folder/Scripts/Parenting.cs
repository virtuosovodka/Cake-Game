using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Parenting : MonoBehaviour
{
    public Transform parent;
    public GameObject door;
    public GameObject handR;
    public GameObject handL;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MovePosition(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {/*
        text.text = "Collision detected!";
        if (collision.gameObject.CompareTag("Door"))
        {
            door.SetActive(false);
            //door.transform.SetParent(parent);
        }*/
    }
}
