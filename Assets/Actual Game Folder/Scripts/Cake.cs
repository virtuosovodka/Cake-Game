using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public Transform Parent;
    public bool cakeFlipped;
    public GameObject cakePlate;
    public GameObject cakePan;
    public GameManager gm;
    public GameObject knife;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cakePan.transform.rotation.eulerAngles.y >= 160 && cakePan.transform.rotation.eulerAngles.y <= 200)
        {
            cakeFlipped = true;
            gm.cake.transform.position = cakePlate.transform.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        print("we hit somethig");

        if (collision.gameObject.CompareTag("CakeBox"))
        {
            collision.transform.SetParent(Parent);
        }

        if (collision.gameObject.CompareTag("Knife")){
            gm.cake.GetChild(0).SetActive(false);
        }
    }
}
