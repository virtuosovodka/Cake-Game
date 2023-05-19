using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTest : MonoBehaviour
{
    public AudioSource doorBell;
    // Start is called before the first frame update
    void Start()
    {
        doorBell = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            doorBell.Play();
        }
    }
}
