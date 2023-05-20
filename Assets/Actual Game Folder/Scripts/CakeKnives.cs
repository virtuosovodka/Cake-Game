using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeKnives : MonoBehaviour
{
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
      if (collision.gameObject.CompareTag("Knife"))
      {
        Debug.Log("dude");
        gm.cake.transform.GetChild(0).gameObject.SetActive(false);
      }
    }
}
