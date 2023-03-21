using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeChildren : MonoBehaviour
{
    public GameObject cakePan;
    public Transform parent;
    public GameObject batter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (cakePan.transform.rotation.x >= 170 & cakePan.transform.rotation.x <= 190 | cakePan.transform.rotation.z >=170 & cakePan.transform.rotation.x <= 190)
        //{
            //Transform childToRemove = cakePan.transform.Find("batter");
            //childToRemove.parent = null;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Batter"))
        {
            batter.transform.SetParent(parent);
            Debug.Log("connect");
            //batter.transform.parent = cakePan.transform.parent;
            //batter.transform.SetParent(cakePan.transform.parent);
        }
    }

}
