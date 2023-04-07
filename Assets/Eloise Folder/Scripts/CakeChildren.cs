using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeChildren : MonoBehaviour
{
    // removing cake from cake pan
    public GameObject cakePan;
    public Transform parent;
    public GameObject batter;

    // for points
    CakeOrder cakeOrder;
    Player player;
    Material playerBatter;
    Material playerFrosting;
    Material playerTopping;
    Material playerSprinkles;
    Material playerLiquid;
    int points = 0;
    int totalPoints;
    float timer = 0;
    float timerEnd;

    //for cherries
    int counter;
    public GameObject cherries;

    float detachTimer = 15;
    // Start is called before the first frame update
    void Start()
    {
        // referncing other scripts for variables connected toother objects
        cakeOrder = GameObject.FindObjectOfType<CakeOrder>();
        player = GameObject.FindObjectOfType<Player>();

        detachTimer -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        

        //timer for points
        timer += Time.deltaTime;

        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // adding batter to cake tin
        if (collision.gameObject.CompareTag("Batter"))
        {
            batter.transform.SetParent(parent);
            Debug.Log("connect");
        }


        // removing cake from cake pan
        if (collision.gameObject.CompareTag("CakeTin") && ((cakePan.transform.rotation.x >= 170 && cakePan.transform.rotation.x <= 190) || (cakePan.transform.rotation.z >= 170 && cakePan.transform.rotation.z <= 190)))
        {
            Transform childToRemove = cakePan.transform.Find("batter");
            childToRemove.parent = null;
        }



        //game ends when the cake reaches the counter
        if (collision.gameObject.CompareTag("Counter"))
        {
            if (cakeOrder == null)
            {
                cakeOrder = GameObject.FindObjectOfType<CakeOrder>();
            }
            else
            {

                //all of the things that influence points
                timerEnd = timer;
                if (timerEnd >= 10)
                {
                    points++;
                }

                if (playerBatter == cakeOrder.bOrder)
                {
                    points++;
                    // add cooked enough and amount of batter
                }
                if (player.timeInOven >= player.cookTime - 1 && player.timeInOven <= player.cookTime + 2)
                {
                    points++;
                }
                if (playerFrosting == cakeOrder.fOrder)
                {
                    points++;
                    // smoothness and amount
                }
                if (playerTopping == cakeOrder.tOrder)
                {
                    points++;
                    // placement and amount
                }
                if (playerSprinkles == cakeOrder.sOrder)
                {
                    points++;
                    // placement and amount
                }
                if (playerLiquid == cakeOrder.lOrder)
                {
                    points++;
                    // placement and amount
                }

                totalPoints = (points / 7) * 100;
            }
        }
    }


}
